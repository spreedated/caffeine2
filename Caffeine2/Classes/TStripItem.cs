using System;

public class TStripItem
{
    public bool IsSeperator { get; set; }
    public string Text { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; } = true;
    public bool Checked { get; set; }
    public EventHandler Action { get; set; }
    /// <summary>
    /// Action call on creation/instance
    /// </summary>
    public EventHandler InitialAction { get; set; }
}
