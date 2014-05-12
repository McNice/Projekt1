using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Chimney : Animated
    {
        ParticleEngine particle;
        public Chimney(Vector2 pos, string texName)
            : base(pos, texName, 0, null)
        {
            particle = new ParticleEngine(texName, pos);
        }
        public override void Update(GameTime gt)
        {
            particle.Update(gt);
        }
        public override void Draw(SpriteBatch sb)
        {
            particle.Draw(sb);
        }
    }
}
