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
            

            //while (true)
            //{
            //    Console.ReadKey();
            //}
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
