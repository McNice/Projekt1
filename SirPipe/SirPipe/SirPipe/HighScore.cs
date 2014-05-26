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
        List<Score> scorelistSP, scorelistMP;
        public readonly string dir = Directory.GetCurrentDirectory()+ "\\HighScore\\";
        int maxScores = 15;

        public HighScore()
        {
            Load();
        }

        void Load()
        {
            List<Score> tempList = new List<Score>();

            StreamReader sr = new StreamReader(dir + "HighScoreSP.txt");
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
            while (tempList.Count > maxScores)
            {
                tempList.RemoveAt(20);
            }

            scorelistSP = tempList;
            tempList = new List<Score>();

            sr = new StreamReader(dir + "HighScoreMP.txt");
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

            scorelistMP = tempList;
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(dir + "HighScoreSP.txt");

            scorelistSP.Sort(delegate(Score p1, Score p2)
            {
                return p2.score.CompareTo(p1.score);
            });

            for (int i = 0; i < scorelistSP.Count; i++)
                if (i <= maxScores)
                    writer.WriteLine("[" + "<" + scorelistSP[i].name + ">" + "<" + scorelistSP[i].score + ">" + "]");

            writer.Close();
            writer = new StreamWriter(dir + "HighScoreMP.txt");

            scorelistMP.Sort(delegate(Score p1, Score p2)
            {
                return p2.score.CompareTo(p1.score);
            });

            for (int i = 0; i < scorelistMP.Count; i++)
                if (i <= maxScores)
                    writer.WriteLine("[" + "<" + scorelistMP[i].name + ">" + "<" + scorelistMP[i].score + ">" + "]");

            writer.Close();
        }

        public void AddScore(Score score, int numer_Of_Players)
        {
            if (numer_Of_Players == 1)
                scorelistSP.Add(score);
            else if (numer_Of_Players == 2)
                scorelistMP.Add(score);
            Save();
            Load();
        }

        public void Draw()
        {
            Renderer.DrawString(Game.StartScreenFont, "SinglePlayer HighScore", new Vector2(400, 50), Color.White);
            for (int i = 0; i < scorelistSP.Count; i++)
            {
                Renderer.DrawString(Game.StartScreenFont, (i + 1) + ": ", new Vector2(350, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
                Renderer.DrawString(Game.StartScreenFont, scorelistSP[i].name + "", new Vector2(425, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
                Renderer.DrawString(Game.StartScreenFont, scorelistSP[i].score + "", new Vector2(650, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
            }

            Renderer.DrawString(Game.StartScreenFont, "MultiPlayer HighScore", new Vector2(1200, 50), Color.White);
            for (int i = 0; i < scorelistMP.Count; i++)
            {
                Renderer.DrawString(Game.StartScreenFont, (i + 1) + ": ", new Vector2(1150, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
                Renderer.DrawString(Game.StartScreenFont, scorelistMP[i].name + "", new Vector2(1225, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
                Renderer.DrawString(Game.StartScreenFont, scorelistMP[i].score + "", new Vector2(1450, 100 + Game.StartScreenFont.LineSpacing * i), Color.White);
            }

        }
    }
}
