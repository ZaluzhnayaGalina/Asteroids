using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Init(Form form)
        {
            _context = BufferedGraphicsManager.Current;
            var g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100,100,200,200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100,100,200,200));
            Buffer.Render();
        }
    }
}
