using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Player
    {
        Texture2D texture;
        public Vector2 pos, prevpos;
        public Vector2 velocity;
        Vector2 gravity;
        public float
            runningSpeed = 0,
            acceleration = 0.08f,
            maxSpeed = 3.5f,
            breakSpeed = 0.5f;

        string player;
        double time;
        ParticleEngine particle;
        Vector2 particleVec = new Vector2(5, 40);
        KeyboardState ks, oldks;

        Keys[] keys;


        Vector2[] colP = { new Vector2(10, 0), new Vector2(30, 0), 
                             new Vector2(0, 10), new Vector2(48, 10), 
                             new Vector2(0, 86), new Vector2(48, 86),
                         new Vector2(18, 96), new Vector2(30, 96)};

        public bool jumping, onLadder;

        public Player(Texture2D texture, Vector2 pos, string player, Keys[] keys)
        {
            this.texture = texture;
            this.pos = pos;
            this.player = player;
            this.gravity = new Vector2(0, 700);
            particle = new ParticleEngine("Smoketex", pos + particleVec);
            this.keys = keys;
        }

        public void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            if (KeyDown(keys[0]))
                PlayerMovement(Keys.A);
            else if (KeyDown(keys[1]))
                PlayerMovement(Keys.D);
            else { runningSpeed = 0; }

            time = gameTime.ElapsedGameTime.TotalSeconds;
            pos.X += runningSpeed * (float)time;
            if (onLadder)
            {
                if (KeyDown(keys[2]))
                    pos.Y -= 100 * (float)time;
                if (KeyDown(keys[3]))
                    pos.Y += 100 * (float)time;
            }
            else
            {
                if (velocity.Y >= 200)
                {
                    velocity.Y = 200;
                    pos += (velocity * (float)time);
                }
                else
                {
                    velocity += gravity * (float)time;
                    pos += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
                }
            }

            particle.pos = pos + particleVec;
            particle.Update(gameTime);

            //if (Math.Abs(velocity.Y) < 12 && ks.IsKeyDown(Keys.Space) && oldks.IsKeyUp(Keys.Space))
            //{
            //    onGround = false;
            //    velocity.Y = -400;
            //}
            oldks = ks;

            if (KeyDown(keys[4]) && !jumping)
            {
                jumping = true;
                velocity.Y = -300;
                pos.Y -= 1;
            }
            jumping = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, new Rectangle(0, 0, Game1.TILESIZE, 2 * Game1.TILESIZE), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
            particle.Draw(spriteBatch);
        }

        public void Collision(Rectangle rect)
        {
            //Top
            if (rect.Contains(new Point((int)(pos.X + colP[0].X), (int)(pos.Y + colP[0].Y))) ||
               rect.Contains(new Point((int)(pos.X + colP[1].X), (int)(pos.Y + colP[1].Y))))
            {
                pos.Y = rect.Bottom;
                velocity.Y = 0;
            }
            //Left
            else if (rect.Contains(new Point((int)(pos.X + colP[2].X), (int)(pos.Y + colP[2].Y))) ||
                rect.Contains(new Point((int)(pos.X + colP[4].X), (int)(pos.Y + colP[4].Y))))
            {
                pos.X = rect.Right;
                runningSpeed = 0;
            }
            //Right
            else if (rect.Contains(new Point((int)(pos.X + colP[3].X), (int)(pos.Y + colP[3].Y))) ||
                rect.Contains(new Point((int)(pos.X + colP[5].X), (int)(pos.Y + colP[5].Y))))
            {
                pos.X = rect.Left - BoundsStatic().Width + 1;
                runningSpeed = 0;
            }
            //Bottom
            else if (rect.Contains(new Point((int)(pos.X + colP[6].X), (int)(pos.Y + colP[6].Y))) ||
              rect.Contains(new Point((int)(pos.X + colP[7].X), (int)(pos.Y + colP[7].Y))))
            {
                pos.Y = rect.Top - colP[6].Y + 1;
                velocity.Y = 0;
                jumping = false;
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

        public void PlayerMovement(Keys key)
        {

            if (key == Keys.D)
            {
                if (runningSpeed <= maxSpeed)
                {
                    runningSpeed += acceleration;
                }
                pos.X += runningSpeed;
            }

            else if (key == Keys.A)
            {
                if (runningSpeed >= -maxSpeed)
                {
                    runningSpeed -= acceleration;
                }
                pos.X += runningSpeed;
            }
            else
                runningSpeed = 0;
        }

        //public Rectangle Bounds(Vector2 pos, float RS)
        //{
        //    return new Rectangle((int)(pos.X + RS), (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        //}

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        }
    }
}
