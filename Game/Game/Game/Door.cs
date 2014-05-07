using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class Door : Animated
    {
        public Door(Vector2 pos, string texName, float animationSpeed)
            : base(pos, texName, animationSpeed)
        {
            start = true;
        }
        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time >= animationSpeed)
            {
                if (start && recX <= tex.Width - 200)
                    recX += 100;
                if (!start && recX >= 100)
                    recX -= 100;
                time = 0;
            }
            Rec();
        }

        public override Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 200);
        }

        public override Rectangle Bounds()
        {
            return new Rectangle((int)pos.X + (Game1.TILESIZE - 10), (int)pos.Y, 10, Game1.TILESIZE * 2);
        }
    }
}
