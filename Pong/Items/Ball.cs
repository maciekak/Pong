using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Ball : Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = new Color(Color.Blue)
            };
            states.Transform.Translate(50, 50);
            target.Draw(rect,states);
        }
    }
}
