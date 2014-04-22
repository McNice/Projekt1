using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Particle
    {
        float upSpeed = -0.4f, sideSpeed, rot;
        public float fade = 1;
        float scale = .08f;
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
                timer += 30;
                pos += new Vector2(sideSpeed, upSpeed);
                if (sideSpeed > 0)
                    sideSpeed -= 0.0007f;
                else if (sideSpeed < 0)
                    sideSpeed += 0.0007f;
                rot += 0.1f;
                fade -= .01f;
                scale += .007f;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White * fade, rot, new Vector2(tex.Width / 2, tex.Height / 2), scale, SpriteEffects.None, 1);
        }
    }
}
