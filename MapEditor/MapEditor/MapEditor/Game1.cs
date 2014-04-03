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

namespace MapEditor
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;

        Form1 form;

        Tile[,] tileArray;

        public static Texture2D tex;

        public static int tileSize = 32;

        public static readonly int BLANK = 0;
        public static readonly int TYPE1 = 1;
        public static readonly int TYPE2 = 2;

        public int type;
        public int width;
        public int height;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            form = new Form1();
            form.Show();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("SpriteFont1");
            tex = Content.Load<Texture2D>("bild");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            type = form.type;
            if (form.newMap)
            {
                width = form.width;
                height = form.height;
                NewMap();
                form.newMap = false;
            }
            if (form.save)
            {
                Save();
                form.save = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            if (tileArray != null)
            {
                foreach (Tile t in tileArray)
                {
                    if (t != null)
                        t.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void NewMap()
        {
            tileArray = new Tile[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (tileArray[x, y] == null)
                        tileArray[x, y] = new Tile(new Vector2(x * tileSize, y * tileSize), BLANK);
                }
            }
            graphics.PreferredBackBufferWidth = width * tileSize;
            graphics.PreferredBackBufferHeight = height * tileSize;
            graphics.ApplyChanges();
        }
        private void Save() { }
    }
}
