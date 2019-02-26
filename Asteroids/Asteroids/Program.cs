using System;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form
            {
               
                    Width = Screen.PrimaryScreen.Bounds.Width,
                    Height = Screen.PrimaryScreen.Bounds.Height
            };
            try
            {
                Game.Init(form);
            }
            catch (ArgumentOutOfRangeException e)
            {
                form.Width = 800;
                form.Height = 600;
                Game.Init(form);
            }

            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
