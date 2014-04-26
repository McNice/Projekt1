using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
                int collisionCount = 0;
                foreach (Tile t in map.mapArray)
                {
                    if (t is SolidBlock && Keyboard.GetState().IsKeyDown(Keys.D) && Collision(p, t, Keys.D))
                        collisionCount++;
                    if (t is SolidBlock && Keyboard.GetState().IsKeyDown(Keys.A) && Collision(p, t, Keys.A))
                        collisionCount++;
                }
                if (collisionCount == 0 && Keyboard.GetState().IsKeyDown(Keys.D))
                    p.PlayerMovement(Keys.D);
                else if (collisionCount == 0 && Keyboard.GetState().IsKeyDown(Keys.A))
                    p.PlayerMovement(Keys.A);
            }
        }

        bool Collision(Player p, Tile t, Keys key)
        {
            int direction = 1;
            if (key == Keys.A)
                direction = -1;
            if (p.Bounds(p.position, p.runningSpeed * direction).Intersects(t.Bounds()))
                return true;
            return false;
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
