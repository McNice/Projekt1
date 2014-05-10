﻿using System;
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
                //             LadderClimb(p);
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


                    ///Behover fixas!!
                    //else if (KeyClick(Keys.Enter) && (t as Door).start == false)
                    //{
                    //    (t as Door).start = true;
                    //}
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

        //bool CollisionCheck(Player p, Tile t, Keys key)
        //{
        //    int direction = 1;
        //    if (key == Keys.A)
        //        direction = -1;
        //    if (p.Bounds(p.pos, p.runningSpeed * direction).Intersects(t.Bounds()))
        //        return true;
        //    return false;
        //}

        //void Collision(Player p)
        //{
        //    int collisionCount = 0;
        //    if (KeyDown(Keys.A) || KeyDown(Keys.D))
        //    {
        //        foreach (Tile t in map.mapArray)
        //        {
        //            if (t is SolidBlock && KeyDown(Keys.D) && CollisionCheck(p, t, Keys.D))
        //            {
        //                collisionCount++;
        //                break;
        //            }
        //            if (t is SolidBlock && KeyDown(Keys.A) && CollisionCheck(p, t, Keys.A))
        //            {
        //                collisionCount++;
        //                break;
        //            }
        //        }

        //        if (collisionCount == 0 && KeyDown(Keys.D))
        //            p.PlayerMovement(Keys.D);
        //        else if (collisionCount == 0 && KeyDown(Keys.A))
        //            p.PlayerMovement(Keys.A);

        //    }
        //    else if (KeyUp(Keys.D) && KeyUp(Keys.A))
        //        p.runningSpeed = 0;
        //    if (p.velocity.Y > 0)
        //    {
        //        foreach (Tile s in map.mapArray)
        //        {
        //            if (s is SolidBlock && p.pos.Y < s.pos.Y && ColCheck(p, s))
        //            {
        //                p.pos.Y = s.pos.Y - 2 * Game1.TILESIZE;
        //                p.velocity.Y = 0;
        //                isOnGround = true;
        //                break;
        //            }
        //        }
        //    }
        //    else if (p.velocity.Y < 0)
        //    {
        //        foreach (Tile s in map.mapArray)
        //        {
        //            if (s is SolidBlock && p.pos.Y > s.pos.Y && ColCheck(p, s))
        //            {
        //                p.pos.Y = s.pos.Y + Game1.TILESIZE;
        //                p.velocity.Y = 0;
        //                isOnGround = true;
        //                break;
        //            }
        //        }
        //    }
        //}

        //void LadderClimb(Player p)
        //{
        //    foreach (Tile t in map.mapArray)
        //        if (t is Ladder && p.BoundsStatic().Intersects(t.Bounds()))
        //        {
        //            p.velocity.Y = 0;
        //            int climingSpeed = 3;
        //            if (KeyDown(Keys.W) && ColCheck(p, Keys.W, climingSpeed))
        //            {
        //                p.pos.Y -= climingSpeed;
        //            }
        //            else if (KeyDown(Keys.S) && ColCheck(p, Keys.S, climingSpeed))
        //            {
        //                p.pos.Y += climingSpeed;
        //            }
        //            if (KeyUp(Keys.D) && KeyUp(Keys.A))
        //                p.pos.X = t.pos.X;

        //            break;
        //        }
        //}

        //bool ColCheck(Player p, Keys key, int climbingSpeed)
        //{
        //    int i = 10000;

        //    foreach (Tile t in map.mapArray)
        //    {
        //        if (t is SolidBlock)
        //        {
        //            Rectangle tileRec = t.Bounds();
        //            if (key == Keys.S && new Rectangle((int)(p.pos.X * i), (int)((p.pos.Y + 3) * i), Game1.TILESIZE * i, Game1.TILESIZE * i * 2).Intersects(new Rectangle(tileRec.X * i, tileRec.Y * i, tileRec.Width * i, tileRec.Height * i)))
        //                return false;
        //            else if (key == Keys.W && new Rectangle((int)(p.pos.X * i), (int)((p.pos.Y - 3) * i), Game1.TILESIZE * i, Game1.TILESIZE * i * 2).Intersects(new Rectangle(tileRec.X * i, tileRec.Y * i, tileRec.Width * i, tileRec.Height * i)))
        //                return false;
        //        }
        //    }

        //    return true;
        //}

        //bool ColCheck(Player p, Tile s)
        //{
        //    int i = 10000;
        //    if (new Rectangle((int)(p.pos.X * i), (int)(p.pos.Y * i), Game1.TILESIZE * i, 2 * Game1.TILESIZE * i).Intersects(new Rectangle(s.Bounds().X * i, s.Bounds().Y * i, s.Bounds().Width * i, s.Bounds().Height * i)))
        //        return true;
        //    else
        //        return false;
        //}

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
