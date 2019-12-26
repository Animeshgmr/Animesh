namespace GMRTTranscription
{
    partial class MDIForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFilesMenuLink = new System.Windows.Forms.ToolStripMenuItem();
            this.NewVoiceFileMenuLink = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileMenuLink = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutMenuLink = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.myProfileMenuLink,
            this.logOutMenuLink});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1534, 29);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashBoardToolStripMenuItem,
            this.newFilesMenuLink,
            this.NewVoiceFileMenuLink});
            this.masterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // dashBoardToolStripMenuItem
            // 
            this.dashBoardToolStripMenuItem.Name = "dashBoardToolStripMenuItem";
            this.dashBoardToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.dashBoardToolStripMenuItem.Text = "DashBoard";
            this.dashBoardToolStripMenuItem.Click += new System.EventHandler(this.dashBoardToolStripMenuItem_Click);
            // 
            // newFilesMenuLink
            // 
            this.newFilesMenuLink.Name = "newFilesMenuLink";
            this.newFilesMenuLink.Size = new System.Drawing.Size(188, 26);
            this.newFilesMenuLink.Text = "New Files";
            this.newFilesMenuLink.Click += new System.EventHandler(this.newFilesMenuLink_Click);
            // 
            // NewVoiceFileMenuLink
            // 
            this.NewVoiceFileMenuLink.Name = "NewVoiceFileMenuLink";
            this.NewVoiceFileMenuLink.Size = new System.Drawing.Size(188, 26);
            this.NewVoiceFileMenuLink.Text = "New Voice Files";
            this.NewVoiceFileMenuLink.Click += new System.EventHandler(this.NewVoiceFileMenuLink_Click);
            // 
            // myProfileMenuLink
            // 
            this.myProfileMenuLink.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.myProfileMenuLink.Name = "myProfileMenuLink";
            this.myProfileMenuLink.Size = new System.Drawing.Size(108, 25);
            this.myProfileMenuLink.Text = "MY PROFILE";
            this.myProfileMenuLink.Click += new System.EventHandler(this.myProfileMenuLink_Click);
            // 
            // logOutMenuLink
            // 
            this.logOutMenuLink.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logOutMenuLink.Name = "logOutMenuLink";
            this.logOutMenuLink.Size = new System.Drawing.Size(87, 25);
            this.logOutMenuLink.Text = "LOG OUT";
            this.logOutMenuLink.Click += new System.EventHandler(this.logOutMenuLink_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 789);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1534, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 29);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1534, 760);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1526, 734);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1534, 811);
            this.Controls.Add(tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMR Transcription";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIForm_FormClosing);
            this.Load += new System.EventHandler(this.MDIForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFilesMenuLink;
        private System.Windows.Forms.ToolStripMenuItem dashBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myProfileMenuLink;
        private System.Windows.Forms.ToolStripMenuItem logOutMenuLink;
        private System.Windows.Forms.ToolStripMenuItem NewVoiceFileMenuLink;
        private static System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}



