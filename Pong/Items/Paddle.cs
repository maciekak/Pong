using System.Reflection.Emit;
using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Paddle : Drawable, ICanUpdate
    {
        private const int Speed = 5;

        public const int Height = Configuration.WindowHeight / Configuration.RelPaddleHeight;
        public const int Width = Configuration.WindowWidth / Configuration.RelPaddleWidth;

        public Vector2i Position;
        private int _speedVector;

        public Paddle(Vector2i position)
        {
            Position = position;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(Width, Height))
            {
                FillColor = new Color(Color.White),
                Position = new Vector2f(Position.X, Position.Y)
            };
            target.Draw(rect, states);
        }

        public void Update()
        {
            if (Position.Y < 0 || Position.Y + _speedVector < 0
                               || Position.Y + Height > Configuration.WindowHeight
                               || Position.Y + Height + _speedVector > Configuration.WindowHeight)
            {
                return;
            }

            Position = new Vector2i(Position.X, Position.Y + _speedVector);
        }

        public void MoveUp()
        {
            _speedVector = -Speed;
        }

        public void MoveDown()
        {
            _speedVector = Speed;
        }

        public void StopMovingUp()
        {
            if (_speedVector < 0)
                _speedVector = 0;
        }

        public void StopMovingDown()
        {
            if (_speedVector > 0)
                _speedVector = 0;
        }
    }
}
