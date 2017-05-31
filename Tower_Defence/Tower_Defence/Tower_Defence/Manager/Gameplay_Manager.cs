using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tower_Defence.Game_Object;

namespace Tower_Defence.Manager
{
    class Gameplay_Manager : Content_Manager
    {
        protected Tile tile;
        protected HUD hud;
        protected Waypoint waypoint;

        protected Point screen_position;

        protected RenderTarget2D render_target;

        protected int draw_offset_x, draw_offset_y, money;
        protected const int ZERO = 0;

        protected List<Tile> map_tiles = new List<Tile>();
        protected List<Tile> hud_tiles = new List<Tile>();
        protected List<Enemy> enemies = new List<Enemy>();
        protected List<Tower> towers = new List<Tower>();
        protected List<Bullet> bullets = new List<Bullet>();
        protected List<Particle_engine> particel_engines = new List<Particle_engine>();

        protected List<Waypoint> hud_waypoints = new List<Waypoint>();
        protected List<Waypoint> map_waypoints = new List<Waypoint>();

        protected List<Vector2> waypoints = new List<Vector2>();

        protected int Draw_offset_x
        {
            get { return draw_offset_x; }
            set { draw_offset_x = value; }
        }

        protected int Draw_offset_y
        {
            get { return draw_offset_y; }
            set { draw_offset_y = value; }
        }

        protected int Moeny
        {
            get { return money; }
            set { money = value; }
        }


        protected Point Screen_position
        {
            get { return screen_position; }
            set { screen_position = value; }
        }

        public Gameplay_Manager(Game1 game_1) : base (game_1)
        {
            Load_Test_Content();

            hud = new HUD(Vector2.Zero, game_1);
            waypoint = new Waypoint(Point.Zero, target_tex);
            tile = new Tile(Point.Zero, clear_tex);

            render_target = new RenderTarget2D(game_1.graphics.GraphicsDevice, game_1.graphics.GraphicsDevice.Viewport.Width, game_1.graphics.GraphicsDevice.Viewport.Height);

            money = 500;
        }

        public virtual void Update(GameTime game_time)
        {
            Input.Update();

            Camera_Movement();

            screen_position = new Point(((int)Input.mouse_position.X / tile.texture.Width) * tile.texture.Width,
                ((int)Input.mouse_position.Y / tile.texture.Height) * tile.texture.Height);

            tile.Position = new Point(screen_position.X, screen_position.Y);

            foreach (Tile t in map_tiles)
                t.Update(draw_offset_x, draw_offset_y);

            foreach (Tile t in hud_tiles)
                t.Update(ZERO, ZERO);

            foreach (var w in map_waypoints)
                w.Update(draw_offset_x, draw_offset_y);

            foreach (var t in towers)
                t.Update(Draw_offset_x, Draw_offset_y);

            foreach (var e in particel_engines)
            {
                e.Update(Draw_offset_x, Draw_offset_y);

                if (e.active)
                    e.Timer(game_time);
            }

            foreach (var b in bullets)
            {
                b.Update(draw_offset_x, draw_offset_y);

                if (b.dead)
                {
                    bullets.Remove(b);
                    break;
                }
            }

            foreach (var t in towers)
                t.Update(draw_offset_x, draw_offset_y);

            hud.Update();

            if (Input.Key_Click(Keys.G))
            {
                Enemy e = new Enemy(Vector2.Zero, tower_yellow);

                e.Load_Waypoint();
                e.Set_Waypoints();

                enemies.Add(e);
            }

            foreach (Enemy e in enemies)
            {
                e.Update(draw_offset_x, draw_offset_y);

                if (e.dead)
                {
                    enemies.Remove(e);

                    break;
                }
            }
        }

        public virtual void Draw(SpriteBatch sprite_batch)
        {
            Draw_Render_Target(render_target, game_1.graphics.GraphicsDevice);

            foreach (Tile t in map_tiles)
                t.Draw(sprite_batch);

            foreach (Waypoint w in map_waypoints)
                w.Draw(sprite_batch);

            foreach (var e in enemies)
                e.Draw(sprite_batch);

            hud.Draw(sprite_batch);

            foreach (Tile t in hud_tiles)
                t.Draw(sprite_batch);

            foreach (var w in hud_waypoints)
                w.Draw(sprite_batch);

            sprite_batch.Draw(render_target, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
        }

        public void Load_Editor_Hud_Tiles()
        {
            stream_reader = new StreamReader(@"editor_hud_tile_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                Texture2D tile_tex = Get_Texture(split[2]);

                if (tile_tex.Name == "target_tile")
                    hud_waypoints.Add(new Waypoint(new Point(int.Parse(split[0]) - waypoint.center.X, int.Parse(split[1])), target_tex));

                else
                  hud_tiles.Add(new Tile(new Point(int.Parse(split[0]) - tile.center.X, int.Parse(split[1])), tile_tex));
            }

            stream_reader.Close();
        }

        public void Load_Play_Hud_Tiles()
        {
            stream_reader = new StreamReader(@"play_hud_tile_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                Texture2D tile_tex = Get_Texture(split[2]);
                
                hud_tiles.Add(new Tile(new Point(int.Parse(split[0]) - tile.center.X, int.Parse(split[1])), tile_tex));
            }

            stream_reader.Close();

        }

        public void Load_Map()
        {
            stream_reader = new StreamReader(@"tile_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                Texture2D tile_tex = Get_Texture(split[2]);

                map_tiles.Add(new Tile(new Point(int.Parse(split[0]) - tile.center.X, int.Parse(split[1]) - tile.center.Y), tile_tex));
            }

            stream_reader.Close();
        }

        public void Load_Waypoint()
        {
            stream_reader = new StreamReader(@"waypoint_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                map_waypoints.Add(new Waypoint(new Point(int.Parse(split[0]) - tile.center.X, int.Parse(split[1]) - tile.center.Y), target_tex));
            }

            stream_reader.Close();
        }

        public void Camera_Movement()
        {
            if (Input.Key_Pressed(Keys.A))
                Draw_offset_x += tile.texture.Width;

            if (Input.Key_Pressed(Keys.D))
                Draw_offset_x -= tile.texture.Width;

            if (Input.Key_Pressed(Keys.W))
                Draw_offset_y += tile.texture.Height;

            if (Input.Key_Pressed(Keys.S))
                Draw_offset_y -= tile.texture.Height;

            if (Input.Key_Click(Keys.Space))
            {
                Draw_offset_x = 0;
                Draw_offset_y = 0;
            }


            if (Input.Middle_Press())
            {
                Vector2 direction = new Vector2(Input.old_mouse_position.X - Input.mouse_position.X, Input.old_mouse_position.Y - Input.mouse_position.Y);

                direction.Normalize();

                Draw_offset_x -= (int)direction.X * (tile.texture.Width * 2);
                Draw_offset_y -= (int)direction.Y * (tile.texture.Height * 2);
            }

        }

        private void Draw_Render_Target(RenderTarget2D target, GraphicsDevice gd)
        {
            SpriteBatch s_b = new SpriteBatch(gd);

            Color color = new Color(255, 255, 255, 0.01f);

            gd.SetRenderTarget(target);

            gd.Clear(Color.Transparent);

            s_b.Begin();

            foreach (Tile t in map_tiles)
                t.Draw(s_b);

            foreach (var e in enemies)
                e.Draw(s_b);

            foreach (var t in towers)
                t.Draw(s_b);

            s_b.End();

            gd.SetRenderTarget(null);
        }


    }
}
