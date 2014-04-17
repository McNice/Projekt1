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
                    players.Add(new Player(Game1.astroid, new Vector2(300, 300), "Player1"));
                    break;
                case PlayerState.Multiplayer:
                    players.Add(new Player(Game1.astroid, new Vector2(300, 500), "Player1"));
                    players.Add(new Player(Game1.astroid, new Vector2(400, 700), "Player2"));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Player p in players)
            {
                p.Update(gameTime);
            }
            foreach (Player p in players)
                foreach (Tile b in map.mapArray)
                    if (b is Block)
                        if (BoundingBox(p.position, p.PlayerBox).Intersects(BoundingBox((b as Block).pos, (b as Block).boundingBox)))
                        {
                            p.Collision();
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
        private Rectangle BoundingBox(Vector2 pos, Rectangle size)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, size.Width, size.Height);
        }
    }
}
