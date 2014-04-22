using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class ParticleEngine
    {

        ContentManager content;
        List<Particle> particleList;
        Random rnd = new Random();
        public Vector2 pos;
        Texture2D tex;
        double timer = 100;

        public ParticleEngine(ContentManager Content, string texName,Vector2 Position)
        {
            content = Content;
            tex = TextureLoad(texName);
            pos = Position;
            particleList = new List<Particle>();
        }
       
        public void Update(GameTime gt)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            if (timer <= 0)
            {
                timer += 15;
                particleList.Add(new Particle(tex, pos, rnd.Next(-10, 11) / 100f));
            }
            foreach (Particle p in particleList)
            {
                p.Update(gt);
            }
            //for (int i = 0; i < particleList.Count(); i++)
            //{
            //    if (particleList[i].fade <= 0)
            //        particleList.Remove(particleList[i]);
            //}

        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Particle p in particleList)
                p.Draw(sb);
            sb.DrawString(content.Load<SpriteFont>("1"), "" + particleList.Count(), Vector2.Zero, Color.White);
        }

        private Texture2D TextureLoad(string texName)
        {
            return content.Load<Texture2D>(texName);
        }

    }


}
