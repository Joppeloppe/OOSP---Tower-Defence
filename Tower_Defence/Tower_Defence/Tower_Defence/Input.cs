using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Tower_Defence
{
    static class Input
    {
        public static KeyboardState keyboard_state, old_keyboard_state = Keyboard.GetState();
        public static KeyboardState keyState, oldKeyState = Keyboard.GetState();

        public static MouseState mouseState, oldMouseState = Mouse.GetState();

        public static Point mouse_position, old_mouse_position;

        public static bool Key_Click(Keys key)
        {
            return keyboard_state.IsKeyUp(key) && old_keyboard_state.IsKeyDown(key);
        }

        public static bool Key_Pressed(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool Left_Click()
        {
            return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }

        public static bool Left_Press()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool Right_Click()
        {
            return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
        }

        public static bool Right_Press()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }

        public static bool Middle_Click()
        {
            return mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released;
        }

        public static bool Middle_Press()
        {
            return mouseState.MiddleButton == ButtonState.Pressed;
        }

        public static void Update()
        {
            old_keyboard_state = keyboard_state;
            keyboard_state = Keyboard.GetState();

            mouse_position = new Point(mouseState.X, mouseState.Y);
            old_mouse_position = new Point(oldMouseState.X, oldMouseState.Y);

            oldKeyState = keyState;
            keyState = Keyboard.GetState();

            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
    }
}
