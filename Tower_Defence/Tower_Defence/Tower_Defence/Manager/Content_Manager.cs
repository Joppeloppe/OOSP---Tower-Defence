using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tower_Defence.Manager
{
    class Content_Manager
    {
        protected Game1 game_1;

        protected StreamWriter stream_writer;
        protected StreamReader stream_reader;

        protected Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        protected Texture2D clear_tex, blue_tex, grey_tex, lime_tex, orange_tex, pink_tex, purple_tex, red_tex, target_tex, tower_blue, tower_green, tower_grey, tower_purple, tower_yellow;
        protected List<Texture2D> particle_textures = new List<Texture2D>();

        protected SpriteFont font;


        public Content_Manager(Game1 game_1)
        {
            this.game_1 = game_1;
        }

        public virtual void Load_Test_Content()
        {
            clear_tex = game_1.Content.Load<Texture2D>(@"Image/Color/clear");

            blue_tex = game_1.Content.Load<Texture2D>(@"Image/Color/blue");
            grey_tex = game_1.Content.Load<Texture2D>(@"Image/Color/grey");
            lime_tex = game_1.Content.Load<Texture2D>(@"Image/Color/lime");
            orange_tex = game_1.Content.Load<Texture2D>(@"Image/Color/orange");
            pink_tex = game_1.Content.Load<Texture2D>(@"Image/Color/pink");
            purple_tex = game_1.Content.Load<Texture2D>(@"Image/Color/purple");
            red_tex = game_1.Content.Load<Texture2D>(@"Image/Color/red");
            target_tex = game_1.Content.Load<Texture2D>(@"Image/Misc/target_tile");

            tower_blue = game_1.Content.Load<Texture2D>(@"Image/Tower/tower_blue");
            tower_green = game_1.Content.Load<Texture2D>(@"Image/Tower/tower_green");
            tower_grey = game_1.Content.Load<Texture2D>(@"Image/Tower/tower_grey"); 
            tower_purple = game_1.Content.Load<Texture2D>(@"Image/Tower/tower_purple");
            tower_yellow = game_1.Content.Load<Texture2D>(@"Image/Tower/tower_yellow");

            blue_tex.Name = "blue_tex";
            grey_tex.Name = "grey_tex";
            lime_tex.Name = "lime_tex";
            orange_tex.Name = "orange_tex";
            pink_tex.Name = "pink_tex";
            purple_tex.Name = "purple_tex";
            red_tex.Name = "red_tex";
            target_tex.Name = "target_tile";

            tower_blue.Name = "tower_blue";
            tower_green.Name = "tower_green";
            tower_grey.Name = "tower_grey";
            tower_purple.Name = "tower_purple";
            tower_yellow.Name = "tower_yellow";
            
            textures.Add(blue_tex.Name, blue_tex);
            textures.Add(grey_tex.Name, grey_tex);
            textures.Add(lime_tex.Name, lime_tex);
            textures.Add(orange_tex.Name, orange_tex);
            textures.Add(pink_tex.Name, pink_tex);
            textures.Add(purple_tex.Name, purple_tex);
            textures.Add(red_tex.Name, red_tex);
            textures.Add(target_tex.Name, target_tex);

            textures.Add(tower_blue.Name, tower_blue);
            textures.Add(tower_green.Name, tower_green);
            textures.Add(tower_grey.Name, tower_grey);
            textures.Add(tower_purple.Name, tower_purple);
            textures.Add(tower_yellow.Name, tower_yellow);

            particle_textures.Add(game_1.Content.Load<Texture2D>(@"Image/Misc/circle"));
            particle_textures.Add(game_1.Content.Load<Texture2D>(@"Image/Misc/star"));
            particle_textures.Add(game_1.Content.Load<Texture2D>(@"Image/Misc/diamond"));

            font = game_1.Content.Load<SpriteFont>(@"Font/Andy");
        }

        public Texture2D Get_Texture(string key)
        {
            if(textures.ContainsKey(key))
            {
                return textures[key];
            }

            return null;
        }
    }
}
