namespace GMRTTranscription
{
    partial class MyTestCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyTestCode));
            this.voiceplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.volumebar = new System.Windows.Forms.TrackBar();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.playbackspeed = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playerstatusbar = new System.Windows.Forms.TrackBar();
            this.lbl_playduration = new System.Windows.Forms.Label();
            this.lbl_totalduration = new System.Windows.Forms.Label();
            this.pic_playpause = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.voiceplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playbackspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerstatusbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_playpause)).BeginInit();
            this.SuspendLayout();
            // 
            // voiceplayer
            // 
            this.voiceplayer.Enabled = true;
            this.voiceplayer.Location = new System.Drawing.Point(-2, 1);
            this.voiceplayer.Name = "voiceplayer";
            this.voiceplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("voiceplayer.OcxState")));
            this.voiceplayer.Size = new System.Drawing.Size(579, 303);
            this.voiceplayer.TabIndex = 0;
            this.voiceplayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.voiceplayer_PlayStateChange);
            // 
            // volumebar
            // 
            this.volumebar.BackColor = System.Drawing.SystemColors.Control;
            this.volumebar.Location = new System.Drawing.Point(146, 356);
            this.volumebar.Margin = new System.Windows.Forms.Padding(0);
            this.volumebar.Maximum = 100;
            this.volumebar.Minimum = 10;
            this.volumebar.Name = "volumebar";
            this.volumebar.Size = new System.Drawing.Size(82, 45);
            this.volumebar.TabIndex = 3;
            this.volumebar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumebar.Value = 10;
            this.volumebar.Scroll += new System.EventHandler(this.volumebar_Scroll);
            // 
            // lbl_speed
            // 
            this.lbl_speed.BackColor = System.Drawing.Color.Purple;
            this.lbl_speed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_speed.ForeColor = System.Drawing.Color.White;
            this.lbl_speed.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_speed.Location = new System.Drawing.Point(270, 353);
            this.lbl_speed.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_speed.Size = new System.Drawing.Size(89, 35);
            this.lbl_speed.TabIndex = 5;
            this.lbl_speed.Text = "1x Speed";
            this.lbl_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_speed.MouseHover += new System.EventHandler(this.lbl_speed_MouseHover);
            // 
            // playbackspeed
            // 
            this.playbackspeed.Location = new System.Drawing.Point(270, 392);
            this.playbackspeed.Minimum = 1;
            this.playbackspeed.Name = "playbackspeed";
            this.playbackspeed.Size = new System.Drawing.Size(89, 45);
            this.playbackspeed.TabIndex = 6;
            this.playbackspeed.Value = 1;
            this.playbackspeed.Visible = false;
            this.playbackspeed.Scroll += new System.EventHandler(this.playbackspeed_Scroll);
            this.playbackspeed.Leave += new System.EventHandler(this.playbackspeed_Leave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playerstatusbar
            // 
            this.playerstatusbar.AutoSize = false;
            this.playerstatusbar.Location = new System.Drawing.Point(51, 310);
            this.playerstatusbar.Name = "playerstatusbar";
            this.playerstatusbar.Size = new System.Drawing.Size(460, 15);
            this.playerstatusbar.TabIndex = 7;
            this.playerstatusbar.Scroll += new System.EventHandler(this.playerstatusbar_Scroll);
            // 
            // lbl_playduration
            // 
            this.lbl_playduration.AutoSize = true;
            this.lbl_playduration.Location = new System.Drawing.Point(4, 311);
            this.lbl_playduration.Name = "lbl_playduration";
            this.lbl_playduration.Size = new System.Drawing.Size(35, 13);
            this.lbl_playduration.TabIndex = 8;
            this.lbl_playduration.Text = "safasf";
            // 
            // lbl_totalduration
            // 
            this.lbl_totalduration.AutoSize = true;
            this.lbl_totalduration.Location = new System.Drawing.Point(518, 311);
            this.lbl_totalduration.Name = "lbl_totalduration";
            this.lbl_totalduration.Size = new System.Drawing.Size(35, 13);
            this.lbl_totalduration.TabIndex = 9;
            this.lbl_totalduration.Text = "label1";
            // 
            // pic_playpause
            // 
            this.pic_playpause.Image = global::GMRTTranscription.Properties.Resources.play1;
            this.pic_playpause.Location = new System.Drawing.Point(4, 352);
            this.pic_playpause.Name = "pic_playpause";
            this.pic_playpause.Size = new System.Drawing.Size(41, 35);
            this.pic_playpause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_playpause.TabIndex = 4;
            this.pic_playpause.TabStop = false;
            this.pic_playpause.Tag = "fasfasfasfsaf";
            this.pic_playpause.Click += new System.EventHandler(this.pic_playpause_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.Control;
            this.btnback.BackgroundImage = global::GMRTTranscription.Properties.Resources.button_bg;
            this.btnback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(51, 352);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(89, 35);
            this.btnback.TabIndex = 2;
            this.btnback.Text = "Back 5sec";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // MyTestCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 530);
            this.Controls.Add(this.lbl_totalduration);
            this.Controls.Add(this.lbl_playduration);
            this.Controls.Add(this.playerstatusbar);
            this.Controls.Add(this.playbackspeed);
            this.Controls.Add(this.lbl_speed);
            this.Controls.Add(this.pic_playpause);
            this.Controls.Add(this.volumebar);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.voiceplayer);
            this.KeyPreview = true;
            this.Name = "MyTestCode";
            this.Text = "MyTestCode";
            this.Load += new System.EventHandler(this.MyTestCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyTestCode_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.voiceplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playbackspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerstatusbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_playpause)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer voiceplayer;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.TrackBar volumebar;
        private System.Windows.Forms.PictureBox pic_playpause;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.TrackBar playbackspeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar playerstatusbar;
        private System.Windows.Forms.Label lbl_playduration;
        private System.Windows.Forms.Label lbl_totalduration;
    }
}