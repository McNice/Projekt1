﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MAHArcadeSystem;

namespace SirPipe
{
    public class Tile
    {
        protected Texture2D tex;
        protected string texName;
        public Vector2 pos;
        public Rectangle tileBox;
        public Tile(Vector2 pos,string texName)
        {
            this.pos = pos;
            this.texName = texName;
            LoadContent();
        }

        public void LoadContent()
        {
            tex = Game.mediaManager.Texture(texName);
        }
        
        public virtual void Draw()
        {
            Renderer.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.48f, SpriteEffects.None, 0.6f);
        }

        public virtual Rectangle Bounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, Game.TILESIZE, Game.TILESIZE);
        }
    }
}
