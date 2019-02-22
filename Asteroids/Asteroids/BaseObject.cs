using System.Drawing;

namespace Asteroids
{
    public class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0 || Pos.X>Game.Width)
                Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height)
                Dir.Y = -Dir.Y;
        }

    }
}
