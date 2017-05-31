using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Enemy : Moving_Object
    {
        StreamReader stream_reader;

        public Queue<Vector2> waypoints = new Queue<Vector2>();

        public float life;

        public bool spawn;

        public float Life
        {
            get { return life; }
            set { life = value; }
        }

        public float distance_to_target
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }

        public Enemy (Vector2 pos, Texture2D tex) : base (pos, tex)
        {
            Position = pos;
            texture = tex;

            Center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

            Speed = 2f;
            Life = 50;
        }

        public override void Update(int draw_offset_x, int draw_offset_y)
        {
            if (waypoints.Count > 0)
            {
                if (distance_to_target < speed)
                {
                    Position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                else
                {
                    direction = waypoints.Peek() - position;
                    direction.Normalize();
                }

            }

            else
                dead = true;

            base.Update(draw_offset_x, draw_offset_y);
        }

        public void Set_Waypoints()
        {
            this.position = waypoints.Dequeue();
        }

        public void Load_Waypoint()
        {
            stream_reader = new StreamReader(@"waypoint_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                waypoints.Enqueue(new Vector2(int.Parse(split[0]) - center.X, int.Parse(split[1]) - center.Y));
            }

            stream_reader.Close();
        }

        public void Attack_Object(List<Tower> towers)
        {
            foreach (var t in towers)
                if (Collide_tower(t))
                {
                    towers.Remove(t);

                    break;
                }
        }

        public bool Collide_tower(Tower tower)
        {
            return rectangle.Intersects(tower.Rectangle);
        }
    }
}
