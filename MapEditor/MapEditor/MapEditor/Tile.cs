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
        [XmlAttribute]
        public int type;
        public Vector2 pos;
<<<<<<< HEAD
        public string texName;
=======
>>>>>>> 337fd0a1772d155f1f00848e5c562fd39ab1a88a

        public Tile(Vector2 pos, int type)
        {
            this.pos = pos;
            this.type = type;
        }

        public Tile() { }

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
