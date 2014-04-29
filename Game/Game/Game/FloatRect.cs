using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game
{
    public class FloatRect
    {
        private Vector2 pos;
        private Vector2 dim;

        public Vector2 Pos { get { return pos; } }
        public Vector2 Dim { get { return dim; } }

        public FloatRect(Vector2 pos, Vector2 dim)
        {
            this.pos = pos;
            this.dim = dim;
        }
    }
}
