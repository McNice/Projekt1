using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Manager
    {
        public Random rng;
        public List<Player> players = new List<Player>();
        public List<string> bricks = new List<string>();
        public List<string> grass = new List<string>();
        Texture2D guiTex;

        public PlayerInput[] p1Keys = { PlayerInput.PlayerOneLeft, PlayerInput.PlayerOneRight, PlayerInput.PlayerOneUp, PlayerInput.PlayerOneDown, PlayerInput.PlayerOneYellow, PlayerInput.PlayerOneRed };
        public PlayerInput[] p2Keys = { PlayerInput.PlayerTwoLeft, PlayerInput.PlayerTwoRight, PlayerInput.PlayerTwoUp, PlayerInput.PlayerTwoDown, PlayerInput.PlayerTwoYellow, PlayerInput.PlayerTwoRed };

        public Map map;
        public static string path = "../../../../../../Maps/";
        KeyboardState ks, oldks;

        public Manager()
        {
            rng = new Random();
            bricks.Add("Fine Brick 2");
            bricks.Add("Fine Brick 3");
            bricks.Add("Fine Brick 4");
            bricks.Add("Fine Brick 5");
            grass.Add("Low Grass");
            grass.Add("Low Grass");
            grass.Add("Low Grass");
            grass.Add("Low Grass 1");
            map = new Map(Game.TILESX, Game.TILESY);
            guiTex = Game.mediaManager.Texture("GUI");
        }

        public void NewGame(bool multiPlayer)
        {
            players.Clear();
            if (!multiPlayer)
            {
                players.Add(new Player("P1 Sprite", map.spawnPoint, "Player1", p1Keys));
            }
            else if (multiPlayer)
            {
                players.Add(new Player("P1 Sprite", map.spawnPoint, "Player1", p1Keys));
                players.Add(new Player("P2 Sprite", map.spawnPoint2, "Player2", p2Keys));
            }
        }

        public void Update(GameTime gameTime, ref int gamemode)
        {
            oldks = ks;
            ks = Keyboard.GetState();
            foreach (Player p in players)
            {
                p.Update(gameTime);
                CollisionJohan(p, gameTime, ref gamemode);
            }

            if (players.All<Player>(x => x.fin))
                gamemode = 2;

            foreach (Animated ani in map.mapArray.OfType<Animated>())
            {
                ani.Update(gameTime);
            }
            foreach (Lava lava in map.mapArray.OfType<Lava>())
            {
                lava.Update(gameTime);
            }
            foreach (ArrowTrap at in map.mapArray.OfType<ArrowTrap>())
                if (at is ArrowTrap)
                    (at as ArrowTrap).Update(gameTime);

            if (Vicotry())
            {
                Game.victory.Play();
                gamemode = 2;
            }

            if (oldks.IsKeyDown(Keys.I) && ks.IsKeyUp(Keys.I))
                gamemode = 2;
            if (Timer.end)
                gamemode = 1;
        }

        bool Vicotry()
        {
            int i = 0;
            foreach (Player p in players)
                foreach (HellDoor h in map.mapArray.OfType<HellDoor>())
                {
                    if (p.BoundsStatic().Intersects(h.Bounds()))
                        i++;
                }

            if (i >= players.Count)
                return true;
            else
                return false;

        }

        void CollisionJohan(Player p, GameTime gameTime, ref int mode)
        {
            p.onLadder = false;
            p.jumping = true;
            p.fin = false;
            foreach (Tile t in map.mapArray)
            {
                if (t is SolidBlock)
                {
                    if (t.Bounds().Intersects(p.BoundsStatic()))
                    {
                        if (t is Slope)
                        {
                            foreach (Rectangle r in (t as Slope).rectList)
                            {
                                if (r.Intersects(p.BoundsStatic()))
                                    p.Collision(r);
                            }
                        }
                        else
                            p.Collision(t.Bounds());
                    }
                    if (t is ArrowTrap)
                    {
                        foreach (Arrow a in (t as ArrowTrap).arrows)
                        {
                            if (a.Bounds().Intersects(p.ArrowColBounds()))
                            {
                                mode = 1;
                                Game.getHurt.Play();
                            }
                            foreach (SolidBlock s in map.mapArray.OfType<SolidBlock>())
                            {
                                if (s != t)
                                {
                                    if (a.Bounds().Intersects(s.Bounds()))
                                        a.dead = true;
                                }
                            }
                            foreach (Door d in map.mapArray.OfType<Door>())
                            {
                                if (a.Bounds().Intersects(d.Bounds()) && d.start == true)
                                    a.dead = true;
                            }
                        }
                    }
                }

                if (t is Door)
                {
                    if (p.BoundsStatic().Intersects((t as Door).Bounds()) && (t as Door).start == true)
                    {
                        p.Collision((t as Door).Bounds());
                    }
                }
                if (t is ButtonLever && p.BoundsStatic().Intersects(t.Bounds()))
                {
                    if (InputHandler.GetButtonState(p.keys[5]) == InputState.Pressed)
                    {
                        foreach (Animated ani in map.mapArray.OfType<Animated>())
                        {
                            if (ani.channel == (t as ButtonLever).channel)
                            {
                                if ((t as ButtonLever).arg != 0)
                                    Game.leverPull.Play();
                                ani.Switch();
                            }
                        }
                    }
                }
                if (t is Ladder && (t as Ladder).Bounds().Intersects(p.BoundsStatic()))
                    p.OnLadder();


                if (t is Lava && (t as Lava).Bounds().Intersects(p.BoundsStatic()))
                {
                    Game.getHurt.Play();
                    mode = 1;
                }
            }
        }

        //bool KeyDown(Keys key)
        //{
        //    if (ks.IsKeyDown(key))
        //        return true;
        //    return false;
        //}

        //bool KeyUp(Keys key)
        //{
        //    if (ks.IsKeyUp(key))
        //        return true;
        //    return false;
        //}

        //public bool KeyClick(Keys key)
        //{
        //    if (ks.IsKeyDown(key) && oldks.IsKeyUp(key))
        //        return true;
        //    return false;
        //}

        public void Draw()
        {
            foreach (Player p in players)
            {
                p.Draw();
            }
            map.Draw();
            Renderer.Draw(guiTex, new Vector2(0, 960), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
        }
    }
}
