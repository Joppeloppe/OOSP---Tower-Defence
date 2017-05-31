using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_Defence.Manager;

namespace Tower_Defence
{
    class Play_Screen : Play_manager
    {

        public Play_Screen (Game1 game_1) : base (game_1)
        {
            Load_Map();
        }

        public override void Update(GameTime game_time)
        {

            base.Update(game_time);
        }

        public override void Draw(SpriteBatch sprite_batch)
        {
            base.Draw(sprite_batch);
        }
    }
}
