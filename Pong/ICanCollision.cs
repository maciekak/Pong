using System.Collections;
using System.Collections.Generic;
using Pong.Items;

namespace Pong
{
    public interface ICanCollision
    {
        void CheckForCollision(IEnumerable<Paddle> paddles);
    }
}
