﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MAHArcadeSystem;

namespace SirPipe
{
    public class ArrowTrap : SolidBlock
    {
        int rot, maxTimer = 4000;
        public List<Arrow> arrows;
        double timer;


        public ArrowTrap(Vector2 pos, string texName, int rot)
            : base(pos, texName)
        {
            this.rot = rot;
            arrows = new List<Arrow>();
            timer = 3000;
        }
        public void Update(GameTime gt)
        {
            timer += gt.ElapsedGameTime.TotalMilliseconds;
            if (timer >= maxTimer)
            {
                timer -= maxTimer;
                arrows.Add(AddArrow());
                Game.arrowShoot.Play();
            }
            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].Update(gt);
                if (!(new Rectangle(-50, -50, Game.TILESIZE * Game.TILESX + 100, Game.TILESIZE * Game.TILESY + 100).Contains(new Point((int)arrows[i].pos.X, (int)arrows[i].pos.Y))))
                    arrows[i].dead = true;
            }
            arrows.RemoveAll(x => x.dead);
        }
        Arrow AddArrow()
        {
            Vector2 dir = Vector2.Zero;
            if (rot == 90)
            {
                dir = new Vector2(0, 1);
            }
            else if (rot == 180)
            {
                dir = new Vector2(-1, 0);
            }
            else if (rot == 270)
            {
                dir = new Vector2(0, -1);
            }
            else if (rot == 0)
            {
                dir = new Vector2(1, 0);
            }

            return new Arrow(pos + new Vector2(24, 24), "Arrow", dir, rot);
        }

        public override void Draw()
        {

            Renderer.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.8f);
            for (int i = 0; i < arrows.Count; i++)
                arrows[i].Draw();
        }
    }
}
