using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class LevelManager
    {
        Manager manager;
        Timer timer;
        HighScoreAdd hsAdd;
        KeyboardState ks, oks;
        public enum GameMode
        {
            playing, lose, victory, gameOver
        }
        public GameMode gameMode;
        bool mp;
        public bool GameOver = false;
        int mode = 3;
        int mapNr = -1;
        List<string> mapNames;

        public LevelManager(bool multiPlayer)
        {
            mp = multiPlayer;
            manager = new Manager();
            timer = new Timer(Game1.StartScreenFont);
            manager.NewGame(mp);
            gameMode = GameMode.playing;
            mapNames = LoadMaps(multiPlayer);
            NextMap();
            hsAdd = new HighScoreAdd();
        }

        public void Update(GameTime gt)
        {
            if (mode == 0)
                gameMode = GameMode.playing;
            else if (mode == 1)
                gameMode = GameMode.lose;
            else if (mode == 2)
                gameMode = GameMode.victory;
            else if (mode == 3)
                gameMode = GameMode.gameOver;

            switch (gameMode)
            {
                case GameMode.playing:
                    manager.Update(gt, ref mode);
                    timer.Update(gt);

                    break;
                case GameMode.lose:

                    break;
                case GameMode.victory:
                    NextMap();
                    mode = 0;
                    break;
                case GameMode.gameOver:
                    ks = Keyboard.GetState();
                    hsAdd.Update();
                    string temp = hsAdd.PlayerName();
                    if (KeyClick(Keys.Space) && temp != string.Empty)
                    {
                        Game1.highScore.AddScore(hsAdd.AddScore(hsAdd.PlayerName(), hsAdd.points));
                        GameOver = true;
                    }
                    oks = ks;
                    break;
            }

        }

        public bool KeyClick(Keys key)
        {
            if (ks.IsKeyDown(key) && oks.IsKeyUp(key))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {


            switch (gameMode)
            {
                case GameMode.playing:
                    timer.Draw(sb);
                    manager.Draw(sb);
                    break;
                case GameMode.lose:
                    break;
                case GameMode.victory:
                    break;
                case GameMode.gameOver:
                    hsAdd.Draw(sb);

                    break;
            }
        }

        public void NextMap()
        {
            mapNr++;
            if (mapNames.Count == mapNr)
                mapNr = 0;
            manager.map.LoadMap(mapNames[mapNr], manager.bricks, manager.grass, manager.rng);
        }

        public List<string> LoadMaps(bool multiplayer)
        {
            string file;
            List<string> temp = new List<string>();
            if (multiplayer)
                file = "multiplayer.txt";
            else
                file = "singleplayer.txt";

            StreamReader r = new StreamReader("../../../../../../Maps/" + file);
            using (r)
            {
                while (!r.EndOfStream)
                {
                    temp.Add(r.ReadLine());
                }
            }
            return temp;
        }
    }
}
