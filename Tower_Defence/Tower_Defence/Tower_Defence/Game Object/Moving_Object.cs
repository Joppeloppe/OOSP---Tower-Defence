using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Moving_Object
    {
        public Vector2 position, direction, center;
        public Texture2D texture;
        public Rectangle rectangle;
        public float speed;
        public bool dead;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }

        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Moving_Object(Vector2 pos, Texture2D tex)
        {
            position = pos;
            texture = tex;

            center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public virtual void Update(int draw_offset_x, int draw_offset_y)
        {
            rectangle.X = (int)Position.X + draw_offset_x;
            rectangle.Y = (int)Position.Y + draw_offset_y;

            Position += Direction * Speed;
        }

        public virtual void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, rectangle, Color.White);
        }

        public virtual bool Is_selected()
        {
            return rectangle.Contains(Input.mouse_position);
        }



    }
}
