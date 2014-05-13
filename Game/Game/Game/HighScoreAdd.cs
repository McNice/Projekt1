using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class HighScoreAdd
    {
        string[] name = new string[10];
        string[,] stringArray = new string[7, 5];
        int a, X, Y;
        public int points;
        KeyboardState ks, oks;


        public HighScoreAdd()
        {
            StringArray();
        }

        void StringArray()
        {
            int nextChar = 0;
            string chars = "ABCDE05FGHIJ16KLMNO27PQRST38UWZXY49";

            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 7; y++)
                {
                    stringArray[y, x] = Convert.ToString(chars[nextChar]);
                    nextChar++;
                }
        }

        public void Update()
        {
            ks = Keyboard.GetState();
            if (Key(Keys.D))
                X++;
            else if (Key(Keys.A))
                X += 6;
            else if (Key(Keys.W))
                Y += 4;
            else if (Key(Keys.S))
                Y++;
            AddChar();
            oks = ks;
        }

        bool Key(Keys key)
        {
            if (ks.IsKeyDown(key) && oks.IsKeyUp(key))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            for (int y = 0; y < 5; y++)
                for (int x = 0; x < 7; x++)
                    Char(sb, stringArray[x, y], x, y);
            string temp = PlayerName();
            sb.DrawString(Game1.StartScreenFont, temp, new Vector2((float)(1920 / 2), 150)
                , Color.White, 0, new Vector2(Game1.StartScreenFont.MeasureString(temp).Length() / 2, Game1.StartScreenFont.LineSpacing/2), 2, SpriteEffects.None, 1);
        }

        public Score AddScore(string playerName, int score)
        {
            return new Score(playerName, score);
        }

        public string PlayerName()
        {
            string pn = string.Empty;
            foreach (string n in name)
            {
                if (n != null || n != string.Empty)
                    pn += n;
            }
            return pn;
        }

        void Char(SpriteBatch sb, string i, int x, int y)
        {
            float scale = 3;
            Color color = Color.Gray;
            if (x == X % 7 && y == Y % 5)
            {
                scale = 4.5f;
                color = Color.White;
            }
            Vector2 pos = new Vector2(300 + Game1.StartScreenFont.LineSpacing * 5 * x, 350 + Game1.StartScreenFont.LineSpacing * 3 * y);
            sb.DrawString(Game1.StartScreenFont, i, pos, color, 0, new Vector2(7, Game1.StartScreenFont.LineSpacing / 2), scale, SpriteEffects.None, 1);

        }
        

        public void AddChar()
        {
            if (a <= name.Length - 1 && Key(Keys.Enter))
            {
                name[a] = stringArray[X % 7, Y % 5];
                a++;

            }
            else if (a > 0 && a <= name.Length && Key(Keys.Back))
            {
                name[a - 1] = string.Empty;
                a--;
            }

        }
    }
}
