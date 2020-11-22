using EventHook;
using System;
using System.Diagnostics;
using System.Timers;
using WindowsInput;
using WindowsInput.Native;
using Caffeine2;

public class CaffeineEngine : IDisposable
{
    #region Config Properties
    public TimeSpan KeyPressInterval { get; set; } = Program.CommandLineOptions.Arguments.Interval ?? new TimeSpan(0, 0, 59);
    #endregion

    #region Publics
    public VirtualKeyCode KeyToPress { get; set; } = Program.CommandLineOptions.Arguments.KeyToPress ?? VirtualKeyCode.F23;
    public DateTime LastKeyPressEvent { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
    public int OverallKeypresses { get; private set; }
    public int KeypressedInRun { get; private set; }
    #endregion

    #region Privates
    private KeyboardWatcher keyboardWatcher;
    private readonly Timer CaffeineTimer = new Timer();
    private readonly InputSimulator inputSimulator = new InputSimulator();
    #endregion

    #region Constructor
    public CaffeineEngine(bool start = true)
    {
        CaffeineTimer.Elapsed += CaffeineTimer_Elapsed;
        CaffeineTimer.Interval = new TimeSpan(0, 0, 1).TotalMilliseconds;

        if (start)
        {
            this.Start();
        }
        Debug.Print("Caffeine engine instance running");
    }
    #endregion
    #region Events
    private void GlobalKeyEvents(object sender, KeyInputEventArgs e)
    {
        LastKeyPressEvent = DateTime.Now;
        Debug.Print("Keypress: " + e.KeyData.Keyname);
        Enum.TryParse<VirtualKeyCode>(e.KeyData.Keyname, out VirtualKeyCode acc);

        if (this.KeyToPress == acc)
        {
            this.OverallKeypresses++;
            this.KeypressedInRun++;
        }
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
    public void Start()
    {
        if (!this.CaffeineTimer.Enabled)
        {
            this.keyboardWatcher = new EventHookFactory().GetKeyboardWatcher(); // Need to be re-instance, start after stop doesnt work
            this.keyboardWatcher.OnKeyInput += GlobalKeyEvents;
            this.keyboardWatcher.Start();
            this.CaffeineTimer.Enabled = true;
            this.CaffeineTimer.Start();
            this.IsActive = true;
            this.KeypressedInRun = 0;
        }
        Debug.Print("Caffeine started :)");
    }

    public void Stop()
    {
        if (this.CaffeineTimer.Enabled)
        {
            this.keyboardWatcher.Stop();
            this.keyboardWatcher.OnKeyInput -= GlobalKeyEvents;
            this.CaffeineTimer.Enabled = false;
            this.CaffeineTimer.Stop();
            this.IsActive = false;
        }
        Debug.Print("Caffeine stopped");
    }

    public void Dispose()
    {
        //Soft release
        this.Stop();
        //Call disposes
        this.CaffeineTimer.Dispose();
        Debug.Print("Caffeine engine disposed");
    }
}
