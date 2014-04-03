using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MapEditor
{
    class Tile
    {
        int type;

        Vector2 pos;

        public Tile(Vector2 pos, int type)
        {
            this.pos = pos;
            this.type = type;
        }

        public void Draw(SpriteBatch sB)
        {
            sB.Draw(Game1.tex, pos, new Rectangle(type * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public int GetTileType()
        {
            return type;
        }
    }
}
