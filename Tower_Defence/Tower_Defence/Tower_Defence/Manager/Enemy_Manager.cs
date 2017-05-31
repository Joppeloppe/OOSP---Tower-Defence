using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tower_Defence.Game_Object;

namespace Tower_Defence.Manager
{
    class Enemy_Manager
    {
        StreamReader stream_reader;

        public void Update()
        {
            if (Input.Key_Click(Keys.G))
            {
                Enemy e = new Enemy(Vector2.Zero, Content_Manager.red_tex);

                e.Load_Waypoint();
                e.Set_Waypoints();
            }
        }

        public void Load_Waypoint()
        {
            stream_reader = new StreamReader(@"waypoint_position.txt");

            while (!stream_reader.EndOfStream)
            {
                string[] split = stream_reader.ReadLine().Split(';');

                Gameplay_Manager.map_waypoints.Add(new Waypoint(new Point(int.Parse(split[0]) - Gameplay_Manager.tile.center.X, int.Parse(split[1]) - Gameplay_Manager.tile.center.Y), Content_Manager.target_tex));
            }

            stream_reader.Close();
        }

        
    }
}
