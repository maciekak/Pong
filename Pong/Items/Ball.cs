using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Pong.Items
{
    public class Ball : Drawable, ICanUpdate, ICanCollision
    {
        private const int BallSize = Configuration.BallHeightWidth;
        
        private Vector2i _speed;
        public Vector2i Position;

        public Ball(Vector2i speed)
        {
            _speed = speed;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var rect = new RectangleShape(new Vector2f(BallSize, BallSize))
            {
                FillColor = new Color(Color.White)
            };
            target.Draw(rect, states);
        }
        
        public void Update()
        {
            Position += _speed;
        }

        public void CheckForCollision(IEnumerable<Paddle> paddles)
        {
            foreach (var paddle in paddles)
            {
                if (paddle.Position.X > Configuration.WindowWidth / 2)
                {
                    if (CheckRightPaddleCollision(paddle))
                        break;
                }
                else if (CheckLeftPaddleCollision(paddle))
                    break;
            }

            CheckWallsCollision();
        }

        private bool CheckLeftPaddleCollision(Paddle paddle)
        {
            if (_speed.X > 0)
                return false;

            if (!CheckIfOnCorrectHeight(paddle))
                return false;

            var rightSide = paddle.Position.X + Paddle.Width;
            if (rightSide > Position.X || rightSide > Position.X + _speed.X)
                ChangeXDirection();

            return true;
        }

        private bool CheckRightPaddleCollision(Paddle paddle)
        {
            if (_speed.X < 0)
                return false;

            if(!CheckIfOnCorrectHeight(paddle))
                return false;

            var ballLeftSide = Position.X + BallSize;
            if (paddle.Position.X < ballLeftSide || paddle.Position.X < ballLeftSide + _speed.X)
                ChangeXDirection();

            return true;
        }

        private bool CheckIfOnCorrectHeight(Paddle paddle)
        {
            return (paddle.Position.Y > Position.Y + BallSize
                    || paddle.Position.Y > Position.Y + BallSize + _speed.Y)
                   && (paddle.Position.Y + Paddle.Height < Position.Y
                       || paddle.Position.Y + Paddle.Height < Position.Y + _speed.Y);
        }

        private void CheckWallsCollision()
        {
            if (_speed.Y < 0 
                && (Position.Y <= 0 || Position.Y + _speed.Y <= 0))
            {
                ChangeYDirection();
                return;
            }

            if (_speed.Y > 0
                && (Position.Y + BallSize >= Configuration.WindowHeight
                    || Position.Y + BallSize + _speed.Y >= Configuration.WindowHeight))
            {
                ChangeYDirection();
                return;
            }

            if (_speed.X < 0
                && (Position.X <= 0 || Position.X + _speed.X <= 0))
            {
                ChangeXDirection();
                return;
            }

            if (_speed.X > 0
                && (Position.X + BallSize >= Configuration.WindowWidth
                    || Position.X + BallSize + _speed.X >= Configuration.WindowWidth))
            {
                ChangeXDirection();
            }

        }

        private void ChangeXDirection()
        {
            _speed = new Vector2i(_speed.X * -1, _speed.Y);
        }

        private void ChangeYDirection()
        {
            _speed = new Vector2i(_speed.X, _speed.Y * -1);
        }
    }
}
