using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game {
    public class Player {
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        Vector2 gravity;
        string player;
        float time;
        enum Movement {
            Right,
            Left,
            Up,
            Down,
            UpRight,
            UpLeft,
            DownRight,
            DownLeft,
            Idle,
            Jump
        }
        Movement movement = new Movement();

        public Player(Texture2D texture, Vector2 position, string player) {
            this.texture = texture;
            this.position = position;
            this.player = player;
            this.gravity = new Vector2(0, 0.0005f);
        }

        public void Update(GameTime gameTime) {
            PlayerMovement();
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            position += (velocity * time) + (gravity * (float)Math.Pow(time, 2) / 2);
            velocity += gravity * time;
            switch (movement) {
                case Movement.Right:
                    position.X++;
                    break;
                case Movement.Left:
                    position.X--;
                    break;
                case Movement.Up:
                    position.Y--;
                    break;
                case Movement.Down:
                    position.Y++;
                    break;
                case Movement.Idle:
                    break;
                case Movement.Jump:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void PlayerMovement() {
            if (player == "Player1") {
                if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                    movement = Movement.Up;
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        movement = Movement.UpRight;
                    else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        movement = Movement.UpLeft;
                } else if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
                    movement = Movement.Down;
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        movement = Movement.DownRight;
                    else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        movement = Movement.DownLeft;
                } else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    movement = Movement.Right;
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    movement = Movement.Left;
                else
                    movement = Movement.Idle;
            }

            if (player == "Player2") {
                if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                    movement = Movement.Up;
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        movement = Movement.UpRight;
                    else if (Keyboard.GetState().IsKeyDown(Keys.A))
                        movement = Movement.UpLeft;
                } else if (Keyboard.GetState().IsKeyDown(Keys.S)) {
                    movement = Movement.Down;
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                        movement = Movement.DownRight;
                    else if (Keyboard.GetState().IsKeyDown(Keys.A))
                        movement = Movement.DownLeft;
                } else if (Keyboard.GetState().IsKeyDown(Keys.D))
                    movement = Movement.Right;
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                    movement = Movement.Left;
                else
                    movement = Movement.Idle;
            }
        }
    }
}
