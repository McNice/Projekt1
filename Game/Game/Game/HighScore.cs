using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    public class HighScore
    {
        List<Score> scorelist;
        public HighScore()
        {
            scorelist = Load();
        }
        public List<Score> Load()
        {
            List<Score> temp = new List<Score>();
            temp.Add(new Score("asdsadsad",12093810));
            temp.Add(new Score("fasfa", 45646));
            temp.Add(new Score("sdfsfsf", 4564564));
            temp.Add(new Score("sdfdsfsf", 4645645));
            return temp;
        }
        public void Save()
        {

        }
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < scorelist.Count; i++)
            {
                sb.DrawString(Game1.StartScreenFont, scorelist[i].name +"", new Vector2(300, 50 + Game1.StartScreenFont.LineSpacing * i), Color.White);
                sb.DrawString(Game1.StartScreenFont, scorelist[i].score + "", new Vector2(500, 50 + Game1.StartScreenFont.LineSpacing * i), Color.White);                
            }
        }
    }
}
