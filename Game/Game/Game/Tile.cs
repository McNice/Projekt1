﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game
{
    public class Tile
    {
        Texture2D tex;
        string texName;
        public Vector2 pos;
        public Tile(Vector2 pos,string Texture)
        {
            this.pos = pos;
            texName = Texture;
            LoadContent();
        }

        public void LoadContent()
        {
            tex = Game1.textureManager.Texture(texName);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
        }
    }
}