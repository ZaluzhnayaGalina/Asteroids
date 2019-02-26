using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);            
            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
