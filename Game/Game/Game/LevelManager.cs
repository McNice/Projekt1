using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Game
{
    public class LevelManager
    {
        Manager manager;
        Timer timer;
        public enum GameMode
        {
            playing, lose, victory, gameOver
        }
        public GameMode gameMode;
        bool mp;
        int mode;
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
        }

        public void Update(GameTime gt)
        {
            if (mode == 0)
                gameMode = GameMode.playing;
            else if (mode == 1)
                gameMode = GameMode.lose;
            else if (mode == 2)
                gameMode = GameMode.victory;

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

                    break;
            }

        }

        public void Draw(SpriteBatch sb)
        {
            timer.Draw(sb);
            manager.Draw(sb);
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
