using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Lava : Animated
    {
        public Lava(Vector2 pos, string texName, float animationSpeed, int? channel, bool start)
            : base(pos, texName, animationSpeed, channel)
        {
             
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Rec(), Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.6f);
        }
    } 
}
