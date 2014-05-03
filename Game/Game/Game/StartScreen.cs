using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace Game
{
    public class StartScreen
    {
        Texture2D tex;
        public int i;
        int numberOfButtons = 5;
        public StartScreen()
        {
            tex = Game1.mediaManager.Texture("Inomhusgolv");
        }

        public void Update(GameTime gameTime)
        {
            if (KeyMouseReader.KeyPressed(Keys.S))
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
            else if (KeyMouseReader.KeyPressed(Keys.W))
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

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, new Rectangle(0, 0, Game1.TILESIZE * Game1.TILESX, Game1.TILESIZE * Game1.TILESY), Color.White);
            Button(100, "SinglePlayer", sb, 0);
            Button(200, "MultiPlayer", sb, 1);
            Button(300, "Tutorial", sb, 2);
            Button(400, "Controls", sb, 3);
            Button(500, "Credits", sb, 4);
            Button(600, "HighScores", sb, 5);
        }

        public void Button(float f, string name, SpriteBatch sb, int x)
        {
            Vector2 pos = new Vector2(((Game1.TILESIZE * Game1.TILESX) / 2) - (Game1.StartScreenFont.MeasureString(name).Length() / 2), f);
            if (x != i)
            {
                sb.DrawString(Game1.StartScreenFont, name, pos, Color.Gray);
            }
            else
            {
                sb.DrawString(Game1.StartScreenFont, name, pos, Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 1);
            }
        }
    }
}
