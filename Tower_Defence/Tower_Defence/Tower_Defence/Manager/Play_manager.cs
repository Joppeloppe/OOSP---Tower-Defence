using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_Defence.Game_Object;

namespace Tower_Defence.Manager
{
    class Play_manager : Tower_Manager
    {

        public Play_manager(Game1 game_1) : base (game_1)
        {
            this.game_1 = game_1;

            Load_Play_Hud_Tiles();
        }

        public override void Update(GameTime game_time)
        {
            Play_input();

            tile.Update(ZERO, ZERO);

            base.Update(game_time);
        }

        public override void Draw(SpriteBatch sprite_batch)
        {
            if (!hud.Play_Rectangle.Contains(Input.mouse_position))
                tile.Draw(sprite_batch);

            base.Draw(sprite_batch);

            if (hud.Play_Rectangle.Contains(Input.mouse_position))
                tile.Draw(sprite_batch);

            base.Draw(sprite_batch);

            foreach (var t in towers)
                t.Draw(sprite_batch);

            foreach (var b in bullets)
                b.Draw(sprite_batch);

            foreach (var p in particel_engines)
                p.Draw(sprite_batch);

            sprite_batch.DrawString(font, "Money: " + money, new Vector2(600, 0), Color.White);
        }

        public void Play_input()
        {
            if (Input.Left_Click())
            {
                foreach (Tile t in hud_tiles)
                    if (t.Is_selected())
                        tile.texture = t.texture;

                if (hud.Play_Rectangle.Contains(Input.mouse_position) && tile.texture != clear_tex)
                {
                    foreach (var t in towers)
                        if (t.Is_selected())
                        {
                            towers.Remove(t);

                            money += t.Cost / 2;

                            break;
                        }

                    Tower tower = new Tower(new Vector2((int)Screen_position.X - Draw_offset_x, (int)Screen_position.Y - Draw_offset_y), tile.texture);

                    if (tower.Cost <= money)
                    {
                        Add_particel_engine(tower);

                        towers.Add(tower);

                        money -= tower.Cost;

                    }

                }
            }
  
            if (Input.Right_Click())
            {
                foreach (var t in towers)
                    if (t.Is_selected())
                    {
                        towers.Remove(t);

                        money += t.Cost / 2;

                        break;
                    }
            }
        }

        public void Add_particel_engine(Tower tower)
        {
            Particle_engine particle_engine = new Particle_engine(particle_textures, Vector2.Zero);

            particle_engine.active = true;

            particle_engine.emitter_location = new Vector2(tower.Center.X, tower.Center.Y);

            particel_engines.Add(particle_engine);

        }
    }
}
