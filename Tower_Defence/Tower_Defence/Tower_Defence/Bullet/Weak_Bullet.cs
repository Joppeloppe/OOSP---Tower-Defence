using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Weak_Bullet : Bullet
    {
        public Weak_Bullet(Vector2 pos, Texture2D tex, Vector2 target_pos) : base (pos, tex, target_pos)
        {
            Position = pos;
            texture = tex;
            Target_position = target_pos;

            center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

            Direction = Target_position - Position;

            Speed = 5;

            Homing();
        }
    }
}
