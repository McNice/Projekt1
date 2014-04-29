using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class StartScreen
    {
        Texture2D tex;
        KeyboardState ks;
        KeyboardState oldks;

        public StartScreen()
        {
            tex = Game1.textureManager.Texture("Inomhusgolv");
        }

        public void Update(GameTime gameTime)
        {
            if (ks.IsKeyDown(Keys.S) && oldks.IsKeyUp(Keys.S))
            {
                
            }
            oldks = ks;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, new Rectangle(0, 0, Game1.TILESIZE * Game1.TILESX, Game1.TILESIZE * Game1.TILESY), Color.White);
        }

        public void Button(Vector2 pos, string name, SpriteBatch sb)
        {
            //sb.DrawString(Game1.StartScreenFont,
        }
    }
}
