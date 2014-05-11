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

namespace Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static Texture2D testTex;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Timer timer;
        public static SpriteFont StartScreenFont;
        StartScreen startScreen;
        public static int TILESIZE = 48;
        public static int TILESX = 40;
        public static int TILESY = 20;
        enum GameState
        {
            Title,
            Highscore,
            Controls,
            Credits,
            Play,
            End
        }
        GameState gameState = GameState.Title;
        Manager manager;
        HighScore highScore;
        public static MM mediaManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = TILESIZE * TILESX;
            graphics.PreferredBackBufferHeight = TILESIZE * TILESY;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            mediaManager = new MM(Content);
            manager = new Manager();
            highScore = new HighScore();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StartScreenFont = Content.Load<SpriteFont>("StartScreenFont");
            timer = new Timer(Game1.StartScreenFont);
            manager.LoadContent();
            startScreen = new StartScreen();

            // TEST
            testTex = Content.Load<Texture2D>("Textures/Black Tile");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();

            if (KeyMouseReader.KeyPressed(Keys.Escape))
                this.Exit();

            switch (gameState)
            {
                case GameState.Title:
                    startScreen.Update(gameTime);
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                    {
                        if (startScreen.i == 0)
                        {
                            manager.multiPlayer = false;
                            manager.players.Clear();
                            manager.NewGame();
                            gameState = GameState.Play;
                        }
                        else if (startScreen.i == 1)
                        {
                            manager.multiPlayer = true;
                            manager.players.Clear();
                            manager.NewGame();
                            gameState = GameState.Play;
                        }
                        else if (startScreen.i == 2)
                        {

                        }
                        else if (startScreen.i == 3)
                            gameState = GameState.Controls;
                        else if (startScreen.i == 4)
                            gameState = GameState.Credits;
                        else if (startScreen.i == 5)
                            gameState = GameState.Highscore;
                    }
                    break;
                case GameState.Highscore:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
                    break;
                case GameState.Controls:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
                    break;
                case GameState.Credits:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
                    break;
                case GameState.Play:
                    manager.Update(gameTime);
                    timer.Update(gameTime);
                    break;
                case GameState.End:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            switch (gameState)
            {
                case GameState.Play:
                    manager.Draw(spriteBatch);
                    timer.Draw(spriteBatch);
                    break;
                case GameState.Title:
                    GraphicsDevice.Clear(Color.Black);
                    startScreen.Draw(spriteBatch);
                    break;
                case GameState.Controls:
                    GraphicsDevice.Clear(Color.Black);
                    startScreen.Button(500, "Insert Image", spriteBatch, 9);
                    startScreen.Button(800, "Back", spriteBatch, 3);
                    break;
                case GameState.Credits:
                    GraphicsDevice.Clear(Color.Black);
                    startScreen.Button(100, "Credits", spriteBatch, 9);
                    startScreen.Button(200, "Anton - Gjorde ''allt''", spriteBatch, 9);
                    startScreen.Button(300, "Daniel - H�mtade kaffe", spriteBatch, 9);
                    startScreen.Button(400, "Johan - H�mtade kaffe", spriteBatch, 9);
                    startScreen.Button(500, "Kamil - H�mtade kaffe", spriteBatch, 9);
                    startScreen.Button(600, "Simon - is Gay", spriteBatch, 9);
                    startScreen.Button(800, "Back", spriteBatch, 4);
                    break;
                case GameState.Highscore:
                    GraphicsDevice.Clear(Color.Black);
                    highScore.RandomScore();
                    highScore.Draw(spriteBatch);
                    startScreen.Button(800, "Back", spriteBatch, 5);
                    break;
                case GameState.End:
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
