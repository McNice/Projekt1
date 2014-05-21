using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Timer
    {
        int minDec = 1, min = 0, secDec = 0, sec = 0;
        double timer = 1000;
        SpriteFont font;
        Vector2 pos = new Vector2(50, 990);
        public Timer(SpriteFont font)
        {
            this.font = font;
        }
        public void Update(GameTime gt)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            if (timer <= 0)
            {
                timer += 1000;
                sec--;
            }
            if (sec < 0)
            {
                sec += 10;
                secDec--;
            }
            if (secDec < 0)
            {
                secDec += 6;
                min--;
            }
            if (min < 0)
            {
                min += 10;
                if (minDec != 0)
                    minDec--;
            }

        }

        public void Draw()
        {
            Renderer.DrawString(font, " " + minDec + "" + min + ":" + secDec + "" + sec, pos, Color.Black);
        }
    }
}
