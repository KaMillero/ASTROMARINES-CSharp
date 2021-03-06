﻿using ASTROMARINES.Other;
using ASTROMARINES.Properties;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ASTROMARINES.Levels
{
    internal class SimpleTextScreen : ILevel
    {
        private readonly Clock clock;
        private readonly Font font;
        private readonly Text text;

        public SimpleTextScreen(string displayedText)
        {
            clock = new Clock();
            font = new Font(Resources.FontMainGameFont);
            text = new Text(displayedText, font);
            var textBoundingBox = text.GetLocalBounds();
            text.Origin = new Vector2f(textBoundingBox.Left + textBoundingBox.Width / 2,
                                       textBoundingBox.Top + textBoundingBox.Height / 2);
            text.Position = new Vector2f(WindowProperties.WindowWidth / 2, WindowProperties.WindowHeight / 2);
            text.Color = new Color(Color.White);
        }

        public bool HasLevelEnded { get; private set; }

        public void Dispose()
        {
            font.Dispose();
            text.Dispose();
            clock.Dispose();
        }

        public void Draw(RenderWindow window)
        {
            window.Clear(Color.Black);
            window.Draw(text);
            window.Display();
        }

        public void LevelLogic(ref RenderWindow window)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && clock.ElapsedTime.AsMilliseconds() > 200)
                HasLevelEnded = true;
            Mouse.SetPosition(new Vector2i((int)WindowProperties.WindowWidth / 2, (int)WindowProperties.WindowHeight / 2), window);
        }
    }
}