
namespace Caffeine2
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "xx",
            "Seconds between keys"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "-startoff",
            "Start inactive"}, -1);
            this.BTN_Ok = new System.Windows.Forms.Button();
            this.PBX_Logo = new System.Windows.Forms.PictureBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.LBL_Version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_Cli = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LBL_Copyright = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Ok
            // 
            this.BTN_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Ok.Location = new System.Drawing.Point(151, 528);
            this.BTN_Ok.Name = "BTN_Ok";
            this.BTN_Ok.Size = new System.Drawing.Size(75, 23);
            this.BTN_Ok.TabIndex = 0;
            this.BTN_Ok.Text = "&Cool!";
            this.BTN_Ok.UseVisualStyleBackColor = true;
            this.BTN_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // PBX_Logo
            // 
            this.PBX_Logo.Image = global::Caffeine2.Properties.Resources.logo1;
            this.PBX_Logo.Location = new System.Drawing.Point(32, 12);
            this.PBX_Logo.Name = "PBX_Logo";
            this.PBX_Logo.Size = new System.Drawing.Size(101, 74);
            this.PBX_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBX_Logo.TabIndex = 1;
            this.PBX_Logo.TabStop = false;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.Location = new System.Drawing.Point(138, 19);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(61, 13);
            this.LBL_Title.TabIndex = 2;
            this.LBL_Title.Text = "Caffeine2";
            // 
            // LBL_Version
            // 
            this.LBL_Version.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Version.Location = new System.Drawing.Point(205, 19);
            this.LBL_Version.Name = "LBL_Version";
            this.LBL_Version.Size = new System.Drawing.Size(157, 13);
            this.LBL_Version.TabIndex = 3;
            this.LBL_Version.Text = "########################";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(138, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Prevents your PC from sleeping, locking, \r\nactivating screensaver or being afk in" +
    " messanger.\r\n";
            // 
            // LBL_Cli
            // 
            this.LBL_Cli.AutoSize = true;
            this.LBL_Cli.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Cli.Location = new System.Drawing.Point(12, 108);
            this.LBL_Cli.Name = "LBL_Cli";
            this.LBL_Cli.Size = new System.Drawing.Size(133, 13);
            this.LBL_Cli.TabIndex = 5;
            this.LBL_Cli.Text = "Command line options:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(12, 124);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(350, 314);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Parameter";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 378;
            // 
            // LBL_Copyright
            // 
            this.LBL_Copyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Copyright.Location = new System.Drawing.Point(12, 441);
            this.LBL_Copyright.Name = "LBL_Copyright";
            this.LBL_Copyright.Size = new System.Drawing.Size(350, 84);
            this.LBL_Copyright.TabIndex = 7;
            this.LBL_Copyright.Text = "Caffeine2 is written by Markus Wackermann 2020\r\nGraphics drawn by Markus Wackerma" +
    "nn 2020\r\n\r\nCaffeine2 is inspired from Caffeine\r\nby Tom Revell\r\n";
            this.LBL_Copyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(100, 506);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(178, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.zhornsoftware.co.uk/caffeine/";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 563);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.LBL_Copyright);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LBL_Cli);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_Version);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.PBX_Logo);
            this.Controls.Add(this.BTN_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Ok;
        private System.Windows.Forms.PictureBox PBX_Logo;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Label LBL_Version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_Cli;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label LBL_Copyright;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}