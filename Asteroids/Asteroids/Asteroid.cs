using System.Drawing;

namespace Asteroids
{
    public class Asteroid: BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
           Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Reborn()
        {
            base.Reborn();
            Pos.X = Game.Width;
        }
    }
}
