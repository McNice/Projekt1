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
        protected int recX = 0;
        protected float animationSpeed;
        protected float time = 0;
        public int? channel;
        public bool start;

        public Animated(Vector2 pos, string texName, float animationSpeed, int? channel)
            : base(pos, texName)
        {
            this.pos = pos;
            this.tex = Game1.mediaManager.Texture(texName);
            this.animationSpeed = animationSpeed;
            this.channel = channel;
        }
        public virtual void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time >= animationSpeed)
            {
                if (recX <= 0 && !start)
                    start = true;
                if (recX >= tex.Width - 100 && start)
                    start = false;
                if (start)
                    recX += 100;
                if (!start)
                    recX -= 100;
                time = 0;
            }
            Rec();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Rec(), Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.4f);
        }

        public virtual Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 100);
        }

        public virtual void Switch() { }
    }
}
