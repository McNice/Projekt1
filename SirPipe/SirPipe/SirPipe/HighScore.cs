using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MAHArcadeSystem;
using System.IO;

namespace SirPipe
{
    public class HighScore
    {
        List<Score> scorelist;
        public readonly string dir = "../../../../../../HighScore/";
        int maxScores = 15;

        public HighScore()
        {
            Load();
        }

        void Load()
        {
            List<Score> tempList = new List<Score>();

            StreamReader sr = new StreamReader(dir + "HighScore.txt");
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                if (temp.Contains('[') || temp.Contains(']'))
                {
                    string[] stringArray = temp.Split(new char[] { '[', ']', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string tempName = stringArray[0];
                    int tempScore = int.Parse(stringArray[1]);
                    tempList.Add(new Score(tempName, tempScore));
                }
            }

            sr.Close();

            tempList.Sort(delegate(Score p1, Score p2)
            {
                return p2.score.CompareTo(p1.score);
            });

            scorelist = tempList;
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(dir + "HighScore.txt");

            scorelist.Sort(delegate(Score p1, Score p2)
            {
                return p2.score.CompareTo(p1.score);
            });

            for (int i = 0; i < scorelist.Count; i++)
                if (i <= maxScores)
                    writer.WriteLine("[" + "<" + scorelist[i].name + ">" + "<" + scorelist[i].score + ">" + "]");

            writer.Close();
        }

        public void AddScore(Score score)
        {
            scorelist.Add(score);
            Save();
            Load();
        }
        

        public void Draw()
        {
            for (int i = 0; i < scorelist.Count; i++)
            {
                Renderer.DrawString(Game.StartScreenFont, scorelist[i].name + "", new Vector2(300, 50 + Game.StartScreenFont.LineSpacing * i), Color.White);
                Renderer.DrawString(Game.StartScreenFont, scorelist[i].score + "", new Vector2(500, 50 + Game.StartScreenFont.LineSpacing * i), Color.White);
            }
        }
    }
}
