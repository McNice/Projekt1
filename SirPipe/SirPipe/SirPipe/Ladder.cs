using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Ladder : Tile
    {
        public Ladder(Vector2 pos, string texName)
            : base(pos, texName)
        {
            tex = Game.mediaManager.Texture(texName);
        }
        public override void Draw()
        {
            Renderer.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.4f);
        }
        public override Rectangle Bounds()
        {
            return new Rectangle((int)pos.X + 22, (int)pos.Y, 4, Game.TILESIZE);
        }
    }
}
