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
    public class Player
    {
        Texture2D tex;
        public Vector2 pos, prevpos;
        public Vector2 velocity;
        Vector2 gravity;
        public float
            acceleration = 0.08f,
            deceleration = 0.2f,
            maxSpeed = 3.0f,
            animationSpeed = 30,
            animationTime = 0,
            ladderTime,
            ladderDelay = 350;
        int recX = 0;
        int recY = 0;
        bool running;
        string player;
        double time;
        ParticleEngine particle;
        Vector2 particleVec = new Vector2(2, 44);
        KeyboardState ks, oldks;
        SpriteEffects spriteEffect;

        public PlayerInput[] keys;


        Vector2[] colP = { new Vector2(10, 0), new Vector2(30, 0), 
                             new Vector2(0, 26), new Vector2(48, 26), 
                             new Vector2(0, 76), new Vector2(48, 76),
                         new Vector2(18, 96), new Vector2(30, 96)};

        public bool jumping, onLadder, startJump, climbing = false;

        bool up;
        public int ladderCount = 0;

        public Player(string texName, Vector2 pos, string player, PlayerInput[] keys)
        {
            this.tex = Game.mediaManager.Texture(texName);
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

            pos.X += velocity.X;
            particle.pos = pos + particleVec;
            particle.Update(gameTime);

            Animation(gameTime);

            oldks = ks;

            System.Diagnostics.Debug.WriteIf(!jumping, "onground\n");
        }

        void Movement(GameTime gameTime)
        {
            if (InputHandler.IsKeyDown(keys[0], true))
            {
                pos.X -= maxSpeed;
                //if (velocity.X >= -maxSpeed)
                //{
                //    if (velocity.X > 0)
                //        velocity.X -= deceleration;
                //    velocity.X -= acceleration;
                //}
                particleVec = new Vector2(2, 44);
                running = true;
                spriteEffect = SpriteEffects.None;
            }
            else if (InputHandler.IsKeyDown(keys[1], true))
            {
                pos.X += maxSpeed;
                //if (velocity.X <= maxSpeed)
                //{
                //    if (velocity.X < 0)
                //        velocity.X += deceleration;
                //    velocity.X += acceleration;
                //}
                particleVec = new Vector2(50, 44);
                running = true;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                //if (velocity.X >= 0.1f)
                //{
                //    velocity.X -= deceleration;
                //}
                //else if (velocity.X <= -0.1f)
                //{
                //    velocity.X += deceleration;
                //}
                //else if (velocity.X >= -0.1f && velocity.X <= 0.1f)
                //    velocity.X = 0;
                running = false;
            }
        }

        void OnLadder(GameTime gameTime)
        {
            time = gameTime.ElapsedGameTime.TotalSeconds;
            if (onLadder)
            {
                climbing = false;
                if (InputHandler.IsKeyDown(keys[2], true))
                {
                    velocity.Y = -200;
                    pos.Y -= 100 * (float)time;
                    climbing = true;
                }
                else if (InputHandler.IsKeyDown(keys[3], true))
                {
                    pos.Y += 100 * (float)time;
                    climbing = true;
                }
                else { velocity.Y = 0; }
            }
            else
            {
                velocity += gravity * (float)time;
                pos += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
            }
        }

        void Jump()
        {
            if (InputHandler.IsKeyDown(keys[4], true) && !jumping && !startJump)
            {
                Game.jump.Play();
                startJump = true;
                recX = 0;
                recY = tex.Height / 3;
            }
        }

        public void Draw()
        {
            Renderer.Draw(tex, new Vector2((int)pos.X, (int)pos.Y), SrcRec(), Color.White, 0, Vector2.Zero, 0.52f, spriteEffect, 0.5f);
            particle.Draw();
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

            }
            //Right
            else if (rect.Contains(new Point((int)(pos.X + colP[3].X), (int)(pos.Y + colP[3].Y))) ||
                rect.Contains(new Point((int)(pos.X + colP[5].X), (int)(pos.Y + colP[5].Y))))
            {
                pos.X = rect.Left - BoundsStatic().Width + 1;

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

        //bool KeyDown(Keys key)
        //{
        //    if (Keyboard.GetState().IsKeyDown(key))
        //        return true;
        //    return false;
        //}

        //bool KeyUp(Keys key)
        //{
        //    if (Keyboard.GetState().IsKeyUp(key))
        //        return true;
        //    return false;
        //}

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, Game.TILESIZE, 2 * Game.TILESIZE);
        }

        public Rectangle SrcRec()
        {
            return new Rectangle(recX, recY, (tex.Width / 20) - 1, 200);
        }

        public void Animation(GameTime gameTime)
        {
            if (!jumping)
            {
                ladderCount = 0;
                if (startJump)
                {
                    animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (animationTime >= animationSpeed - 30)
                    {
                        recX += recX = (tex.Width / 20);
                        animationTime -= animationSpeed - 30;
                        if (recX >= (tex.Width / 20) * 14)
                        {
                            startJump = false;
                            jumping = true;
                            velocity.Y = -330;
                            pos.Y -= 1;
                        }
                    }
                }
                else if (running)
                {
                    animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
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
                ladderCount = 40;
                startJump = false;
                animationTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                spriteEffect = SpriteEffects.None;
                particleVec = new Vector2(24, 50);
                recY = 2 * (tex.Height / 3);
                if (climbing)
                {
                    ClimbSound(gameTime);
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
                    if (recX > 11 * (tex.Width / 20))
                        recX = 11 * (tex.Width / 20);
                    animationTime = 0;
                }
            }
            else if (jumping)
            {
                if (ladderCount > 0)
                    ladderCount--;
                else
                {
                    startJump = false;
                    recY = (tex.Height / 3);
                    recX = (tex.Width / 20) * 14;
                }
            }
        }

        public void OnLadder()
        {
            velocity.Y = 0;
            onLadder = true;
        }

        public void ClimbSound(GameTime gt)
        {
            ladderTime += (float)gt.ElapsedGameTime.TotalMilliseconds;
            if (ladderTime >= ladderDelay)
            {
                Game.ladder.Play();
                ladderTime -= ladderDelay;
            }
        }
    }
}
