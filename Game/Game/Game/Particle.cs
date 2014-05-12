using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
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
            upSpeed += (float)gt.ElapsedGameTime.TotalSeconds / 10f;
            if (timer <= 0)
            {
                timer += 1;
                pos += new Vector2(rnd.Next(-sideSpeed,sideSpeed+1), upSpeed);
                rot += 0.1f;
                fade -= (0.015f + (float)(rnd.NextDouble() / 1000f));
                scale += (0.007f + (float)(rnd.NextDouble() / 1000f));
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White * fade, rot, new Vector2(tex.Width / 2, tex.Height / 2), scale, SpriteEffects.None, 1);
        }
    }
}
