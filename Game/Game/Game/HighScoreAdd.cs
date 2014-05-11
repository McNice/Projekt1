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
        string chars;
        string playerName = string.Empty;
        string[] name;
        int[,] intArray;
        int i, a;
        KeyboardState ks, oks;

        public HighScoreAdd()
        {
            chars = "ABCDEFGHIJKLMNOPRSTUWZXYQ";
            intArray = new int[chars.Length / 5, chars.Length / 5];
            name = new string[10];
            IntArray();
        }

        void IntArray()
        {

            for (int x = 0; x < chars.Length / 5; x++)
                for (int y = 0; y < chars.Length / 5; y++)
                {
                    intArray[x, y] = i;
                    i++;
                }
            i = 50000;


        }

        void Update()
        {
            ks = Keyboard.GetState();
            if (Key(Keys.D))
                i++;
            else if (Key(Keys.A))
                i--;
            else if (Key(Keys.W))
                i -= 5;
            else if (Key(Keys.S))
                i += 5;
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
            Update();
            for (int y = 0; y < 5; y++)
                for (int x = 0; x < 5; x++)
                    Button(sb, intArray[y, x], x, y);

            sb.DrawString(Game1.StartScreenFont, PlayerName(), new Vector2(300), Color.White);

        }

        string PlayerName()
        {
            string pn = string.Empty;
            foreach (string n in name)
            {
                if (n != null)
                    pn += n;
            }           
            
            return pn;
        }

        public void Button(SpriteBatch sb, int z, int x, int y)
        {
            float scale = 2;
            Color color = Color.Gray;
            if (z == i % 25)
            {
                scale = 3f;
                color = Color.White;
            }
            Vector2 pos = new Vector2(400 + Game1.StartScreenFont.LineSpacing * 2 * x, 400 + Game1.StartScreenFont.LineSpacing * 2 * y);
            sb.DrawString(Game1.StartScreenFont, chars[z] + "", pos, color, 0, new Vector2(7, Game1.StartScreenFont.LineSpacing / 2), scale, SpriteEffects.None, 1);

        }

        public void AddChar()
        {
            if (a <= name.Length - 1 && Key(Keys.Enter))
            {
                name[a] = chars[i % 25].ToString();
                a++;

            }
            else if (a > 0 && a <= name.Length && Key(Keys.Back))
            {
                name[a-1] = string.Empty;
                a--;
            }
        }
    }
}
