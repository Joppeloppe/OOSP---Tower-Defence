using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_Defence.Gamge_Object;

namespace Tower_Defence.Manager
{
    class Bullet_Manager : Tower_Manager
    {
        public Bullet_Manager(Game1 game_1) : base (game_1)
        {

        }

        public override void Update()
        {

            for (int i = 0; i < cannonball_towers.Count; i++)
            {
                cannonball_towers[i].Find_Closest_Target(enemies);

                if (cannonball_towers[i].Target_in_range(cannonball_towers[i].Target_position))
                {
                    Strong_Bullet b = new Strong_Bullet(cannonball_towers[i].Position, Content_Manager.purple_tex, cannonball_towers[i].Target_position);

                    strong_bullets.Add(b);
                }

            }

            foreach (var b in strong_bullets)
            {
                b.Update(Gameplay_Manager.draw_offset_x, Gameplay_Manager.draw_offset_y);

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (b.Has_Collided(enemies[i]))
                        b.dead = true;
                }

                if (b.dead)
                {
                    strong_bullets.Remove(b);

                    break;
                }
            }

            foreach (var b in weak_bullets)
            {
                b.Update(Gameplay_Manager.draw_offset_x, Gameplay_Manager.draw_offset_y);

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (b.Has_Collided(enemies[i]))
                        b.dead = true;
                }

                if (b.dead)
                {
                    weak_bullets.Remove(b);

                    break;
                }
            }

            base.Update();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sprite_batch)
        {
            base.Draw(sprite_batch);
        }
    }
}
