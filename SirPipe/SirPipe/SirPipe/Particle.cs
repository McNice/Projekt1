using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Particle
    {
        float upSpeed = -0.5f, sideSpeed, rot = 0.3f;
        public float fade = 1;
        float scale = .1f;
        Texture2D tex;
        Vector2 pos;
        Random rnd = new Random();
        double timer;
        public Particle(Texture2D Texture, Vector2 Position, float sideSpeed)
        {
            tex = Texture;
            pos = Position;
            this.sideSpeed = sideSpeed;
        }
        public Particle(Texture2D Texture, Vector2 Position, float sideSpeed, float fade)
        {
            tex = Texture;
            pos = Position;
            this.sideSpeed = sideSpeed;
            this.fade = fade;
        }
        
        public void Update(GameTime gt)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            upSpeed += (float)gt.ElapsedGameTime.TotalSeconds / 10f;
            if (timer <= 0)
            {
                timer += 1;
                pos += new Vector2(sideSpeed, upSpeed);
                rot += 0.1f;
                fade -= (0.015f + (float)(rnd.NextDouble() / 1000f));
                scale += (0.007f + (float)(rnd.NextDouble() / 1000f));
            }
        }
        public void Update(GameTime gt,int sideSpeed, float upSpeed)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            //upSpeed += (float)gt.ElapsedGameTime.TotalSeconds / 10f;
            if (timer <= 0)
            {
                timer += 20;
                pos += new Vector2(rnd.Next(-sideSpeed*10,sideSpeed*10+1)/7, upSpeed);
                rot += 0.05f;
                fade -= (0.001f);
                scale += (0.001f );
            }
        }
        public void Draw()
        {
            Renderer.Draw(tex, pos, null, Color.White * fade, rot, new Vector2(tex.Width / 2, tex.Height / 2), scale, SpriteEffects.None, 0.53f);
        }
    }
}
