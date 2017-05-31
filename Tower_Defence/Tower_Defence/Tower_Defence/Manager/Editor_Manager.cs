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
    class Editor_Manager : Gameplay_Manager
    {
        public Editor_Manager(Game1 game_1) : base (game_1)
        {
            this.game_1 = game_1;

            tile = new Tile(Point.Zero, clear_tex);
        }

        public override void Update(GameTime game_time)
        {
            Load_Editor_Hud_Tiles();

            Tile_Editor();

            if (Input.Key_Pressed(Keys.LeftControl) && Input.Key_Click(Keys.M))
                Save_Map();

            if (Input.Key_Pressed(Keys.LeftControl) && Input.Key_Click(Keys.O))
            {
                Load_Map();
                Load_Waypoint();
            }

            base.Update(game_time);

            tile.Update(ZERO, ZERO);
        }

        public override void Draw(SpriteBatch sprite_batch)
        {
            if (!hud.Play_Rectangle.Contains(Input.mouse_position))
                tile.Draw(sprite_batch);

            base.Draw(sprite_batch);

            if (hud.Play_Rectangle.Contains(Input.mouse_position))
                tile.Draw(sprite_batch);
        }

        public void Tile_Editor()
        {
            Editor_input();
        }

        public void Editor_input()
        {
            if (Input.Left_Click())
            {
                foreach (Tile t in hud_tiles)
                    if (t.Is_selected())
                        tile.texture = t.texture;

                foreach (Waypoint w in hud_waypoints)
                    if (w.Is_selected())
                        tile.texture = w.texture;

            }

            if (Input.Left_Press() && hud.Play_Rectangle.Contains(Input.mouse_position) && tile.texture != waypoint.texture)
            {
                foreach (Tile t in map_tiles)
                    if (t.Is_selected())
                    {
                        map_tiles.Remove(t);

                        break;
                    }

                map_tiles.Add(new Tile(new Point((int)screen_position.X - draw_offset_x, (int)screen_position.Y - draw_offset_y), tile.texture));
            }

            else if (Input.Left_Press() && hud.Play_Rectangle.Contains(Input.mouse_position) && tile.texture == waypoint.texture)
            {

                foreach (var w in map_waypoints)
                    if (w.Is_selected())
                    {
                        map_waypoints.Remove(w);
                        break;
                    }

                map_waypoints.Add(new Waypoint(new Point((int)screen_position.X - draw_offset_x, (int)screen_position.Y - draw_offset_y), target_tex));
            }

            if (Input.Right_Press())
            {
                foreach (Tile t in map_tiles)
                {
                    if (t.Is_selected() && tile.texture != waypoint.texture)
                    {
                        map_tiles.Remove(t);
                        break;
                    }
                }

                foreach (var w in map_waypoints)
                {
                    if (w.Is_selected() && tile.texture == waypoint.texture)
                    {
                        map_waypoints.Remove(w);
                        break;
                    }
                }

            }

            if (Input.Key_Click(Keys.C))
            {
                map_tiles.Clear();
                waypoints.Clear();
            }

        }

        public void Save_Map()
        {
            stream_writer = new StreamWriter(@"tile_position.txt", false);
            
            foreach (Tile t in map_tiles)
                stream_writer.WriteLine(t.ToString());

            stream_writer.Close();

            Save_Waypoints();
        }

        public void Save_Waypoints()
        {
            stream_writer = new StreamWriter(@"waypoint_position.txt", false);

            foreach (var w in map_waypoints)
                stream_writer.WriteLine(w.ToString());

            stream_writer.Close();
        }
    }
}
