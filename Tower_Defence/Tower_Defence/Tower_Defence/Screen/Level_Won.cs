using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence
{
    class Level_Won
    {
        Texture2D texture;

        public Level_Won(Game1 game_1)
        {
            texture = game_1.Content.Load<Texture2D>(@"Image/Screen/game_win_test");
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
