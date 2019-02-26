using System.Drawing;

namespace Asteroids
{
    public abstract class BaseObject: ICollision, IRebornable
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        private Point _startPos;
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            _startPos = new Point(pos.X, pos.Y);
        }

        public abstract void Draw();

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
                Pos.X = Game.Width + Size.Width;
            if (Pos.X > Game.Width)
                Pos.X =  Game.Width;

        }

        public bool Collision(ICollision obj)
        {
            return obj.Rectangle.IntersectsWith(Rectangle);
        }

        public Rectangle Rectangle { get=>new Rectangle(Pos, Size); }
        public virtual void Reborn()
        {
            Pos.X = _startPos.X;
            Pos.Y = _startPos.Y;
        }
    }
}
