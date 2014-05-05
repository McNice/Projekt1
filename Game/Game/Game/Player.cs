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
            maxSpeed = 2.0f,
            breakSpeed = 0.5f;

        string player;
        double time;
        Manager m = new Manager();
        ParticleEngine particle;
        Vector2 particleVec = new Vector2(5, 40);

        public Player(Texture2D texture, Vector2 position, string player)
        {
            this.texture = texture;
            this.position = position;
            this.player = player;
            this.gravity = new Vector2(0, 700);
            particle = new ParticleEngine("Smoketex", position + particleVec);
        }

        public void Update(GameTime gameTime)
        {

            time = gameTime.ElapsedGameTime.TotalSeconds;
            prevPosition = position;
            velocity += gravity * (float)time;
            position += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
            particle.pos = position + particleVec;
            particle.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                m.isOnGround = false;
                velocity.Y = -300;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, Game1.TILESIZE, 2 * Game1.TILESIZE), Color.White);
            particle.Draw(spriteBatch);
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

        public FloatRect Rect(int a)
        {
            if (a == 0)
                return new FloatRect(position, new Vector2(texture.Width, texture.Height));
            if (a == 1)
                return new FloatRect(prevPosition, new Vector2(texture.Width, texture.Height));
            return null;
        }
    }
}
