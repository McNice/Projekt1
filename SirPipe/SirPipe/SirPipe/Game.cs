using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Game : MAHArcadeSystem.BaseGame
    {
        public static Timer timer;
        public override string GameDisplayName { get { return "SirPipe"; } }
        public static Texture2D background, startScreenTex;
        public static Texture2D testTex, black, controls;
        public static MM mediaManager;
        public static SpriteFont StartScreenFont, highScoreFont;
        public static int TILESIZE = 48;
        public static int TILESX = 40;
        public static int TILESY = 20;
        public static SoundEffect blip, select, getHurt, jump, ladder, land, victory, arrowShoot, helldoorOpen, leverPull;
        public enum GameState
        {
            Title,
            Highscore,
            Controls,
            Tutorial,
            Credits,
            Play,
            End
        }
        public static GameState gameState = GameState.Title;
        LevelManager lvlmanager;
        public static HighScore highScore;
        StartScreen startScreen;

        public Game()
        {
            //Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //PlayerInput
            mediaManager = new MM(Content);
            highScore = new HighScore();
            //LoadContent
            blip = mediaManager.Sound("blip");
            select = mediaManager.Sound("Select");
            getHurt = mediaManager.Sound("GetHurt");
            jump = mediaManager.Sound("Jump");
            ladder = mediaManager.Sound("Ladder");
            land = mediaManager.Sound("Land");
            victory = mediaManager.Sound("PowerUp");
            arrowShoot = mediaManager.Sound("ArrowShoot");
            helldoorOpen = mediaManager.Sound("HelldoorOpen");
            leverPull = mediaManager.Sound("LeverPull");
            StartScreenFont = Content.Load<SpriteFont>("StartScreenFont");
            startScreen = new StartScreen();
            background = Content.Load<Texture2D>("backgroundtutorial");
            startScreenTex = Content.Load<Texture2D>("Startscreen2");
            controls = Content.Load<Texture2D>("Textures/Controls");
            highScoreFont = Content.Load<SpriteFont>("HighScoreFont");
            // TEST
            testTex = Content.Load<Texture2D>("whitePx");
            black = Content.Load<Texture2D>("black");
            timer = new Timer(Game.StartScreenFont);
        }

        protected override void Update(GameTime gameTime)
        {
            if (InputHandler.IsKeyDown(PlayerInput.PlayerOneStart, false) && InputHandler.IsKeyDown(PlayerInput.PlayerTwoStart, false))
            {
                LevelManager.score = 0;
                gameState = GameState.Title;
            }
            switch (gameState)
            {
                case GameState.Title:
                    startScreen.Update(gameTime);
                    if (InputHandler.GetButtonState(PlayerInput.PlayerOneYellow) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoYellow) == InputState.Pressed)
                    {
                        blip.Play();
                        if (startScreen.i == 0)
                        {
                            lvlmanager = new LevelManager(false);
                            gameState = GameState.Play;
                            timer.TimerReset();
                        }
                        else if (startScreen.i == 1)
                        {
                            lvlmanager = new LevelManager(true);
                            gameState = GameState.Play;
                            timer.TimerReset();
                        }
                        else if (startScreen.i == 2)
                        {
                            lvlmanager = new LevelManager(false);
                            lvlmanager.Tutorial();
                            gameState = GameState.Tutorial;
                            timer.TimerReset();
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
                    if (InputHandler.GetButtonState(PlayerInput.PlayerOneYellow) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoYellow) == InputState.Pressed)
                    {
                        blip.Play();
                        gameState = GameState.Title;
                    }
                    break;
                case GameState.Tutorial:
                    lvlmanager.Update(gameTime);
                    break;
                case GameState.Credits:
                    if (InputHandler.GetButtonState(PlayerInput.PlayerOneYellow) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoYellow) == InputState.Pressed)
                    {
                        blip.Play();
                        gameState = GameState.Title;
                    }
                    break;
                case GameState.Highscore:
                    if (InputHandler.GetButtonState(PlayerInput.PlayerOneYellow) == InputState.Pressed || InputHandler.GetButtonState(PlayerInput.PlayerTwoYellow) == InputState.Pressed)
                    {
                        blip.Play();
                        gameState = GameState.Title;
                    }
                    break;

                case GameState.End:
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            Renderer.Clear(Color.CornflowerBlue);
            Renderer.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            switch (gameState)
            {
                case GameState.Play:
                    Renderer.Clear(Color.LightGray);
                    lvlmanager.Draw();
                    break;
                case GameState.Title:
                    Renderer.Clear(Color.Black);
                    startScreen.Draw();
                    break;
                case GameState.Controls:
                    Renderer.Clear(Color.Black);
                    Renderer.Draw(controls, new Vector2(320, 320), Color.White);
                    startScreen.Button(800, "Back", 3);
                    break;
                case GameState.Tutorial:
                    Renderer.Clear(Color.LightGray);
                    lvlmanager.Draw();
                    Renderer.Draw(background, Vector2.Zero, Color.White);
                    break;
                case GameState.Credits:
                    Renderer.Clear(Color.Black);
                    startScreen.Button(100, "Credits", 9);
                    startScreen.Button(200, "Anton - Gjorde ''allt''", 9);
                    startScreen.Button(300, "Daniel - Hämtade kaffe", 9);
                    startScreen.Button(400, "Johan - Hämtade kaffe", 9);
                    startScreen.Button(500, "Kamil - Hämtade kaffe", 9);
                    startScreen.Button(600, "Simon - is Gay", 9);
                    startScreen.Button(800, "Back", 4);
                    break;
                case GameState.Highscore:
                    Renderer.Clear(Color.Black);
                    highScore.Draw();
                    startScreen.Button(800, "Back", 5);
                    break;
                case GameState.End:
                    break;
            }
            Renderer.End();
        }
    }
}
