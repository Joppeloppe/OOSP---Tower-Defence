using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence
{
    class HUD
    {
        Game1 game_1;

        Vector2 position;
        Texture2D texture, tile_texture;
        Rectangle rectangle, play_rectangle;

        SpriteFont font;

        Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        
        Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public Rectangle Play_Rectangle
        {
            get { return play_rectangle; }
            set { play_rectangle = value; }
        }

        public HUD (Vector2 pos, Game1 game_1)
        {
            this.game_1 = game_1;
            position = pos;

            texture = game_1.Content.Load<Texture2D>(@"Image/HUD/hud_1600_900");
            tile_texture = game_1.Content.Load<Texture2D>(@"Image/Color/blue");
            font = game_1.Content.Load<SpriteFont>(@"Font/Andy");

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            play_rectangle = new Rectangle((int)position.X + tile_texture.Width * 2, (int)position.Y + tile_texture.Height * 2, texture.Width - tile_texture.Width * 4, texture.Height - tile_texture.Height * 4);
        }

        public void Update()
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            play_rectangle = new Rectangle((int)position.X + tile_texture.Width * 2, (int)position.Y + tile_texture.Height * 2, texture.Width - tile_texture.Width * 4, texture.Height - tile_texture.Width * 4);
        }

        public void Draw (SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(texture, rectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0);
            //sprite_batch.DrawString(font, "Hejsan!", Vector2.Zero, Color.White);
        }

    }
}
