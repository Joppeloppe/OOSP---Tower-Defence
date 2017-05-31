using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Tower : Moving_Object
    {
        public int distance_to_tower, nearest_object, damage, radius, attack_speed, cost;

        public float target_speed, time_to_target;

        public Vector2 target_position, target_direction, future_target;

        public List<Bullet> bullets = new List<Bullet>();

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public int Attack_speed
        {
            get { return attack_speed; }
            set { attack_speed = value; }
        }


        public int Distance_to_tower
        {
            get { return distance_to_tower; }
            set { distance_to_tower = value; }
        }

        public int Nearest_object
        {
            get { return nearest_object; }
            set { nearest_object = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }


        public float Target_speed
        {
            get { return target_speed; }
            set { target_speed = value; }
        }

        public float Time_to_target
        {
            get { return time_to_target; }
            set { time_to_target = value; }
        }

        public Vector2 Target_position
        {
            get { return target_position; }
            set { target_position = value; }
        }

        public Vector2 Target_direction
        {
            get { return target_direction; }
            set { target_direction = value; }
        }

        public Vector2 Future_target
        {
            get { return future_target; }
            set { future_target = value; }
        }

        public Tower(Vector2 pos, Texture2D tex) : base (pos, tex)
        {
            Position = pos;
            texture = tex;

            Center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            Radius = texture.Width * 3;

            Distance_to_tower = 99999999;

            Cost = 100;
        }

        public void Find_Closest_Target(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if ((int)Vector2.Distance(position, enemies[i].position) < Distance_to_tower)
                {
                    Nearest_object = i;

                    Distance_to_tower = (int)Vector2.Distance(position, enemies[i].position);

                    Target_position = enemies[i].position;

                    Target_direction = enemies[i].direction;

                    Target_speed = enemies[i].speed;

                    //Time_to_target = distance_to_tower / speed;

                    //Future_target = enemies[i].position + enemies[i].direction * enemies[i].speed * time_to_target;

                    Direction = Target_position - position;
                }
            }
        }

        public bool Tower_collision(Moving_Object mo)
        {
            return rectangle.Intersects(mo.rectangle);
        }

        public bool Target_in_range(Vector2 target)
        {
            return Vector2.Distance(Center, target) < Radius;
        }

    }
}
