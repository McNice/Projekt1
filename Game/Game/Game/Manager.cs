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
        public bool multiPlayer;
        
        List<Player> players = new List<Player>();

        Map map;
        public static string path = "../../../../../../Maps/";



        public Manager()
        {
            map = new Map(Game1.TILESX, Game1.TILESY);
            map.LoadMap("anton");
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
                Collision(p);
                LadderClimb(p);
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
            if (p.velocity.Y > 0)
            {
                foreach (Tile s in map.mapArray)
                {
                    if (s is SolidBlock && p.position.Y < s.pos.Y && ColCheck(p, s))
                    {
                        p.position.Y = s.pos.Y - 2 * Game1.TILESIZE;
                        p.velocity.Y = 0;
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
                    if (KeyDown(Keys.W))
                    {
                        p.position.Y -= 3;
                    }
                    else if (KeyDown(Keys.S))
                    {
                        p.position.Y += 3;
                    }
                    if (KeyUp(Keys.D) && KeyUp(Keys.A))
                        p.position.X = t.pos.X;

                    break;
                }
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

        //void Collision(Player p, int a)
        //{
        //    FloatRect rect = p.Rect(0);
        //    FloatRect pR = p.Rect(1);

        //    foreach (Tile t in map.mapArray)
        //    {
        //        if (t is SolidBlock)
        //        {
        //            if (t.Bounds().Intersects(p.BoundsStatic()))
        //            {
        //                if (pR.Pos.X + pR.Dim.X > t.pos.X && (
        //            }
        //        }
        //    }
        //}

        public void NewGame()
        {
            if (!multiPlayer)
            {
                players.Add(new Player(Game1.mediaManager.Texture("Monopoly man 50x100"), new Vector2(300, 300), "Player1"));
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
