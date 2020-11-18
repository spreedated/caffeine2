using System;

public struct TStripItem
{
    public bool IsSeperator { get; set; }
    public string Text { get; set; }
    public bool Checked { get; set; }
    public EventHandler Action { get; set; }
    /// <summary>
    /// Action call on creation/instance
    /// </summary>
    public EventHandler InitialAction { get; set; }
}
