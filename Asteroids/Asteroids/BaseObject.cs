using System.Drawing;

namespace Asteroids
{
    public abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
                Pos.X = Game.Width + Size.Width;

        }

        public bool Collision(ICollision obj)
        {
            return obj.Rectangle.IntersectsWith(Rectangle);
        }

        public Rectangle Rectangle { get=>new Rectangle(Pos, Size); }
    }
}
