using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Game {
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int TILESIZE = 40;
        public static int TILESX = 30;
        public static int TILESY = 20;
        enum GameState {
            Title,
            Highscore,
            Controls,
            Credits,
            Play,
            End
        }
        GameState gameState = GameState.Play;
        Manager manager;
        TM textureManager;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = TILESIZE * TILESX;
            graphics.PreferredBackBufferHeight = TILESIZE * TILESY;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            manager = new Manager();
            textureManager = new TM(Content);
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureManager.LoadContent();
            manager.LoadContent();
        }

        protected override void Update(GameTime gameTime) {
            KeyMouseReader.Update();
            if (KeyMouseReader.KeyPressed(Keys.Escape))
                this.Exit();

            switch (gameState) {
                case GameState.Title:
                    break;
                case GameState.Highscore:
                    break;
                case GameState.Controls:
                    break;
                case GameState.Credits:
                    break;
                case GameState.Play:
                    manager.Update(gameTime);
                    break;
                case GameState.End:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch (gameState) {
                case GameState.Title:
                    break;
                case GameState.Highscore:
                    break;
                case GameState.Controls:
                    break;
                case GameState.Credits:
                    break;
                case GameState.Play:
                    manager.Draw(spriteBatch);
                    break;
                case GameState.End:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}