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

namespace MapEditor
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Form1 form;

        MouseState mS, omS;

        readonly string dir = "../../../../../../Maps/";
        public static Texture2D tex;

        public static int tileSize = 24;

        public static readonly int BLANK = 0;
        public static readonly int TYPE1 = 1;
        public static readonly int TYPE2 = 2;
        public static readonly int TYPE3 = 3;
        public static readonly int TYPE4 = 4;
        public static readonly int TYPE5 = 5;
        public static readonly int TYPE6 = 6;
        public static readonly int TYPE7 = 7;
        public static readonly int TYPE8 = 8;
        public static readonly int TYPE9 = 9;
        public static readonly int TYPE10 = 10;

        public int type;
        public int width = 40;
        public int height = 20;

        Map map;

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
            NewMap(width, height);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tex = Content.Load<Texture2D>("bild");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            omS = mS;
            mS = Mouse.GetState();

            type = form.type;
            if (form.newMap)
            {
                width = form.width;
                height = form.height;
                NewMap(width, height);
                form.newMap = false;
            }
            if (form.save && map != null)
            {
                Save();
                form.save = false;
            }

            if (form.load)
            {
                Load();
                graphics.PreferredBackBufferWidth = map.Width * tileSize;
                graphics.PreferredBackBufferHeight = map.Height * tileSize;
                graphics.ApplyChanges();
                form.load = false;
            }

            if (mS.LeftButton == ButtonState.Pressed && map != null)
            {
                if (0 < mS.X && mS.X < width * tileSize && 0 < mS.Y && mS.Y < height * tileSize)
                {
                    int x = Math.Abs(mS.X / tileSize);
                    int y = Math.Abs(mS.Y / tileSize);
                    map.EditTile(x, y, type);

                }
            }
            if (mS.RightButton == ButtonState.Pressed && map != null)
            {
                if (0 < mS.X && mS.X < width * tileSize && 0 < mS.Y && mS.Y < height * tileSize)
                {
                    int x = Math.Abs(mS.X / tileSize);
                    int y = Math.Abs(mS.Y / tileSize);
                    map.EditTile(x, y, 0);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            if (map != null)
            {
                map.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void NewMap(int width, int height)
        {
            map = new Map(width, height);

            graphics.PreferredBackBufferWidth = width * tileSize;
            graphics.PreferredBackBufferHeight = height * tileSize;
            graphics.ApplyChanges();
        }

        private void Save()
        {
            string path = form.path;
            StreamWriter writer = new StreamWriter(dir + path + ".txt");

            writer.WriteLine("[" + width + "][" + height + "]");

            for (int y = 0; y < height; y++)
            {
                writer.Write("|");
                for (int x = 0; x < width; x++)
                {
                    writer.Write(map.tileArray[x, y].GetTileType() + "|");
                }
                writer.WriteLine();
            }
            writer.Close();
        }

        private void Load()
        {
            string path = form.path;
            string[,] temp = map.LoadMap(path);
            if (temp != null)
            {
                width = map.width;
                height = map.height;
                NewMap(width, height);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        map.tileArray[x, y].SetType(Convert.ToInt32(temp[x, y]));
                    }
                }
            }
        }
    }
}
