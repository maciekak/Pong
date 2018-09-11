using System.Collections.Generic;
using System.Threading;
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
            window.SetKeyRepeatEnabled(false);

            var ball = new Ball(new Vector2i(200, 200), new Vector2i(5, 5));
            var leftPaddle = new Paddle(new Vector2i(30, 200));
            var rightPaddle = new Paddle(new Vector2i(Configuration.WindowWidth - 50, 200));
            var paddles = new List<Paddle> {leftPaddle, rightPaddle};

            window.KeyPressed += (sender, args) =>
            {
                switch (args.Code)
                {
                    case Keyboard.Key.Q:
                        leftPaddle.MoveUp();
                        break;
                    case Keyboard.Key.A:
                        leftPaddle.MoveDown();
                        break;
                }

                switch (args.Code)
                {
                    case Keyboard.Key.O:
                        rightPaddle.MoveUp();
                        break;
                    case Keyboard.Key.L:
                        rightPaddle.MoveDown();
                        break;
                }
            };
            window.KeyReleased += (sender, args) =>
            {
                switch (args.Code)
                {
                    case Keyboard.Key.Q:
                        leftPaddle.StopMovingUp();
                        break;
                    case Keyboard.Key.A:
                        leftPaddle.StopMovingDown();
                        break;
                }

                switch (args.Code)
                {
                    case Keyboard.Key.O:
                        rightPaddle.StopMovingUp();
                        break;
                    case Keyboard.Key.L:
                        rightPaddle.StopMovingDown();
                        break;
                }
            };

            window.SetActive();
            while (window.IsOpen)
            {
                window.Closed += (sender, args) =>
                {
                    window.Close();
                };
                window.Clear();

                ball.CheckForCollision(paddles);

                ball.Update();
                paddles.ForEach(p => p.Update());
                
                window.DispatchEvents();
                window.Draw(ball);
                paddles.ForEach(p => window.Draw(p));
                window.Display();
                Thread.Sleep(1000/60);
            }
        }
    }
}
