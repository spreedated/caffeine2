using Gma.System.MouseKeyHook;
using System;
using System.Timers;
using System.Windows.Forms;

namespace Caffeine2
{
    class Program
    {
        public static ASCIIKeys KeyToPress { get; set; } = ASCIIKeys.VK_F15;
        public static DateTime LastKeyPressEvent { get; set; }

        private static IKeyboardEvents m_GlobalHook;
        private static readonly System.Timers.Timer CaffeineTimer = new System.Timers.Timer();
        static void Main(string[] args)
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalKeyEvents;
            CaffeineTimer.Elapsed += CaffeineTimer_Elapsed;

            SendKey();

            while (true)
            {
                Console.ReadKey();
            }
        }

        static void GlobalKeyEvents(object sender, KeyPressEventArgs e)
        {
            LastKeyPressEvent = DateTime.Now;
        }

        public enum ASCIIKeys
        {
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87
        }

        static void CaffeineTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now )
            {

            }
        }

        static void SendKey()
        {
            string hexStr = "0x" + ((int)ASCIIKeys.VK_F15).ToString("X"); //Build Hexstring for selected ASCII-Key enum
            AutoIt.AutoItX.Send("{ASC " + hexStr + "}");
        }
    }
}
