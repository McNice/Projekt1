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
        public float runningSpeed = 5.0f;
        public bool isOnGround = false;
        string player;
        double time;


        public Player(Texture2D texture, Vector2 position, string player)
        {
            this.texture = texture;
            this.position = position;
            this.player = player;
            this.gravity = new Vector2(0, 700);
        }

        public void Update(GameTime gameTime)
        {
            time = gameTime.ElapsedGameTime.TotalSeconds;
            prevPosition = position;
            position += (velocity * (float)time) + gravity * (float)Math.Pow(time, 2) * 0.5f;
            velocity += gravity * (float)time;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                velocity.Y = -400;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, 50, 100), Color.White);
        }

        public void PlayerMovement(Keys key)
        {
            if (key == Keys.D)
                position.X += runningSpeed;
            if (key == Keys.A)
                position.X -= runningSpeed;
        }

        public Rectangle Bounds(Vector2 pos, float RS)
        {
            return new Rectangle((int)(pos.X + RS), (int)pos.Y, 50, 100);
        }

        public Rectangle BoundsStatic()
        {
            return new Rectangle((int)position.X, (int)position.Y, 50, 100);
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
