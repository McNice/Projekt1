﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Chimney : Animated
    {
        ParticleEngine particle;
        public Chimney(Vector2 pos, string texName)
            : base(pos, texName, 0, null)
        {
            particle = new ParticleEngine(texName, pos,1,-0.3f, 0.6f);
        }
        public override void Update(GameTime gt)
        {
            particle.Update(gt,1);
        }
        public override void Draw()
        {
            particle.Draw();
        }
    }
}
