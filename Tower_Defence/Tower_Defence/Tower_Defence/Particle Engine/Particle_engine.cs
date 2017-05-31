using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence
{
    public class Particle_engine
    {
        private Random random;

        public Vector2 emitter_location;


        private int elapsed_time;
        private int time_interval = 2;
        private int duration = 60;
        public bool active;

        private List<Particle> particles;
        private List<Texture2D> textures;

        public Particle_engine(List<Texture2D> textures, Vector2 location)
        {
            emitter_location = location;

            this.textures = textures;
            this.particles = new List<Particle>();

            random = new Random();
        }

        public void Update(int draw_offset_x, int draw_offset_y)
        {
            if (active)
            {
                int total = 1;

                for (int i = 0; i < total; i++)
                {
                    particles.Add(Generate_New_Particle(draw_offset_x, draw_offset_y));
                }
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();

                if (particles[particle].ttl <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw (SpriteBatch sprite_batch)
        {

            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(sprite_batch);
            }

        }
        private Particle Generate_New_Particle(int draw_offset_x, int draw_offset_y)
        {
            Texture2D tex = textures[random.Next(textures.Count)];
            Vector2 pos = new Vector2(emitter_location.X + draw_offset_x, emitter_location.Y + draw_offset_y);

            Vector2 speed = new Vector2(0.5f * (float)(random.NextDouble() * 2 - 1),
                0.5f * (float)(random.NextDouble() * 2 - 1));

            float angle = 0;
            float angle_speed = 0.1f * (float)(random.NextDouble() * 2 - 1);

            Color color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

            float size = (float)random.NextDouble();
            int ttl = 50 + random.Next(20);

            return new Particle(pos, tex, speed, angle, angle_speed, color, size, ttl);
        }

        public virtual void Timer(GameTime game_time)
        {
            if (active)
            {
                elapsed_time += (int)game_time.ElapsedGameTime.TotalMilliseconds;

                if (elapsed_time >= time_interval)
                {
                    --duration;

                    elapsed_time -= time_interval;
                }
            }

            if (duration <= 0)
            {
                active = false;

                duration = 60;
            }
        }
    }
}
