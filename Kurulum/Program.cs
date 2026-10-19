using System;
using System.Windows.Forms;

namespace Kurulum
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new KurulumForm());
        }
    }
}
