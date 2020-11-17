using System;
using System.Diagnostics;

namespace Caffeine2
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new CaffeineEngine();

            System.Windows.Forms.NotifyIcon k = new System.Windows.Forms.NotifyIcon();
            k.Icon = Properties.Resources.computer_78938;
            k.Visible = true;

            System.Windows.Forms.ContextMenu cxt = new System.Windows.Forms.ContextMenu();
            //TODO: ... :)

            //while (true)
            //{
            //    Console.ReadKey();
            //}
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
