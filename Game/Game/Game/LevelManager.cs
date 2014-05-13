using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LevelManager
    {
        Manager manager;
        public enum GameMode
        {
            playing, lose, victory, gameOver
        }
        public GameMode gameMode;
        bool mp;
        int mode;

        public LevelManager(bool multiPlayer)
        {
            mp = multiPlayer;
            manager = new Manager();
            manager.NewGame(mp);
            gameMode = GameMode.playing;
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

                    break;
                case GameMode.lose:

                    break;
                case GameMode.victory:

                    break;
                case GameMode.gameOver:

                    break;
            }

        }
        
        public void Draw(SpriteBatch sb)
        {
            manager.Draw(sb);
        }
    }
}
