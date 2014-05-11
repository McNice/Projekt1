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
        string[,] stringArray = new string[5, 5];
        int i, a, X, Y;
        KeyboardState ks, oks;


        public HighScoreAdd()
        {
            StringArray();
        }

        void StringArray()
        {
            int nextChar = 0;
            string chars = "ABCDEFGHIJKLMNOPRSTUWZXYQ";

            for (int x = 0; x < chars.Length / 5; x++)
                for (int y = 0; y < chars.Length / 5; y++)
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
                X += 4;
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
                for (int x = 0; x < 5; x++)
                    Char(sb, stringArray[x, y], x, y);

            sb.DrawString(Game1.StartScreenFont, PlayerName(), new Vector2(300), Color.White);
        }

        public string PlayerName()
        {
            string pn = string.Empty;
            foreach (string n in name)
            {
                if (n != null)
                    pn += n;
            }
            return pn;
        }

        void Char(SpriteBatch sb, string i, int x, int y)
        {
            float scale = 3;
            Color color = Color.Gray;
            if (x == X % 5 && y == Y % 5)
            {
                scale = 4.5f;
                color = Color.White;
            }
            Vector2 pos = new Vector2(400 + Game1.StartScreenFont.LineSpacing * 5 * x, 250 + Game1.StartScreenFont.LineSpacing * 3 * y);
            sb.DrawString(Game1.StartScreenFont, i, pos, color, 0, new Vector2(7, Game1.StartScreenFont.LineSpacing / 2), scale, SpriteEffects.None, 1);

        }

        public void AddChar()
        {
            if (a <= name.Length - 1 && Key(Keys.Enter))
            {
                name[a] = stringArray[X % 5, Y % 5];
                a++;

            }
            else if (a > 0 && a <= name.Length && Key(Keys.Back))
            {
                name[a - 1] = string.Empty;
                a--;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                name[a] = Keys.A.ToString();
                a++;
            }
        }
    }
}
