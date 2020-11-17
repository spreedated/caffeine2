using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using EventHook;
using WindowsInput;
using WindowsInput.Native;

public class CaffeineEngine : IDisposable
{
    #region Config Properties
    private TimeSpan KeyPressInterval = new TimeSpan(0, 0, 59);
    #endregion
    #region Publics
    public VirtualKeyCode KeyToPress { get; set; } = VirtualKeyCode.F23;
    public DateTime LastKeyPressEvent { get; set; } = DateTime.Now;
    #endregion

    #region Privates
    private readonly KeyboardWatcher keyboardWatcher;
    private readonly Timer CaffeineTimer = new Timer();
    private readonly InputSimulator inputSimulator = new InputSimulator();
    #endregion

    #region Constructor
    public CaffeineEngine()
    {
        keyboardWatcher = new EventHookFactory().GetKeyboardWatcher();
        keyboardWatcher.Start();
        keyboardWatcher.OnKeyInput += GlobalKeyEvents;

        CaffeineTimer.Elapsed += CaffeineTimer_Elapsed;
        CaffeineTimer.Interval = new TimeSpan(0, 0, 1).TotalMilliseconds;
        CaffeineTimer.Start();
    }
    #endregion
    #region Events
    private void GlobalKeyEvents(object sender, KeyInputEventArgs e)
    {
        LastKeyPressEvent = DateTime.Now;
        Debug.Print("Keypress: " + e.KeyData.Keyname);
    }

    private void CaffeineTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if ((DateTime.Now - LastKeyPressEvent).TotalSeconds >= KeyPressInterval.TotalSeconds)
        {
            SendKey();
            LastKeyPressEvent = DateTime.Now;
        }
    }
    #endregion

    private void SendKey()
    {
        this.inputSimulator.Keyboard.KeyPress(KeyToPress);
        Debug.Print("Keypress sent: " + KeyToPress.ToString());
    }

    public void Dispose()
    {
        if (this.keyboardWatcher != null)
        {
            keyboardWatcher.Stop();
        }
        this.CaffeineTimer.Dispose();
    }
}
