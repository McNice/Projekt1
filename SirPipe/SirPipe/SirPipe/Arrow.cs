using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Arrow
    {
        public Vector2 pos;
        Texture2D tex;
        Vector2 dir;
        float speed, rot;
        public bool dead = false;
        public Arrow(Vector2 pos, string texname, Vector2 direction, int rot)
        {
            this.pos = pos;
            tex = Game.mediaManager.Texture(texname);
            dir = direction;
            this.rot = rot;
            speed = 5f;
        }
        public void Update(GameTime gt)
        {
            pos += dir * speed;
        }
        public void Draw()
        {
            Renderer.Draw(tex, pos, new Rectangle(0, 0, 100, 100), Color.White, MathHelper.ToRadians(rot), new Vector2(tex.Width / 2, tex.Height / 2), 1, SpriteEffects.None, 0.5f);
        }
        public Rectangle Bounds()
        {
            if (rot == 0 || rot == 180)
                return new Rectangle((int)(pos.X - tex.Width / 2), (int)(pos.Y - tex.Height / 2) + 20, tex.Width, 8);
            else
                return new Rectangle((int)(pos.X - tex.Width / 2) + 20, (int)(pos.Y - tex.Height / 2), 8, tex.Height);
        }
    }
}
