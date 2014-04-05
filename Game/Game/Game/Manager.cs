using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game {
    public class Manager {
        enum PlayerState {
            Singleplayer,
            Multiplayer
        }
        PlayerState playerState = new PlayerState();

        List<Player> players = new List<Player>();

        public Manager() {
        }

        public void LoadContent() {
            playerState = PlayerState.Multiplayer;
            switch (playerState) {
                case PlayerState.Singleplayer:
                    players.Add(new Player(TM.astroid, new Vector2(300, 300), "Player1"));
                    break;
                case PlayerState.Multiplayer:
                    players.Add(new Player(TM.astroid, new Vector2(300, 300), "Player1"));
                    players.Add(new Player(TM.astroid, new Vector2(400, 300), "Player2"));
                    break;
            }
        }

        public void Update(GameTime gameTime) {
            foreach (Player p in players) {
                p.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Player p in players) {
                p.Draw(spriteBatch);
            }
        }
    }
}
