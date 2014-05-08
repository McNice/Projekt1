﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game
{
    public class ButtonLever : Animated
    {
        public bool on;
        public ButtonLever(Vector2 pos, string texName, float animationSpeed, int channel)
            : base(pos, texName, animationSpeed, channel)
        {
            start = false;
        }

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time >= animationSpeed)
            {
                if (recX <= 0 && on)
                    start = true;
                if (recX >= tex.Width - 100 && !on)
                    start = false;
                if (start && recX <= tex.Width - 200)
                    recX += 100;
                if (!start && recX >= 100)
                    recX -= 100;
                time = 0;
            }
            rec = new Rectangle(recX, 0, 100, 100);
        }
    }
}
