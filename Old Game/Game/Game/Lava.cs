using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Lava : Tile
    {
        int recX = 0;
        Texture2D tex2;
        bool fade = false;
        float alpha = 0.0f;
        float animationSpeed;
        float time;
        public Lava(Vector2 pos, string texName, float animationSpeed)
            : base(pos, texName)
        {
            this.tex2 = Game1.mediaManager.Texture("Lava overlay");
            this.animationSpeed = animationSpeed;
        }
        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time >= animationSpeed)
            {
                time = 0;
                recX++;
            }
                if (recX >= tex.Width - 100)
                    recX = 0;
                if (fade)
                    alpha -= 0.005f;
                else
                    alpha += 0.005f;
                if (alpha >= 0.3f)
                    fade = true;
                else if (alpha <= 0)
                    fade = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Rec(), Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.61f);
            spriteBatch.Draw(tex2, pos, Rec(), Color.White * alpha, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.62f);
        }
        public Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 100);
        }
    }
}
