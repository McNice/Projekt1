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
            deceleration = 0.2f,
            maxSpeed = 3.5f,
            animationSpeed = 50,
            animationTime = 0;
        int recX = 0;
        int recY = 0;
        bool running;
        string player;
        double time;
        ParticleEngine particle;
        Vector2 particleVec = new Vector2(2, 44);
        KeyboardState ks, oldks;
        SpriteEffects spriteEffect;

        public Keys[] keys;


        Vector2[] colP = { new Vector2(10, 0), new Vector2(30, 0), 
                             new Vector2(0, 10), new Vector2(48, 10), 
                             new Vector2(0, 76), new Vector2(48, 76),
                         new Vector2(18, 96), new Vector2(30, 96)};

        public bool jumping, onLadder, startJump, climbing = false;

        bool up;

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

            Movement(gameTime);

            OnLadder(gameTime);

            Jump();

            Animation(gameTime);

            pos.X += runningSpeed;
            particle.pos = pos + particleVec;
            particle.Update(gameTime);



            oldks = ks;

            System.Diagnostics.Debug.WriteIf(!jumping, "onground\n");
        }

        void Movement(GameTime gameTime)
        {
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
        }

        void OnLadder(GameTime gameTime)
        {
            time = gameTime.ElapsedGameTime.TotalSeconds;
            if (onLadder)
            {
                climbing = false;
                if (KeyDown(keys[2]))
                {
                    pos.Y -= 100 * (float)time;
                    climbing = true;
                }
                if (KeyDown(keys[3]))
                {
                    pos.Y += 100 * (float)time;
                    climbing = true;
                }

            }
            else
            {
                velocity += gravity * (float)time;
                pos += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
            }
        }

        void Jump()
        {
            if (KeyDown(keys[4]) && !jumping && !startJump)
            {
                startJump = true;
                recX = 0;
                recY = tex.Height / 3;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, new Vector2((int)pos.X, (int)pos.Y), SrcRec(), Color.White, 0, Vector2.Zero, 0.52f, spriteEffect, 0.5f);
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
                    if (runningSpeed < 0)
                        runningSpeed += deceleration;
                    runningSpeed += acceleration;
                }
                particleVec = new Vector2(50, 44);
                running = true;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }

            else if (key == Keys.A || key == Keys.Left)
            {
                if (runningSpeed >= -maxSpeed)
                {
                    if (runningSpeed > 0)
                        runningSpeed -= deceleration;
                    runningSpeed -= acceleration;
                }
                particleVec = new Vector2(2, 44);
                running = true;
                spriteEffect = SpriteEffects.None;
            }
        }

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        }

        public Rectangle SrcRec()
        {
            return new Rectangle(recX, recY, (tex.Width / 20) - 1, 200);
        }

        public void Animation(GameTime gameTime)
        {
            animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (!jumping)
            {
                if (startJump)
                {
                    if (animationTime >= animationSpeed - 30)
                    {
                        recX += recX = (tex.Width / 20);
                        animationTime -= animationSpeed - 30;
                        if (recX >= (tex.Width / 20) * 14)
                        {
                            startJump = false;
                            jumping = true;
                            velocity.Y = -300;
                            pos.Y -= 1;
                        }
                    }
                }
                else if (running)
                {
                    recY = 0;
                    if (animationTime >= animationSpeed)
                    {
                        recX += (tex.Width / 20);

                        if (recX >= tex.Width - 100)
                            recX = 0;
                        animationTime -= animationSpeed;
                    }
                }
                else
                {
                    recX = 800;
                    recY = 0;
                    animationTime = 0;
                }
            }
            else if (onLadder)
            {
                spriteEffect = SpriteEffects.None;
                particleVec = new Vector2(24, 50);
                recY = 2 * (tex.Height / 3);
                if (climbing)
                {
                    if (animationTime >= animationSpeed)
                    {
                        if (up)
                            recX += (tex.Width / 20);
                        else
                            recX -= (tex.Width / 20);

                        if (recX <= 0)
                        {
                            recX = 0;
                            up = true;
                        }
                        if (recX > 11 * (tex.Width / 20))
                        {
                            recX = 11 * (tex.Width / 20);
                            up = false;
                        }
                        animationTime -= animationSpeed;
                    }
                }
                else
                {
                    animationTime = 0;
                    if (recX > 11 * (tex.Width / 20))
                        recX = 11 * (tex.Width / 20);
                }

            }
            else if (jumping)
            {
                startJump = false;
                recY = (tex.Height / 3);
                recX = (tex.Width / 20) * 14;
                animationTime = 0;
            }
        }

        public void OnLadder()
        {
            velocity.Y = 0;
            onLadder = true;
        }
    }
}
