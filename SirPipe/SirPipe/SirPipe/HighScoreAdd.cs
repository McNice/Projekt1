using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MAHArcadeSystem;

namespace SirPipe
{
    public class HighScoreAdd
    {
        string[] name = new string[10];
        string[,] stringArray = new string[7, 6];
        public bool done;
        int a, X, Y;
        public int points;
        PlayerInput[] p1Keys;
        Texture2D tex;


        public HighScoreAdd(PlayerInput[] p1Keys)
        {
            StringArray();
            this.p1Keys = p1Keys;
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
            stringArray[3, 5] = "Done";
        }

        public void Update()
        {
            if (InputHandler.GetButtonState(p1Keys[1]) == InputState.Pressed)
                X++;
            else if (InputHandler.GetButtonState(p1Keys[0]) == InputState.Pressed)
                X += 6;
            else if (InputHandler.GetButtonState(p1Keys[2]) == InputState.Pressed)
                Y += 5;
            else if (InputHandler.GetButtonState(p1Keys[3]) == InputState.Pressed)
                Y++;
            if (Y % 6 == 5)
            {
                X = 3;
                if (InputHandler.GetButtonState(p1Keys[5]) == InputState.Pressed)
                    done = true;
            }
            else
                AddChar();
        }

        public void Draw(bool victory)
        {
            if (!victory)
                tex = Game.mediaManager.Texture("DieOldMan");
            else
                tex = Game.mediaManager.Texture("Happy Ending");
            Renderer.Draw(tex, new Rectangle(50, 15, Game.TILESIZE * Game.TILESX, Game.TILESIZE * Game.TILESY), Color.White);
            for (int y = 0; y < 6; y++)
                for (int x = 0; x < 7; x++)
                {
                    Char(stringArray[x, y], x, y);
                }

            string temp = PlayerName();
            Renderer.DrawString(Game.highScoreFont, temp, new Vector2((float)(1920 / 2), 300)
                , Color.White, 0, new Vector2(Game.highScoreFont.MeasureString(temp).Length() / 2, Game.StartScreenFont.LineSpacing / 2), 1, SpriteEffects.None, 1);
        }

        public Score AddScore(string playerName, int score)
        {
            return new Score(playerName, LevelManager.score + Game.timer.Score());
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

        void Char(string i, int x, int y)
        {
            float scale = 1;
            Color color = Color.Gray;
            if (x == X % 7 && y == Y % 6)
            {
                scale = 1.5f;
                color = Color.White;
            }

            if (i != null)
            {
                if (i != "Done")
                {
                    Vector2 pos = new Vector2(385 + Game.highScoreFont.MeasureString("A").Length() * 1.8f * x , 450 + Game.highScoreFont.LineSpacing * 1.2f * y);
                    Renderer.DrawString(Game.highScoreFont, i, pos, color, 0, new Vector2(7, Game.highScoreFont.LineSpacing / 2), scale, SpriteEffects.None, 1);
                }
                else
                {
                    Vector2 pos = new Vector2((Game.TILESIZE * Game.TILESX / 2) , 450 + Game.highScoreFont.LineSpacing * 1.2f * y);
                    Renderer.DrawString(Game.highScoreFont, i, pos, color, 0, new Vector2((Game.highScoreFont.MeasureString(i).Length() / 2), Game.highScoreFont.LineSpacing / 2), scale, SpriteEffects.None, 1);
                }
            }
        }

        public void AddChar()
        {
            if (a <= name.Length - 1 && InputHandler.GetButtonState(p1Keys[5]) == InputState.Pressed)
            {
                name[a] = stringArray[X % 7, Y % 6];
                a++;
            }
            else if (a > 0 && a <= name.Length && InputHandler.GetButtonState(p1Keys[4]) == InputState.Pressed)
            {
                name[a - 1] = string.Empty;
                a--;
            }

        }
    }
}
