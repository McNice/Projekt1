using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Timer
    {
        int minDec = 1 , min = 0, secDec = 0, sec = 0;
        double timer = 1000;
        SpriteFont font;
        public Timer(SpriteFont font)
        {
            this.font = font;
        }
        public void Update(GameTime gt)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            if(timer <= 0)
            {
                timer += 1000;
                sec--;
            }
            if(sec < 0)
            {
                sec += 10;
                secDec--;
            }
            if (secDec < 0)
            {
                secDec += 6;
                min--;
            }
            if(min < 0)
            {
                min += 10;
                if(minDec != 0)
                minDec --;
            }
            
        }
        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, " "+minDec+"" + min + ":" + secDec +""+ sec, new Vector2(1000, 500), Color.Red);
        }
    }
}
