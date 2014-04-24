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
        Vector2 position;
        Vector2 velocity;
        Vector2 gravity;
        float runningSpeed = 10.0f;
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
            PlayerMovement(tile);
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position += (velocity * time) + (gravity * (float)Math.Pow(time, 2) / 2);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void PlayerMovement(SolidBlock tile)
        {
            if (CanMove(tile))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    position.X += runningSpeed;
            }
        }

        bool CanMove(Tile tile)
        {
            if (Bounds(position, runningSpeed).Intersects(tile.Bounds()))
                return true;
            return false;
        }
        public Rectangle Bounds(Vector2 pos, float RS)
        {
            return new Rectangle((int)(pos.X + RS), (int)pos.Y, 50, 50);
        }
    }
}
