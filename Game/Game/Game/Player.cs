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
        public Vector2 position;
        Vector2 velocity;
        Vector2 gravity;
        public float runningSpeed = 1.0f;
        public bool isOnGround = false;
        string player;
        float time;


        public Player(Texture2D texture, Vector2 position, string player)
        {
            this.texture = texture;
            this.position = position;
            this.player = player;
            this.gravity = new Vector2(0, 0.0005f);
        }

        public void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position += (velocity * time) + (gravity * (float)Math.Pow(time, 2) / 2);
            //velocity += gravity*time;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position,new Rectangle(0,0,50,50), Color.White);
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
            return new Rectangle((int)(pos.X + RS), (int)pos.Y, 50, 50);
        }
    }
}
