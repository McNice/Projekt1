using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class ParticleEngine
    {

        List<Particle> particleList;
        Random rnd = new Random();
        public Vector2 pos;
        Texture2D tex;
        double timer = 100;
        float verSpeed;
        int sideSpeed;


        public ParticleEngine( string texName, Vector2 Position)
        {
            tex = Game1.mediaManager.Texture(texName);
            pos = Position;
            particleList = new List<Particle>();
        }

        public ParticleEngine(string texName, Vector2 Position,int sideSpeed, float verSpeed)
        {
            tex = Game1.mediaManager.Texture(texName);
            pos = Position + new Vector2(24, 0); 
            this.sideSpeed = sideSpeed;
            this.verSpeed=verSpeed;
            particleList = new List<Particle>();
        }

        public void Update(GameTime gt,short s)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            if (timer <= 0)
            {
                timer += 15;
                particleList.Add(new Particle(tex, pos, rnd.Next(-7, 8) / 100f));
            }
            foreach (Particle p in particleList)
            {
                p.Update(gt,sideSpeed,verSpeed);
            }
            for (int i = 0; i < particleList.Count(); i++)
            {
                if (particleList[i].fade <= 0)
                    particleList.Remove(particleList[i]);
            }
        }

        public void Update(GameTime gt)
        {
            timer -= gt.ElapsedGameTime.TotalMilliseconds;
            if (timer <= 0)
            {
                timer += 15;
                particleList.Add(new Particle(tex, pos, rnd.Next(-7, 8) / 100f));
            }
            foreach (Particle p in particleList)
            {
                p.Update(gt);
            }
            for (int i = 0; i < particleList.Count(); i++)
            {
                if (particleList[i].fade <= 0)
                    particleList.Remove(particleList[i]);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Particle p in particleList)
                p.Draw(sb);
        }        
    }
}
