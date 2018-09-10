using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Paddle : Drawable, ICanUpdate
    {
        public const int Height = Configuration.WindowHeight / Configuration.RelPaddleHeight;
        public const int Width = Configuration.WindowWidth / Configuration.RelPaddleWidth;

        public Vector2i Position;
        public int Speed;
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(Width, Height))
            {
                FillColor = new Color(Color.White)
            };
            target.Draw(rect, states);
        }

        public void Update()
        {
            Position = new Vector2i(Position.X, Position.Y + Speed);
        }
    }
}
