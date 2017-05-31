using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence.Game_Object
{
    class Cannonball_Tower : Tower
    {
        public Cannonball_Tower(Vector2 pos, Texture2D tex) : base (pos, tex)
        {
            Position = pos;
            texture = tex;

            Center = new Vector2(pos.X + tex.Width / 2, pos.Y + tex.Height / 2);

            Rectangle = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);

            Radius = tex.Width * 3;
        }
    }
}
