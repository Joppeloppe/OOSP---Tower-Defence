using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tower_Defence
{
    enum Screen
    {
        Start_Screen,
        Play_Screen,
        Editor_Screen,
        Win_Screen,
        Lost_Screen
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Start_Screen start_screen;
        Play_Screen play_screen;
        Editor_Screen editor_screen;
        Level_Won level_won;
        Level_Lost level_lost;

        Screen current_screen;

        public static int level_numb, window_width, window_height;

        public static int Level_numb
        {
            get { return level_numb; }
            set { level_numb = value; }
        }

        public static int Window_width
        {
            get { return window_width; }
            set { window_width = value; }
        }

        public static int Window_height
        {
            get { return window_height; }
            set { window_height = value; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window_width = 1600;
            Window_height = 896;

            graphics.PreferredBackBufferWidth = Window_width;
            graphics.PreferredBackBufferHeight = Window_height;

            this.Window.Title = "Tower Defence";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            start_screen = new Start_Screen(this);
            current_screen = Screen.Start_Screen;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            switch (current_screen)
            {
                case Screen.Start_Screen:
                    start_screen.Update();
                    break;

                case Screen.Play_Screen:
                    play_screen.Update(gameTime);
                    break;

                case Screen.Editor_Screen:
                    editor_screen.Update(gameTime);
                    break;

                case Screen.Win_Screen:
                    level_won.Update();
                    break;

                case Screen.Lost_Screen:
                    level_lost.Update();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            spriteBatch.Begin();

            switch (current_screen)
            {
                case Screen.Start_Screen:
                    start_screen.Draw(spriteBatch);
                    break;

                case Screen.Play_Screen:
                    play_screen.Draw(spriteBatch);
                    break;

                case Screen.Editor_Screen:
                    editor_screen.Draw(spriteBatch);
                    break;

                case Screen.Win_Screen:
                    level_won.Draw(spriteBatch);
                    break;

                case Screen.Lost_Screen:
                    level_lost.Draw(spriteBatch);
                    break;
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Start_game()
        {
            play_screen = new Play_Screen(this);
            current_screen = Screen.Play_Screen;
        }

        public void Edit_level()
        {
            editor_screen = new Editor_Screen(this);
            current_screen = Screen.Editor_Screen;
        }

        public void Won_level()
        {
            ++level_numb;

            level_won = new Level_Won(this);
            current_screen = Screen.Win_Screen;
        }

        public void Lost_level()
        {
            level_lost = new Level_Lost(this);
            current_screen = Screen.Lost_Screen;
        }
    }
}
