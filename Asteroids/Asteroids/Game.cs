using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public static class Game
    {
        private static BaseObject[] _objects;
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
            var timer = new Timer{Interval = 100};
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, System.EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            _objects = new BaseObject[30];
            for (int i = 0; i < _objects.Length; i++)
            {
                _objects[i] = new BaseObject(new Point(600, i*20),new Point(15-i,15-i), new Size(20,20)  );
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100,100,200,200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100,100,200,200));
            Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (var baseObject in _objects)
            {
                baseObject.Draw();
            }
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var baseObject in _objects)
            {
                baseObject.Update();
            }
        }
    }
}
