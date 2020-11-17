using System;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;
using EventHook;
using WindowsInput;

namespace Caffeine2
{
    class Program
    {
        #region Config Properties
        private static TimeSpan KeyPressInterval = new TimeSpan(0,0,11);
        #endregion
        public static ASCIIKeys KeyToPress { get; set; } = ASCIIKeys.VK_F15;
        public static DateTime LastKeyPressEvent { get; set; } = DateTime.Now;

        private static KeyboardWatcher keyboardWatcher;
        private static readonly System.Timers.Timer CaffeineTimer = new System.Timers.Timer();
        static void Main(string[] args)
        {
            keyboardWatcher = new EventHookFactory().GetKeyboardWatcher();
            keyboardWatcher.Start();
            keyboardWatcher.OnKeyInput += GlobalKeyEvents;

            CaffeineTimer.Elapsed += CaffeineTimer_Elapsed;
            CaffeineTimer.Interval = new TimeSpan(0,0,1).TotalMilliseconds;
            CaffeineTimer.Start();

            while (true)
            {
                Console.ReadKey();
            }
        }

        static void GlobalKeyEvents(object sender, KeyInputEventArgs e)
        {
            LastKeyPressEvent = DateTime.Now;
            Debug.Print("Keypress: " + e.KeyData.Keyname);
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
            if ((DateTime.Now - LastKeyPressEvent).TotalSeconds >= KeyPressInterval.TotalSeconds)
            {
                SendKey();
                LastKeyPressEvent = DateTime.Now;
            }
        }

        static void SendKey()
        {
            string hexStr = "0x" + ((int)KeyToPress).ToString("X"); //Build Hexstring for selected ASCII-Key enum
            //AutoIt.AutoItX.Send("{ASC " + hexStr + "}");
            WindowsInput.InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.F15);
        }
    }
}
