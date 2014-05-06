using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Slope : SolidBlock
    {
        public List<Rectangle> rectList;
        public Slope(Vector2 pos, string texName, int SlopeType)
            : base(pos, texName)
        {
            rectList = new List<Rectangle>();

            if (SlopeType == 1)
            {
                for (int i = 1; i < 24; i++)
                {
                    rectList.Add(new Rectangle((int)pos.X, (int)pos.Y + (i * 2), (i * 2), 2));
                }
            }
            if (SlopeType == 2)
            {
                for (int i = 0; i < 24; i++)
                {
                    rectList.Add(new Rectangle((int)pos.X, (int)pos.Y + (i * 2), 46 - (i * 2), 2));
                }
            }
            if (SlopeType == 3)
            {
                for (int i = 1; i < 24; i++)
                {
                    rectList.Add(new Rectangle((int)pos.X + (i * 2), (int)(pos.Y + 48) - (i * 2), 48 - (i * 2), 2));
                }
            }
            if (SlopeType == 4)
            {
                for (int i = 0; i < 24; i++)
                {
                    rectList.Add(new Rectangle((int)pos.X + (i * 2), (int)pos.Y, 2, (i * 2)));
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            foreach (Rectangle r in rectList)
            {
                //sb.Draw(Game1.testTex, r, Color.Red);
            }
            base.Draw(sb);
        }
    }
}
