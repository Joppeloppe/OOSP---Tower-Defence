using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence
{
    class Start_Screen
    {
        Game1 game_1;

        Texture2D texture;

        public Start_Screen(Game1 game_1)
        {
            this.game_1 = game_1;

            texture = game_1.Content.Load<Texture2D>(@"Image/Screen/start_screen_test");
        }

        public void Update()
        {
            Input.Update();

            //Press any key.
            //if (Keyboard.GetState().GetPressedKeys().Length > 0)

            if (Input.Key_Click(Keys.S))
                game_1.Start_game();

            if (Input.Key_Click(Keys.E))
                game_1.Edit_level();

        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
