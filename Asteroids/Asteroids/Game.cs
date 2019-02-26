using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public static class Game
    {
        private static int _count = 300;
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

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            _objects = new BaseObject[_count];
            var rand = new Random();
            for (int i = 0; i < _objects.Length-1; i++)
            {
                if (i % 50 == 0)
                    _objects[i] = new Ellipse(new Point(rand.Next(Width),rand.Next(Height)), new Point(15 - rand.Next(14), 15 - rand.Next(14)), new Size(10, 10));
                else
                _objects[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(5, 0), new Size(5, 5));
                
            }
            _objects[_count - 1] = new Ufo(new Point(10, Height / 2-150), new Point(0, 0), new Size(0,0));
        }

        public static void Draw()
        {
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
