using System;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;
using EventHook;
using WindowsInput;
using WindowsInput.Native;

namespace Caffeine2
{
    class Program
    {
        #region Config Properties
        private static TimeSpan KeyPressInterval = new TimeSpan(0,0,11);
        #endregion
        public static VirtualKeyCode KeyToPress { get; set; } = VirtualKeyCode.F23;
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
            WindowsInput.InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(KeyToPress);
            Debug.Print("Keypress sent: " + KeyToPress.ToString());
            
        }
    }
}
