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
            LogDelegate logDelegate = message => Console.WriteLine(message);
            Game.Init(form, logDelegate);


            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
