using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game {
    public class TM {
        ContentManager content;
        public TM(ContentManager content){
            this.content = content;
    }

        public Texture2D Texture(string name)
        {
            return content.Load<Texture2D>(name);
        }
    }
}
