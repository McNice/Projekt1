using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace MapEditor
{
    public class Tile
    {
        public int type;
        public Vector2 pos;
        public string texName;

        public Tile(Vector2 pos, int type)
        {
            this.pos = pos;
            this.type = type;
        }

        public void Draw(SpriteBatch sB)
        {
            if (type >= 500 && type < 600)
                sB.Draw(Game1.tex, pos, new Rectangle(11 * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
            else if (type >= 600 && type < 700)
                sB.Draw(Game1.tex, pos, new Rectangle(12 * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
            else if (type >= 700 && type < 800)
                sB.Draw(Game1.tex, pos, new Rectangle(13 * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
            else if (type >= 800 && type < 900)
                sB.Draw(Game1.tex, pos, new Rectangle(14 * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
            else if (type >= 900 && type < 1000)
                sB.Draw(Game1.tex, pos, new Rectangle(20 * Game1.tileSize, 0, Game1.tileSize, Game1.tileSize), Color.White);
            else
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
