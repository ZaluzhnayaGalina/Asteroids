using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class Ufo : BaseObject
    {
        private Image _image;
        public Ufo(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _image = Image.FromFile("ufo.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, Pos);
        }
        public override void Update()
        {
            
        }
    }
}
