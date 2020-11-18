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
    public static List<TStripItem> stripItems = new List<TStripItem>() {
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

    public static void InitToolStripItems()
    {
        Program.Cxt = new ContextMenuStrip();
        Program.NotifyIcon = new NotifyIcon
        {
            Icon = Caffeine2.Properties.Resources.computer_78938,
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
                Checked = item.Checked
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
