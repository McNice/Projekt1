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

namespace WindowsGame1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<ParticleEngine> particle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            
            particle = new List<ParticleEngine>();
            for (int i = 0; i < 10; i++)
                particle.Add(new ParticleEngine(Content, "Smoketex", new Vector2(50+25 * i, 300)));
            //particle = new ParticleEngine(Content,"Smoketex",new Vector2(100*i,300));

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            foreach (ParticleEngine p in particle)
                p.Update(gameTime);
            foreach (ParticleEngine p in particle)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    p.pos.X++;
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                    p.pos.X--;
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                    p.pos.Y++;
                else if (Keyboard.GetState().IsKeyDown(Keys.W))
                    p.pos.Y--;
            }
                
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            foreach (ParticleEngine p in particle)
                p.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
