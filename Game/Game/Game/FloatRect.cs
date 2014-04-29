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

        public bool Intersects(FloatRect rect)
        {
            if (rect.Contains(pos) || rect.Contains(new Vector2(pos.X + dim.X, pos.Y)) ||
                rect.Contains(new Vector2(pos.X, pos.Y + dim.Y)) ||
                rect.Contains(new Vector2(pos.X + dim.X, pos.Y + dim.Y)))
                return true;
            if (Contains(rect.pos) || Contains(new Vector2(rect.pos.X + rect.dim.X, rect.pos.Y)) ||
                Contains(new Vector2(rect.pos.X, rect.pos.Y + rect.dim.Y)) ||
                Contains(new Vector2(rect.pos.X + rect.dim.X, rect.pos.Y + rect.dim.Y)))
                return true;
            if (pos.X > rect.pos.X && pos.X < rect.pos.X + rect.dim.X &&
                pos.Y < rect.pos.Y && pos.Y + dim.Y > rect.pos.Y + rect.dim.Y)
                return true;
            if (pos.Y > rect.pos.Y && pos.Y < rect.pos.Y + rect.dim.Y &&
                pos.X < rect.pos.X && pos.X + dim.X > rect.pos.X + rect.dim.X)
                return true;
            return false;
        }

        public bool Contains(Vector2 p)
        {
            if (p.X < pos.X + dim.X && p.X > pos.X && p.Y < pos.Y + dim.Y && p.Y > pos.Y)
                return true;
            return false;
        }
    }
}
