using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Caffeine2
{
    public partial class About : Form
    {
        #region Disable X
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        #endregion

        private readonly Timer aniTimerDelay = new Timer();
        private readonly Timer aniTimer = new Timer();
        private int pos;
        private bool direction;

        public About()
        {
            InitializeComponent();

            aniTimer.Tick += AniTimer_Tick;
            aniTimer.Interval = 250;

            aniTimerDelay.Tick += AniTimerDelay_Tick;
            aniTimerDelay.Enabled = true;
            aniTimerDelay.Interval = (int)new TimeSpan(0, 0, 3).TotalMilliseconds;
            aniTimerDelay.Start();
        }

        private void AniTimerDelay_Tick(object sender, EventArgs e)
        {
            aniTimerDelay.Stop();
            aniTimerDelay.Enabled = false;
            aniTimerDelay.Dispose();
            aniTimer.Enabled = true;
            aniTimer.Start();
        }
        private void AniTimer_Tick(object sender, EventArgs e)
        {
            PBX_Logo.Image.Dispose(); // Prevent memory leak
            switch (pos)
            {
                case 0:
                    PBX_Logo.Image = Properties.Resources.logo_empty;
                    break;
                case 1:
                    PBX_Logo.Image = Properties.Resources.logo_10;
                    break;
                case 2:
                    PBX_Logo.Image = Properties.Resources.logo_20;
                    break;
                case 3:
                    PBX_Logo.Image = Properties.Resources.logo_30;
                    break;
                case 4:
                    PBX_Logo.Image = Properties.Resources.logo_40;
                    break;
                case 5:
                    PBX_Logo.Image = Properties.Resources.logo_50;
                    break;
                case 6:
                    PBX_Logo.Image = Properties.Resources.logo_60;
                    break;
                case 7:
                    PBX_Logo.Image = Properties.Resources.logo_70;
                    break;
                case 8:
                    PBX_Logo.Image = Properties.Resources.logo_80;
                    break;
                case 9:
                    PBX_Logo.Image = Properties.Resources.logo_90;
                    break;
            }
            if (direction)
            {
                pos++;
            }
            else
            {
                --pos;
            }
            if (pos >= 10 || pos <= -1)
            {
                direction ^= true; // Hope you raised your eyebrows, this toggles a boolean "direction = !direction;" is just lame
            }
        }

        private void About_Load(object sender, EventArgs e)
        {
            LBL_Version.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Icon = Properties.Resources.logo;

            // Read arguments and helptext from CLI_Args and convert their attribues (if has one) to text
            CLI_Args.Arguments.GetType().GetProperties().ToList().ForEach(y =>
            {
                if (y.CustomAttributes.Count() <= 0)
                {
                    return;
                }
                ListViewItem acc = new ListViewItem()
                {
                    Text = "-" + Convert.ToString(y.CustomAttributes.ToList()[0].ConstructorArguments[0].Value)
                };
                acc.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "--" + (string)y.CustomAttributes.ToList()[0].ConstructorArguments[1].Value });
                acc.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (string)y.CustomAttributes.ToList()[0].NamedArguments.Where(x => x.MemberName == "HelpText").FirstOrDefault().TypedValue.Value });
                LSV_Arguments.Items.Add(acc);
            });
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            aniTimer.Dispose(); // Prevent memory leak
            aniTimerDelay.Dispose(); // Prevent memory leak
            PBX_Logo.Dispose(); // Prevent memory leak
            this.Dispose();
        }
    }
}
