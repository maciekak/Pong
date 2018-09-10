using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Ball : Drawable, IColli
    {
        private const int BallSize = Configuration.BallHeightWidth;
        private Vector2i Speed;

        public Ball(Vector2i speed)
        {
            Speed = speed;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(BallSize, BallSize))
            {
                FillColor = new Color(Color.White)
            };
            target.Draw(rect, states);
        }


    }
}
