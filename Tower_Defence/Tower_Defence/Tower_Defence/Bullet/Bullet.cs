using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Bullet : Moving_Object
    {
        public int nearest_object;
        public float damage;

        public int Nearest_object
        {
            get { return nearest_object; }
            set { nearest_object = value; }
        }

        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public Bullet(Vector2 pos, Texture2D tex)
            : base(pos, tex)
        {
            Position = pos;
            texture = tex;

            Center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            Speed = 5;
            Damage = 1f;
        }

        public void Homing(Vector2 target_pos)
        {
            Vector2 direction = target_pos - position;

            if (direction != Vector2.Zero)
                direction.Normalize();

            position += direction * speed;
        }

        public void Straight_Shot()
        {
            if (direction != Vector2.Zero)
                direction.Normalize();
        }

        public void Scatter_Shot(List<Bullet> bullets, List<Enemy> enemies, Texture2D texture)
        {
            Bullet p_1 = new Bullet(position, texture);
            Bullet p_2 = new Bullet(position, texture);

            Vector2 extra_dir = new Vector2(texture.Width, texture.Height);

            p_1.direction += extra_dir;
            p_2.direction -= extra_dir;

            if (p_1.direction != Vector2.Zero)
                direction.Normalize();

            if (p_2.direction != Vector2.Zero)
                direction.Normalize();

            bullets.Add(p_1);
            bullets.Add(p_2);
        }

        public bool Hits_Enemy(Enemy e)
        {
            return Rectangle.Intersects(e.Rectangle);
        }
    }
}
