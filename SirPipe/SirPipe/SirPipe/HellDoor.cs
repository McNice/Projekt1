using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class HellDoor : Animated
    {
        public bool open;
        bool playSound;
        public HellDoor(Vector2 pos, string texName, float animationSpeed, int channel)
            : base(pos, texName, animationSpeed, channel)
        { open = false; }

        public override Rectangle Rec()
        {
            return new Rectangle(recX, 0, 100, 200);
        }
        public override void Update(GameTime gameTime)
        {
            if (playSound)
            {
                Game.helldoorOpen.Play();
                playSound = false;
            }
            base.Update(gameTime);
        }

        public override void Switch()
        {
            if(!open)
            playSound = true;
            open = true;
        }

        public override Rectangle Bounds()
        {
            return new Rectangle((int)pos.X + 20, (int)pos.Y + 20, Game.TILESIZE - 40, (Game.TILESIZE * 2) - 40);
        }
    }
}
