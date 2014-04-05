using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game {
    public class TM {
        ContentManager content;
        public static Texture2D astroid;
        public TM(ContentManager content) {
            this.content = content;
        }

        public void LoadContent() {
            astroid = content.Load<Texture2D>("astroid");
        }
    }
}
