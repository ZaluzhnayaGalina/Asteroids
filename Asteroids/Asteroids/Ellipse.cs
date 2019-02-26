using System.Drawing;

namespace Asteroids
{
    public class Ellipse : BaseObject
    {
        public Ellipse(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width)
                Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height)
                Dir.Y = -Dir.Y;
        }
    }
}
