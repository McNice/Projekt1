using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Manager
    {
        enum PlayerState
        {
            Singleplayer,
            Multiplayer
        }
        PlayerState playerState = new PlayerState();

        List<Player> players = new List<Player>();

        Map map;
        public static string path = "../../../../../../Maps/";

       

        public Manager()
        {
            map = new Map(20, 20);
            map.LoadMap("auto");
        }

        public void LoadContent()
        {
            playerState = PlayerState.Multiplayer;
            switch (playerState)
            {
                case PlayerState.Singleplayer:
                    players.Add(new Player(Game1.textureManager.Texture("Monopoly man 50x100"), new Vector2(300, 300), "Player1"));
                    break;
                case PlayerState.Multiplayer:
                    players.Add(new Player(Game1.textureManager.Texture("Monopoly man 50x100"), new Vector2(300, 300), "Player1"));
                    players.Add(new Player(Game1.textureManager.Texture("Monopoly man 50x100"), new Vector2(400, 300), "Player2"));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Player p in players)
            {
                p.Update(gameTime);
                foreach (SolidBlock t in map.mapArray)
                {
                    
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Player p in players)
            {
                p.Draw(spriteBatch);
            }
            map.Draw(spriteBatch);
        }
    }
}
