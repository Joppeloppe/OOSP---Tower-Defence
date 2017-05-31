using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Game_Object
    {
        public Point position, center;
        public Vector2 direction;
        public Texture2D texture;
        public Rectangle rectangle;
        public int speed;

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public Point Center
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

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Game_Object(Point pos, Texture2D tex)
        {
            position = pos;
            texture = tex;

            center = new Point(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public virtual void Update(int draw_offset_x, int draw_offset_y)
        {
            rectangle.X = (int)position.X + draw_offset_x;
            rectangle.Y = (int)position.Y + draw_offset_y;
        }

        public virtual void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public virtual bool Is_selected()
        {
            return rectangle.Contains(Input.mouse_position);
        }
    }
}
