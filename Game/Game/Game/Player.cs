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
        public Vector2 position, prevPosition;
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

        PlayerPoints pPoints;
        public bool onGround;

        public Player(Texture2D texture, Vector2 position, string player)
        {
            this.texture = texture;
            this.position = position;
            this.player = player;
            this.gravity = new Vector2(0, 700);
            particle = new ParticleEngine("Smoketex", position + particleVec);

            pPoints = new PlayerPoints(new Vector2(0, 30), new Vector2(2, 90), new Vector2(48, 30), new Vector2(45, 90), new Vector2(24, 0), new Vector2(24, 94));
        }

        public void Update(GameTime gameTime)
        {
            if (KeyDown(Keys.A))
                PlayerMovement(Keys.A);
            if (KeyDown(Keys.D))
                PlayerMovement(Keys.D);

            time = gameTime.ElapsedGameTime.TotalSeconds;
            if (!onGround)
            {
                velocity += gravity * (float)time;
                position += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
            }
            particle.pos = position + particleVec;
            particle.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && onGround)
            {
                onGround = false;
                velocity.Y = -300;
                position.Y -= 1;
            }
            onGround = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, Game1.TILESIZE, 2 * Game1.TILESIZE), Color.White);
            particle.Draw(spriteBatch);
        }

        public void Collision(Rectangle rect)
        {
            if (onGround && rect.Contains(new Point((int)(position.X + pPoints.groundCheck.X), (int)(position.Y + pPoints.groundCheck.Y))))
                onGround = true;
            if (rect.Contains(new Point((int)(position.X + pPoints.top.X), (int)(position.Y + pPoints.top.Y))))
            {
                position.Y = rect.Bottom;
                velocity.Y = 0;
            }
            if (rect.Contains(new Point((int)(position.X + pPoints.bottom.X), (int)(position.Y + pPoints.bottom.Y))))
            {
                if (velocity.Y > 0)
                {
                    position.Y = rect.Top - pPoints.bottom.Y;
                    velocity.Y = 0;
                    onGround = true;
                }
            }
            if (rect.Contains(new Point((int)(position.X + pPoints.left1.X), (int)(position.Y + pPoints.left1.Y))) ||
                rect.Contains(new Point((int)(position.X + pPoints.left2.X), (int)(position.Y + pPoints.left2.Y))))
            {
                position.X = rect.Right;
                velocity.X = 0;
            }
            if (rect.Contains(new Point((int)(position.X + pPoints.right1.X), (int)(position.Y + pPoints.right1.Y))) ||
                rect.Contains(new Point((int)(position.X + pPoints.right2.X), (int)(position.Y + pPoints.right2.Y))))
            {
                position.X = rect.Left - pPoints.right1.X;
                velocity.X = 0;
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
                position.X += runningSpeed;
            }

            else if (key == Keys.A)
            {
                if (runningSpeed <= maxSpeed)
                {
                    runningSpeed += acceleration;
                }
                position.X -= runningSpeed;
            }
            else { runningSpeed = 0; }

        }

        public Rectangle Bounds(Vector2 pos, float RS)
        {
            return new Rectangle((int)(pos.X + RS), (int)pos.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        }

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)position.X, (int)position.Y, Game1.TILESIZE, 2 * Game1.TILESIZE);
        }
    }
}
