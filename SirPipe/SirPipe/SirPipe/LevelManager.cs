﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Input;
using MAHArcadeSystem;

namespace SirPipe
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
        int mode = 0;
        int mapNr = -1;
        List<string> mapNames;

        int mAlphaValue = 1;
        int mFadeIncrement = 5;
        double mFadeDelay = .02;

        public LevelManager(bool multiPlayer)
        {
            mp = multiPlayer;
            manager = new Manager();
            timer = new Timer(Game.StartScreenFont);
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
                    mFadeDelay -= gt.ElapsedGameTime.TotalSeconds;
                    if (mFadeDelay <= 0)
                    {
                        mFadeDelay = .035;
                        mAlphaValue += mFadeIncrement;
                        if (mAlphaValue >= 255)
                        {
                            mFadeIncrement *= -1;
                            NextMap();
                        }
                        if (mAlphaValue <= 0)
                        {
                            mFadeIncrement *= -1;
                            mode = 0;
                        }
                    }

                    break;
                case GameMode.gameOver:
                    ks = Keyboard.GetState();
                    hsAdd.Update();
                    string temp = hsAdd.PlayerName();
                    if (KeyClick(Keys.Space) && temp != string.Empty)
                    {
                        Game.highScore.AddScore(hsAdd.AddScore(hsAdd.PlayerName(), hsAdd.points));
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

        public void Draw()
        {
            switch (gameMode)
            {
                case GameMode.playing:
                    timer.Draw();
                    manager.Draw();
                    break;
                case GameMode.lose:
                    break;
                case GameMode.victory:
                    Color col = new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255));
                    Renderer.Draw(Game.black, Vector2.Zero, null, col, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);
                    manager.Draw();
                    break;
                case GameMode.gameOver:
                    hsAdd.Draw();
                    break;
            }
        }

        public void NextMap()
        {
            mapNr++;
            if (mapNames.Count == mapNr)
                mapNr = 0;
            manager.map.LoadMap(mapNames[mapNr], manager.bricks, manager.grass, manager.rng);
            manager.NewGame(mp);
        }

        public void Tutorial()
        {
            manager.map.LoadMap("tutorial", manager.bricks, manager.grass, manager.rng);
            manager.NewGame(mp);
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
