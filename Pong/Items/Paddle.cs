using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Paddle : Drawable
    {
        private const int Height = Configuration.WindowHeight / Configuration.RelPaddleHeight;
        private const int Width = Configuration.WindowWidth / Configuration.RelPaddleWidth;
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(Width, Height))
            {
                FillColor = new Color(Color.White)
            };
            target.Draw(rect, states);
        }
    }
}
