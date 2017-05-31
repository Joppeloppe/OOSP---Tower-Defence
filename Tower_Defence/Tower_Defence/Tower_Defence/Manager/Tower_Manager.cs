using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_Defence.Game_Object;

namespace Tower_Defence.Manager
{
    class Tower_Manager : Gameplay_Manager
    {
        public int timer_elapsed_time, elapsed_time;
        public int time_interval = 50;
        public int duration;
        public int spawn_delay = 1;

        bool spawn_enemy;

        public Tower_Manager(Game1 game_1) : base(game_1)
        {
            duration = 60 / spawn_delay;
        }

        public override void Update(GameTime game_time)
        {
            //NYTT
            elapsed_time += (int)game_time.ElapsedGameTime.TotalMilliseconds;

            if (elapsed_time >= 15000)
            {
                spawn_delay++;
                elapsed_time = 0;
            }

            Spawn_Enemies(game_time);

            if(spawn_enemy)
            {
                Enemy e = new Enemy(Vector2.Zero, tower_yellow);

                e.Load_Waypoint();
                e.Set_Waypoints();

                enemies.Add(e);

                spawn_enemy = false;
            }
            //GAMMALT

            if (enemies.Count > 0)
                for (int i = 0; i < towers.Count; i++)
                {
                    towers[i].Find_Closest_Target(enemies);

                    if (towers[i].Target_in_range(enemies[towers[i].Nearest_object].Position))
                    {
                        Bullet b = new Bullet(towers[i].position, purple_tex);

                        b.Nearest_object = towers[i].Nearest_object;

                        bullets.Add(b);

                        //Timer(game_time);
                    }
                }


            foreach (var b in bullets)
            {
                if (enemies.Count == 0)
                    b.dead = true;

                else if (enemies.Count != 0 && !enemies[b.Nearest_object].dead)
                {
                    b.Homing(enemies[b.Nearest_object].Position);
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (b.Hits_Enemy(enemies[i]))
                    {
                        money += 10;
                        enemies[i].Life -= b.Damage;

                        b.dead = true;
                    }
                }

                if (b.dead)
                {
                    bullets.Remove(b);

                    break;
                }
            }

            foreach (Enemy e in enemies)
            {
                e.Attack_Object(towers);

                if (e.Life == 0)
                    e.dead = true;
            }

            base.Update(game_time);
        }

        public virtual void Timer(GameTime game_time)
        {
            for (int i = 0; i < towers.Count; i++)
			{

                if (towers[i].Target_in_range(enemies[towers[i].Nearest_object].Position))
                {
                    if (towers[i].Target_in_range(enemies[towers[i].Nearest_object].Position))
                    {
                        timer_elapsed_time += (int)game_time.ElapsedGameTime.TotalSeconds;

                        if (timer_elapsed_time >= time_interval)
                        {
                            --duration;

                            timer_elapsed_time -= time_interval;
                        }
                    } 
                }
            

                if (duration <= 0)
                {
                        towers[i].Find_Closest_Target(enemies);

                        if (towers[i].Target_in_range(enemies[towers[i].Nearest_object].Position))
                        {
                            Bullet b = new Bullet(towers[i].position, purple_tex);

                            b.Direction = towers[i].direction;

                            b.Nearest_object = towers[i].Nearest_object;

                            b.Homing(enemies[b.Nearest_object].Position);

                            bullets.Add(b);
                        }

                    duration = 60;
                }
            }
        }


        //NYTT
        public void Spawn_Enemies(GameTime game_time)
        {
            if (spawn_enemy == false)
            {
                timer_elapsed_time += (int)game_time.ElapsedGameTime.TotalMilliseconds;

                if (timer_elapsed_time > time_interval)
                {
                    timer_elapsed_time -= time_interval;

                    duration--;

                    if (duration <= 0)
                    {
                        spawn_enemy = true;

                        duration = 60 / spawn_delay;
                    }
                } 
            }

        }
    }
}


