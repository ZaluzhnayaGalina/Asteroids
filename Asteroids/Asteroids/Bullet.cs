using System.Drawing;

namespace Asteroids
{
    public class Bullet: BaseObject
    {
        private Point _startPos;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _startPos = new Point(pos.X, pos.Y);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            base.Update();
            if (Pos.X > Game.Width)
                Pos.X = _startPos.X;
        }
    }
}
