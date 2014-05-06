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

        Map map;
        public static string path = "../../../../../../Maps/";

        public Manager()
        {
            rng = new Random();
            bricks.Add("Fine Brick 2");
            bricks.Add("Fine Brick 3");
            bricks.Add("Fine Brick 4");
            bricks.Add("Fine Brick 5");
            map = new Map(Game1.TILESX, Game1.TILESY);
            map.LoadMap("a3", bricks, rng);
        }

        public void LoadContent()
        {
            NewGame();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Player p in players)
            {
                p.Update(gameTime);
                CollisionJohan(p);
                //             LadderClimb(p);
            }
            foreach (Tile t in map.mapArray)
            {
                if (t is Animated)
                {
                    (t as Animated).Update(gameTime); 
                }
                if (t is ButtonLever && Keyboard.GetState().IsKeyDown(Keys.G) && (t as ButtonLever).on == false)
                {
                    (t as ButtonLever).on = true;
                }
                if (t is ButtonLever && Keyboard.GetState().IsKeyDown(Keys.H) && (t as ButtonLever).on == true)
                {
                    (t as ButtonLever).on = false;
                }
            }
        }

        void CollisionJohan(Player p)
        {
            foreach (Tile t in map.mapArray)
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
        }

        bool CollisionCheck(Player p, Tile t, Keys key)
        {
            int direction = 1;
            if (key == Keys.A)
                direction = -1;
            if (p.Bounds(p.position, p.runningSpeed * direction).Intersects(t.Bounds()))
                return true;
            return false;
        }

        void Collision(Player p)
        {
            int collisionCount = 0;
            if (KeyDown(Keys.A) || KeyDown(Keys.D))
            {
                foreach (Tile t in map.mapArray)
                {
                    if (t is SolidBlock && KeyDown(Keys.D) && CollisionCheck(p, t, Keys.D))
                    {
                        collisionCount++;
                        break;
                    }
                    if (t is SolidBlock && KeyDown(Keys.A) && CollisionCheck(p, t, Keys.A))
                    {
                        collisionCount++;
                        break;
                    }
                }

                if (collisionCount == 0 && KeyDown(Keys.D))
                    p.PlayerMovement(Keys.D);
                else if (collisionCount == 0 && KeyDown(Keys.A))
                    p.PlayerMovement(Keys.A);

            }
            else if (KeyUp(Keys.D) && KeyUp(Keys.A))
                p.runningSpeed = 0;
            if (p.velocity.Y > 0)
            {
                foreach (Tile s in map.mapArray)
                {
                    if (s is SolidBlock && p.position.Y < s.pos.Y && ColCheck(p, s))
                    {
                        p.position.Y = s.pos.Y - 2 * Game1.TILESIZE;
                        p.velocity.Y = 0;
                        isOnGround = true;
                        break;
                    }
                }
            }
            else if (p.velocity.Y < 0)
            {
                foreach (Tile s in map.mapArray)
                {
                    if (s is SolidBlock && p.position.Y > s.pos.Y && ColCheck(p, s))
                    {
                        p.position.Y = s.pos.Y + Game1.TILESIZE;
                        p.velocity.Y = 0;
                        isOnGround = true;
                        break;
                    }
                }
            }
        }

        void LadderClimb(Player p)
        {
            foreach (Tile t in map.mapArray)
                if (t is Ladder && p.BoundsStatic().Intersects(t.Bounds()))
                {
                    p.velocity.Y = 0;
                    int climingSpeed = 3;
                    if (KeyDown(Keys.W) && ColCheck(p, Keys.W, climingSpeed))
                    {
                        p.position.Y -= climingSpeed;
                    }
                    else if (KeyDown(Keys.S) && ColCheck(p, Keys.S, climingSpeed))
                    {
                        p.position.Y += climingSpeed;
                    }
                    if (KeyUp(Keys.D) && KeyUp(Keys.A))
                        p.position.X = t.pos.X;

                    break;
                }
        }

        bool ColCheck(Player p, Keys key, int climbingSpeed)
        {
            int i = 10000;

            foreach (Tile t in map.mapArray)
            {
                if (t is SolidBlock)
                {
                    Rectangle tileRec = t.Bounds();
                    if (key == Keys.S && new Rectangle((int)(p.position.X * i), (int)((p.position.Y + 3) * i), Game1.TILESIZE * i, Game1.TILESIZE * i * 2).Intersects(new Rectangle(tileRec.X * i, tileRec.Y * i, tileRec.Width * i, tileRec.Height * i)))
                        return false;
                    else if (key == Keys.W && new Rectangle((int)(p.position.X * i), (int)((p.position.Y - 3) * i), Game1.TILESIZE * i, Game1.TILESIZE * i * 2).Intersects(new Rectangle(tileRec.X * i, tileRec.Y * i, tileRec.Width * i, tileRec.Height * i)))
                        return false;
                }
            }

            return true;
        }

        bool KeyDown(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return true;
            return false;
        }

        bool KeyUp(Keys key)
        {
            if (Keyboard.GetState().IsKeyUp(key))
                return true;
            return false;
        }

        bool ColCheck(Player p, Tile s)
        {
            int i = 10000;
            if (new Rectangle((int)(p.position.X * i), (int)(p.position.Y * i), Game1.TILESIZE * i, 2 * Game1.TILESIZE * i).Intersects(new Rectangle(s.Bounds().X * i, s.Bounds().Y * i, s.Bounds().Width * i, s.Bounds().Height * i)))
                return true;
            else
                return false;
        }

        public void NewGame()
        {
            if (!multiPlayer)
            {
                players.Add(new Player(Game1.mediaManager.Texture("Monopoly man 50x100"), new Vector2(600, 400), "Player1"));
            }
            else if (multiPlayer)
            {
                players.Add(new Player(Game1.mediaManager.Texture("Monopoly man 50x100"), new Vector2(300, 300), "Player1"));
                players.Add(new Player(Game1.mediaManager.Texture("Monopoly man 50x100"), new Vector2(400, 300), "Player2"));
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
