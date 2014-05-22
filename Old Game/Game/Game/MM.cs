using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game
{
    public class MM
    {
        ContentManager content;
        public MM(ContentManager content)
        {
            this.content = content;
        }

        public Texture2D Texture(string name)
        {
            return content.Load<Texture2D>("Textures/" + name);
        }

        public SoundEffect Sound(string name)
        {
            return content.Load<SoundEffect>("SoundEffects/" + name);
        }

        public Song Music(string name)
        {
            return content.Load<Song>("Songs/" + name);
        }
    }
}
