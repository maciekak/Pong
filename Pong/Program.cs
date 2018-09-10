using Pong.Items;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Pong
{
    static class Program
    {
        static void Main()
        {
            var window = new RenderWindow(new VideoMode(Configuration.WindowWidth, Configuration.WindowHeight), "Pong");
            var ball = new Ball(new Vector2i(5, 5));

            window.SetActive();
            while (window.IsOpen)
            {
                window.Closed += (sender, args) =>
                {
                    window.Close();
                };
                window.Clear();
                window.DispatchEvents();
                window.Draw(ball);
                window.Display();
            }
        }
    }
}
