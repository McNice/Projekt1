using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using MAHArcadeSystem;

namespace SirPipe
{
    public class StartScreen
    {
        Texture2D tex;
        public int i;
        int numberOfButtons = 5;
        public StartScreen()
        {
            tex = Game.mediaManager.Texture("Black Tile");
        }

        public void Update(GameTime gameTime)
        {
            if (InputHandler.GetButtonState(PlayerInput.PlayerOneDown) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoDown) == InputState.Pressed)
            {
                if (i < numberOfButtons)
                {
                    i++;
                }
                else if (i == numberOfButtons)
                {
                    i = 0;
                }
            }
            else if (InputHandler.GetButtonState(PlayerInput.PlayerOneUp) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoUp) == InputState.Pressed)
            {
                if (i > 0)
                {
                    i--;
                }
                else if (i == 0)
                {
                    i = numberOfButtons;
                }
            }
        }

        public void Draw()
        {
            Button(200, "SinglePlayer", 0);
            Button(300, "MultiPlayer", 1);
            Button(400, "Tutorial", 2);
            Button(500, "Controls", 3);
            Button(600, "Credits", 4);
            Button(700, "HighScores", 5);
        }

        public void Button(float f, string name, int x)
        {
            float scale = 1;
            Color color = Color.Gray;
            if (x == i)
            {
                scale = 1.5f;
                color = Color.White;
            }
            Vector2 pos = new Vector2(((Game.TILESIZE * Game.TILESX) / 2) - ((Game.StartScreenFont.MeasureString(name).Length() * scale) / 2), f);
            Renderer.DrawString(Game.StartScreenFont, name, pos, color, 0, Vector2.Zero, scale, SpriteEffects.None, 1);

        }
    }
}
