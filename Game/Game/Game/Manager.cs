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
        Random rng;
        public bool multiPlayer, isOnGround;

        List<Player> players = new List<Player>();
        List<string> bricks = new List<string>();
        List<string> grass = new List<string>();

        Keys[] p1Keys = { Keys.A, Keys.D, Keys.W, Keys.S, Keys.Space, Keys.G };
        Keys[] p2Keys = { Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.RightControl, Keys.Enter };

        Map map;
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
            map.LoadMap("a1", bricks, grass, rng);
        }

        public void LoadContent()
        {
            NewGame();
        }

        public void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            foreach (Player p in players)
            {
                p.Update(gameTime);
                CollisionJohan(p, gameTime);
            }
            foreach (Animated ani in map.mapArray.OfType<Animated>())
            {
                ani.Update(gameTime);
            }
            oldks = ks;
        }

        void CollisionJohan(Player p, GameTime gameTime)
        {
            p.onLadder = false;
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
                    if (KeyClick(Keys.Enter) && (t as Door).start == true)
                    {
                        (t as Door).start = false;
                    }
                }
                if (t is ButtonLever && p.BoundsStatic().Intersects(t.Bounds()))
                {
                    if (KeyDown(Keys.G))
                    {
                        (t as ButtonLever).on = true;
                    }
                    if (KeyDown(Keys.H))
                    {
                        (t as ButtonLever).on = false;
                    }
                }
                if (t is Ladder && (t as Ladder).Bounds().Intersects(p.BoundsStatic()))
                    p.onLadder = true;

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

        bool KeyClick(Keys key)
        {
            if (ks.IsKeyDown(key) && oldks.IsKeyUp(key))
                return true;
            return false;
        }

        public void NewGame()
        {
            if (!multiPlayer)
            {
                players.Add(new Player("Gubbsprite", map.spawnPoint, "Player1", p1Keys));
            }
            else if (multiPlayer)
            {
                players.Add(new Player("Gubbsprite", map.spawnPoint, "Player1", p1Keys));
                players.Add(new Player("Gubbsprite", map.spawnPoint + new Vector2(50, 0), "Player2", p2Keys));
            }
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
