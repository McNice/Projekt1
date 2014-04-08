using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Map
    {
        public int width, height;
        [XmlIgnore]
        public List<Tile> mapList = new List<Tile>();

        public Tile[][] XmlData
        {
            get { return null; }
            set
            {
                foreach (Tile[] dom in value)
                {
                    foreach (Tile domi in dom)
                    {
                        mapList.Add(domi);
                    }
                }
            }
        }

        public Map()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile dom in mapList)
            {
                if (dom != null)
                    dom.Draw(sb);
            }
        }
    }
}
