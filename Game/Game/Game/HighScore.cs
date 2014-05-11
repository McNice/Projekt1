using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace Game
{
    public class HighScore
    {
        List<Score> scorelist;
        public readonly string dir = "../../../../../../HighScore/";
        int maxScores = 15;
        public HighScore()
        {
            scorelist = Load();
            RandomScore();
        }
        List<Score> Load()
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

            return tempList;
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

        public void AddScore(string name, int score)
        {
            scorelist.Add(new Score(name, score));
            Save();
        }

        void RandomScore()
        {
            string randomString = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sendString = "";
            Random rand = new Random();
            int i = rand.Next(1,10);
            while (sendString.Length < i)
            {
                sendString += randomString[rand.Next(1,randomString.Length)];
            }
            AddScore(sendString, rand.Next(9999999));
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < scorelist.Count; i++)
            {
                sb.DrawString(Game1.StartScreenFont, scorelist[i].name + "", new Vector2(300, 50 + Game1.StartScreenFont.LineSpacing * i), Color.White);
                sb.DrawString(Game1.StartScreenFont, scorelist[i].score + "", new Vector2(500, 50 + Game1.StartScreenFont.LineSpacing * i), Color.White);
            }
        }
    }
}
