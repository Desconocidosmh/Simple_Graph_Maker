﻿using SFML.Graphics;
using SFML.Window;

namespace Graph.Window
{
    public abstract class BaseWindow
    {
        protected const int DEFAULT_FOV = 100;

        protected readonly RenderWindow Window;

        /// <summary>
        /// This color will be drawn as background
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Resolution of this window
        /// </summary>
        public Vector2u Resolution => Window.Size;

        /// <param name="width">Width of the window in pixels</param>
        /// <param name="heigth">Heigth of the window in pixels</param>
        /// <param name="name">Name of the window</param>
        /// <param name="backgroundColor">This color will be displayed in the background</param>
        public BaseWindow(uint width, uint heigth, string name, Color backgroundColor)
        {
            Window = new RenderWindow(
                new VideoMode(width, heigth),
                name, Styles.None);
            Window.SetView(new View(
                new Vector2f(0, 0),
                new Vector2f(DEFAULT_FOV * 2, DEFAULT_FOV * 2))); // Translate point (0, 0) to the middle of the screen and apply fov (times 2 because both sides)
            BackgroundColor = backgroundColor;
        }

        protected abstract void DrawBackground(RenderTarget target);

        protected abstract void DrawForeground(RenderTarget target);

        public void Refresh()
        {
            Window.Clear(BackgroundColor);

            DrawBackground(Window);
            DrawForeground(Window);

            Window.Display();
        }
    }
}