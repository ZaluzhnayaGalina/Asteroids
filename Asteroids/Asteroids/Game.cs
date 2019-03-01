using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    public static class Game
    {
        private static int _count = 300;
        private static BaseObject[] _objects;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static int _asteroidCount=5;
        public static int Width { get; set; }
        public static int Height { get; set; }

        private static LogDelegate _logDelegate;
        public static void Init(Form form, LogDelegate logDelegate)
        {
            _context = BufferedGraphicsManager.Current;
            var g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            var timer = new Timer{Interval = 100};
            timer.Start();
            _logDelegate = logDelegate;
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
            _asteroids = new Asteroid[_asteroidCount];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(8,2));

            var rand = new Random();
            for (int i = 0; i < _objects.Length; i++)
            {
                if (i % 2 == 0)
                    _objects[i] = new Star(new Point(rand.Next(Width),rand.Next(Height)), new Point(15 ,0), new Size(7,7));
                else
                _objects[i] = new Star(new Point(rand.Next(Width), rand.Next(Height)), new Point(5, 0), new Size(5, 5));
                
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rand.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(Width, rand.Next(0, Height)), new Point(-r / 5, r), new Size(r, r));
            }

        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var baseObject in _objects)
            {
                baseObject.Draw();
            }
            foreach (var asteroid in _asteroids)
            {
                asteroid.Draw();
            }
            _bullet.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var baseObject in _objects)
            {
                baseObject.Update();
            }

            _bullet.Update();
            foreach (var asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {
                    _bullet.Reborn();
                    asteroid.Reborn();
                    System.Media.SystemSounds.Hand.Play();
                }
                    
            }
        }
    }
}
