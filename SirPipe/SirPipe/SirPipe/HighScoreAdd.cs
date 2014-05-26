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
        string[,] stringArray = new string[7, 5];
        int a, X, Y;
        public int points;
        KeyboardState ks, oks;
        PlayerInput[] p1Keys;


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
        }

        public void Update()
        {

            //public PlayerInput[] p1Keys = { PlayerInput.PlayerOneLeft, PlayerInput.PlayerOneRight, PlayerInput.PlayerOneUp, PlayerInput.PlayerOneDown, PlayerInput.PlayerOneYellow, PlayerInput.PlayerOneRed };
            ks = Keyboard.GetState();
            if (InputHandler.GetButtonState(p1Keys[1]) == InputState.Pressed)
                X++;
            else if (InputHandler.GetButtonState(p1Keys[0]) == InputState.Pressed)
                X += 6;
            else if (InputHandler.GetButtonState(p1Keys[2]) == InputState.Pressed)
                Y += 4;
            else if (InputHandler.GetButtonState(p1Keys[3]) == InputState.Pressed)
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

        public void Draw()
        {
            for (int y = 0; y < 5; y++)
                for (int x = 0; x < 7; x++)
                    Char(stringArray[x, y], x, y);
            string temp = PlayerName();
            Renderer.DrawString(Game.StartScreenFont, temp, new Vector2((float)(1920 / 2), 150)
                , Color.White, 0, new Vector2(Game.StartScreenFont.MeasureString(temp).Length() / 2, Game.StartScreenFont.LineSpacing / 2), 2, SpriteEffects.None, 1);
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

        void Char(string i, int x, int y)
        {
            float scale = 3;
            Color color = Color.Gray;
            if (x == X % 7 && y == Y % 5)
            {
                scale = 4.5f;
                color = Color.White;
            }
            Vector2 pos = new Vector2(300 + Game.StartScreenFont.MeasureString("A").Length() * 4.2f * x, 350 + Game.StartScreenFont.LineSpacing * 3 * y);
            Renderer.DrawString(Game.StartScreenFont, i, pos, color, 0, new Vector2(7, Game.StartScreenFont.LineSpacing / 2), scale, SpriteEffects.None, 1);

        }

        
        public void AddChar()
        {
            if (a <= name.Length - 1 && InputHandler.GetButtonState(p1Keys[4]) == InputState.Pressed)
            {
                name[a] = stringArray[X % 7, Y % 5];
                a++;

            }
            else if (a > 0 && a <= name.Length && InputHandler.GetButtonState(p1Keys[5]) == InputState.Pressed)
            {
                name[a - 1] = string.Empty;
                a--;
            }

        }
    }
}
