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
        Texture2D background;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
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
            Tutorial,
            Credits,
            Play,
            End
        }
        GameState gameState = GameState.Title;
        LevelManager lvlmanager;
        public static HighScore highScore;
        public static MM mediaManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.ToggleFullScreen();
            //debug
            //graphics.PreferredBackBufferWidth = 1600;
            //graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            mediaManager = new MM(Content);
            highScore = new HighScore();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StartScreenFont = Content.Load<SpriteFont>("StartScreenFont");
            startScreen = new StartScreen();
            background = Content.Load<Texture2D>("theRealShit");
            // TEST
            testTex = Content.Load<Texture2D>("Textures/Black Tile");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();

            if (KeyMouseReader.KeyPressed(Keys.F1))
                graphics.ToggleFullScreen();
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
                            lvlmanager = new LevelManager(false);
                            gameState = GameState.Play;
                        }
                        else if (startScreen.i == 1)
                        {
                            lvlmanager = new LevelManager(true);
                            gameState = GameState.Play;
                        }
                        else if (startScreen.i == 2)
                        {
                            lvlmanager = new LevelManager(false);
                            lvlmanager.Tutorial();
                            gameState = GameState.Tutorial;
                        }
                        else if (startScreen.i == 3)
                            gameState = GameState.Controls;
                        else if (startScreen.i == 4)
                            gameState = GameState.Credits;
                        else if (startScreen.i == 5)
                            gameState = GameState.Highscore;
                    }
                    break;
                case GameState.Play:
                    lvlmanager.Update(gameTime);
                    if (lvlmanager.GameOver)
                        gameState = GameState.Title;
                    break;
                case GameState.Controls:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
                    break;
                case GameState.Tutorial:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Tutorial;
                    lvlmanager.Update(gameTime);
                    break;
                case GameState.Credits:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
                    break;
                case GameState.Highscore:
                    if (KeyMouseReader.KeyPressed(Keys.Space))
                        gameState = GameState.Title;
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
                    lvlmanager.Draw(spriteBatch);
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
                case GameState.Tutorial:
                    lvlmanager.Draw(spriteBatch);
                    spriteBatch.Draw(background, Vector2.Zero, Color.White);
                    break;
                case GameState.Credits:
                    GraphicsDevice.Clear(Color.Black);
                    startScreen.Button(100, "Credits", spriteBatch, 9);
                    startScreen.Button(200, "Anton - Gjorde ''allt''", spriteBatch, 9);
                    startScreen.Button(300, "Daniel - Hämtade kaffe", spriteBatch, 9);
                    startScreen.Button(400, "Johan - Hämtade kaffe", spriteBatch, 9);
                    startScreen.Button(500, "Kamil - Hämtade kaffe", spriteBatch, 9);
                    startScreen.Button(600, "Simon - is Gay", spriteBatch, 9);
                    startScreen.Button(800, "Back", spriteBatch, 4);
                    break;
                case GameState.Highscore:
                    GraphicsDevice.Clear(Color.Black);

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
