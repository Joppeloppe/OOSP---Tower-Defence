using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Waypoint : Tile
    {
        public Waypoint (Point pos, Texture2D tex) : base (pos, tex)
        {
            Position = pos;
            texture = tex;

            Center = new Point(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

        }

        public override string ToString()
        {
            return center.X.ToString() + ';' + center.Y;
        }
    }
}
