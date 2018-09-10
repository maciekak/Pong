using SFML.Graphics;
using SFML.Window;

namespace Pong
{
    static class Program
    {
        static void Main()
        {
            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "test");
            CircleShape cs = new CircleShape(100.0f);
            cs.FillColor = Color.Green;
            window.SetActive();
            while (window.IsOpen)
            {
                window.Closed += (sender, args) =>
                {
                    window.Close();
                };
                window.Clear();
                window.DispatchEvents();
                window.Draw(cs);
                window.Display();
            }
        }
    }
}
