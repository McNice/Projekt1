using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Animated : Tile
    {
        float time = 0;
        float animationSpeed;
        int rectangleX = 0;
        Rectangle rec;
        public Animated(Vector2 pos, string texName, float animationSpeed)
            : base(pos, texName)
        {
            tex = Game1.mediaManager.Texture(texName);
            this.animationSpeed = animationSpeed;
        }
        public void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time >= animationSpeed)
                rectangleX += 100;
            
            if (rectangleX >= tex.Bounds.Width)
                rectangleX = 0;

            rec = new Rectangle(rectangleX, 0, 100, 100);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, rec, Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 1);
        }
    }
}
