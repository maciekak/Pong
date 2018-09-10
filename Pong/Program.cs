using Pong.Items;
using SFML.Graphics;
using SFML.Window;

namespace Pong
{
    static class Program
    {
        static void Main()
        {
            var window = new RenderWindow(new VideoMode(200, 200), "Pong");
            var cs = new CircleShape(100.0f)
            {
                FillColor = Color.Green
            };
            var ball = new Ball();

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
