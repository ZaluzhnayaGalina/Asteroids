using System.Drawing;

namespace Asteroids
{
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rectangle { get; }
    }
}
