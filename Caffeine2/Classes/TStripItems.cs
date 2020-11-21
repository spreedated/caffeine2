using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffeine2;
using System.Windows.Forms;
using System.Reflection;

public static class TStripItems
{
    /// <summary>
    /// List of Items that will be converted to ContextMenu
    /// </summary>
    public static List<TStripItem> stripItems = new List<TStripItem>() {
        new TStripItem()
        {
            Text = "Statistics:",
            Enabled = false
        },
        new TStripItem()
        {
            Name = "OverallKeyPresses",
            Enabled = false
        },
        new TStripItem()
        {
            Name = "KeyPressesInRun",
            Enabled = false
        },
        new TStripItem()
        {
            Name = "NextKeyPress",
            InitialAction = (object sender, EventArgs e)=> {
                nextKeyPressTimer.Enabled = true;
                nextKeyPressTimer.Interval = 1000;
                nextKeyPressTimer.Tick += NextKeyPressTimer_Tick;
                nextKeyPressTimer.Start();
            },
            Enabled = false
        },
        new TStripItem()
        {
            IsSeperator = true
        },
        new TStripItem()
        {
            Text = "&About",
            Action = (object sender, EventArgs e)=> { new About().ShowDialog(); }
        },
        new TStripItem()
        {
            IsSeperator = true
        },
        new TStripItem()
        {
            Text = "A&ctive",
            Action = (object sender, EventArgs e)=> {
                ToolStripMenuItem acc = (ToolStripMenuItem)sender;
                if (Program.engine == null)
                {
                    acc.Enabled = false;
                    return;
                }
                if (Program.engine.IsActive)
                {
                    Program.engine.Stop();
                }
                else
                {
                    Program.engine.Start();
                }
                acc.Checked = Program.engine.IsActive;
                Program.NotifyIcon.Icon = Program.engine.IsActive? Caffeine2.Properties.Resources.icon_full: Caffeine2.Properties.Resources.icon_empty;
            },
            InitialAction = (object sender, EventArgs e) => { 
                ToolStripMenuItem acc = (ToolStripMenuItem)sender; 
                acc.Checked = Program.engine.IsActive; 
            }
        },
        new TStripItem()
        {
            IsSeperator = true
        },
        new TStripItem()
        {
            Text = "E&xit",
            Action = (object sender, EventArgs e)=> { Program.EndApplication(); }
        }
    };

    /// <summary>
    /// 
    /// </summary>
    private static readonly Timer nextKeyPressTimer = new Timer();
    private static void NextKeyPressTimer_Tick(object sender, EventArgs e)
    {
        ToolStripMenuItem[] bac = new ToolStripMenuItem[3];

        bac[0] = Program.Cxt.Items.OfType<ToolStripMenuItem>().Where(x => x.Name == "NextKeyPress").FirstOrDefault();
        bac[1] = Program.Cxt.Items.OfType<ToolStripMenuItem>().Where(x => x.Name == "OverallKeyPresses").FirstOrDefault();
        bac[2] = Program.Cxt.Items.OfType<ToolStripMenuItem>().Where(x => x.Name == "KeyPressesInRun").FirstOrDefault();

        if (Program.engine.IsActive && bac.Where(x=>x == null).Count() == 0)
        {
            bac[0].Text = Program.engine.KeyToPress.ToString() + " in " +  (Program.engine.KeyPressInterval - DateTime.Now.Subtract(Program.engine.LastKeyPressEvent)).ToString(@"hh\:mm\:ss");
            bac[1].Text = $"Overall presses: {(int)(Program.engine.OverallKeypresses/2)}";
            bac[2].Text = $"Session presses: {(int)(Program.engine.KeypressedInRun/2)}";
        }
        else 
        {
            bac[0].Text = " --- ";
        }
    }

    public static void InitToolStripItems()
    {
        Program.Cxt = new ContextMenuStrip();
        Program.NotifyIcon = new NotifyIcon
        {
            Icon = Program.engine.IsActive? Caffeine2.Properties.Resources.icon_full: Caffeine2.Properties.Resources.icon_empty,
            ContextMenuStrip = Program.Cxt,
            Visible = true,
            Text = Assembly.GetExecutingAssembly().GetName().Name
        };
        
        foreach (TStripItem item in stripItems)
        {
            if (item.IsSeperator)
            {
                Program.Cxt.Items.Add(new ToolStripSeparator());
                continue;
            }
            ToolStripMenuItem o = new ToolStripMenuItem()
            {
                Text = item.Text,
                Checked = item.Checked,
                Name = item.Name,
                Enabled = item.Enabled
            };
            o.Click += item.Action;
            if (item.InitialAction != null)
            {
                item.InitialAction(o,null);
            }
            Program.Cxt.Items.Add(o);
        }
    }
}
