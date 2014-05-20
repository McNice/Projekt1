using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Arrow
    {
        public Vector2 pos;
        Texture2D tex;
        Vector2 dir;
        float speed, rot;
        public Arrow(Vector2 pos, string texname, Vector2 direction, int rot)
        {
            this.pos = pos;
            tex = Game1.mediaManager.Texture(texname);
            dir = direction;
            this.rot = rot;
            speed = 5f;
        }
        public void Update(GameTime gt)
        {
            pos += dir * speed;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, new Rectangle(0, 0, 100, 100), Color.White, MathHelper.ToRadians(rot), new Vector2(tex.Width / 2, tex.Height / 2), 1, SpriteEffects.None, 1);
        }
    }
}
