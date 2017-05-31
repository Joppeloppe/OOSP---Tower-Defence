using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence
{
    class Level_Lost
    {
        Game1 game_1;

        Texture2D texture;

        public Level_Lost(Game1 game_1)
        {
            this.game_1 = game_1;

            texture = game_1.Content.Load<Texture2D>(@"Image/Screen/game_over_test");
        }

        public void Update()
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
                game_1.Start_game();
        }

        public void Draw (SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
