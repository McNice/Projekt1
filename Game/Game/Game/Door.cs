﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class Door : Animated
    {
        public Door(Vector2 pos, string texName, float animationSpeed)
            : base(pos, texName, animationSpeed)
        {
            start = false;
        }
        //public override void Update(GameTime gameTime)
        //{
        //}

        public override Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 200);
        }
    }
}
