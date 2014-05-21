using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MAHArcadeSystem;

namespace SirPipe
{
    public class SolidBlock : Tile
    {
        public SolidBlock(Vector2 pos, string texName)
            : base(pos, texName)
        {

        }
    }
}
