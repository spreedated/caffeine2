using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Caffeine2
{
    class Program
    {
        static void Main(string[] args)
        {
            //_ = new CaffeineEngine();

            System.Windows.Forms.ContextMenuStrip cxt = new System.Windows.Forms.ContextMenuStrip();
            System.Windows.Forms.ToolStripMenuItem o = new ToolStripMenuItem();
            o.Text = "Hello";
            o.Size = new System.Drawing.Size(182,48);
            cxt.Items.Add(o);
            

            System.Windows.Forms.NotifyIcon k = new System.Windows.Forms.NotifyIcon();
            k.Icon = Properties.Resources.computer_78938;
            k.ContextMenuStrip = cxt;
            k.Click += (x,y) => { Debug.Print("Works"); };
            k.Visible = true;
            k.Text = "Caffeine2";
            //k.BalloonTipText = "Loaded...";
            //k.BalloonTipTitle = "Caffeine2";
            //k.ShowBalloonTip(1);

            Application.Run(); // GUI needs to run in another Thread that's inside the main Thread

            //while (true)
            //{
            //    Console.ReadKey();
            //}
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
