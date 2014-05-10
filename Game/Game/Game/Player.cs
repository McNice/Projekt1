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
        Texture2D tex;
        public Vector2 pos, prevpos;
        public Vector2 velocity;
        Vector2 gravity;
        public float
            runningSpeed = 0,
            acceleration = 0.08f,
            deceleration = 0.1f,
            maxSpeed = 3.5f,
            animationSpeed = 50,
            animationTime = 0;
        int recX = 0;
        bool running;
        string player;
        double time;
        ParticleEngine particle;
        Vector2 particleVec = new Vector2(5, 40);
        KeyboardState ks, oldks;
        SpriteEffects spriteEffect;

        Keys[] keys;


        Vector2[] colP = { new Vector2(10, 0), new Vector2(30, 0), 
                             new Vector2(0, 10), new Vector2(48, 10), 
                             new Vector2(0, 86), new Vector2(48, 86),
                         new Vector2(18, 96), new Vector2(30, 96)};

        public bool jumping, onLadder;

        public Player(string texName, Vector2 pos, string player, Keys[] keys)
        {
            this.tex = Game1.mediaManager.Texture(texName);
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
            {
                PlayerMovement(keys[0]);
                Animation(gameTime);
            }
            else if (KeyDown(keys[1]))
            {
                PlayerMovement(keys[1]);
                Animation(gameTime);
            }
            else
            {
                if (runningSpeed >= 0.1f)
                {
                    runningSpeed -= deceleration;
                }
                else if (runningSpeed <= -0.1f)
                {
                    runningSpeed += deceleration;
                }
                else if (runningSpeed >= -0.1f && runningSpeed <= 0.1f)
                    runningSpeed = 0;
                running = false;
            }

            time = gameTime.ElapsedGameTime.TotalSeconds;
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

            oldks = ks;

            if (KeyDown(keys[4]) && !jumping)
            {
                jumping = true;
                velocity.Y = -300;
                pos.Y -= 1;
            }
            jumping = true;
            pos.X += runningSpeed;
            Animation(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, SrcRec(), Color.White, 0, Vector2.Zero, .5714f, spriteEffect, 0.5f);
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

            if (key == Keys.D || key == Keys.Right)
            {
                if (runningSpeed <= maxSpeed)
                {
                    runningSpeed += acceleration;
                }
                particleVec = new Vector2(42, 40);
                running = true;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }

            else if (key == Keys.A || key == Keys.Left)
            {
                if (runningSpeed >= -maxSpeed)
                {
                    runningSpeed -= acceleration;
                }
                particleVec = new Vector2(5, 40);
                running = true;
                spriteEffect = SpriteEffects.None;
            }
            //else
            //    runningSpeed = 0;
        }

        //public Rectangle Bounds(Vector2 pos, float RS)
        //{
        //    return new Rectangle((int)(pos.X + RS), (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        //}

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        }

        public Rectangle SrcRec()
        {
            return new Rectangle(recX, 0, (tex.Width / 19), 200);
        }

        public void Animation(GameTime gameTime)
        {
            animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (animationTime >= animationSpeed)
            {
                if (running)
                    recX += (tex.Width / 19);
                else
                    recX = 0;
                if (recX >= tex.Width - 100)
                    recX = 0;

                animationTime -= animationSpeed;
            }
            //SrcRec();
        }
    }
}
