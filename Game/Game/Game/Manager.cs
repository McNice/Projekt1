using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Manager
    {
        public Random rng;
        public List<Player> players = new List<Player>();
        public List<string> bricks = new List<string>();
        public List<string> grass = new List<string>();

        Keys[] p1Keys = { Keys.A, Keys.D, Keys.W, Keys.S, Keys.Space, Keys.G };
        Keys[] p2Keys = { Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightControl, Keys.Enter };

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
            map = new Map(Game1.TILESX, Game1.TILESY);
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
                players.Add(new Player("P2 Sprite", map.spawnPoint + new Vector2(50, 0), "Player2", p2Keys));
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

            foreach (Animated ani in map.mapArray.OfType<Animated>())
            {
                ani.Update(gameTime);
            }
            foreach (Lava lava in map.mapArray.OfType<Lava>())
            {
                lava.Update(gameTime);
            }
            foreach (Tile at in map.mapArray)
                if (at is ArrowTrap)
                    (at as ArrowTrap).Update(gameTime);


            if (oldks.IsKeyDown(Keys.I) && ks.IsKeyUp(Keys.I))
                gamemode = 2;
        }

        void CollisionJohan(Player p, GameTime gameTime, ref int mode)
        {
            p.onLadder = false;
            p.jumping = true;
            p.ladderCount = 0;
            foreach (Tile t in map.mapArray)
            {
                if (t is SolidBlock)
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
                if (t is Door)
                {
                    if (p.BoundsStatic().Intersects((t as Door).Bounds()) && (t as Door).start == true)
                    {
                        p.Collision((t as Door).Bounds());
                    }
                }
                if (t is ButtonLever && p.BoundsStatic().Intersects(t.Bounds()))
                {
                    if (KeyClick(p.keys[5]))
                    {
                        foreach (Animated ani in map.mapArray.OfType<Animated>())
                        {
                            if (ani.channel == (t as ButtonLever).channel)
                            {
                                ani.Switch();
                            }
                        }
                    }
                }
                if (t is Ladder && (t as Ladder).Bounds().Intersects(p.BoundsStatic()))
                    p.OnLadder();
                if (t is HellDoor && (t as HellDoor).open && (t as HellDoor).Bounds().Intersects(p.BoundsStatic()))
                    mode = 2;
            }
        }

        bool KeyDown(Keys key)
        {
            if (ks.IsKeyDown(key))
                return true;
            return false;
        }

        bool KeyUp(Keys key)
        {
            if (ks.IsKeyUp(key))
                return true;
            return false;
        }

        public bool KeyClick(Keys key)
        {
            if (ks.IsKeyDown(key) && oldks.IsKeyUp(key))
                return true;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Player p in players)
            {
                p.Draw(spriteBatch);
            }
            map.Draw(spriteBatch);
        }
    }
}
