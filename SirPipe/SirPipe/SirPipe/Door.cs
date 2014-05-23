using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    class Door : Animated
    {
        public Door(Vector2 pos, string texName, float animationSpeed, int channel, bool start)
            : base(pos, texName, animationSpeed, channel)
        {
            this.start = start;
            if (start == true)
                recX = tex.Width - 100;
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
            return new Rectangle((int)pos.X + (Game.TILESIZE - 14), (int)pos.Y, 18, Game.TILESIZE * 2);
        }

        public override void Switch()
        {
            start = !start;
        }
    }
}
