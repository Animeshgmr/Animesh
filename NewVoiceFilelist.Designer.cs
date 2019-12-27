namespace GMRTTranscription
{
    partial class NewVoiceFilelist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resou    rces being used.
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.invoiceGrid = new System.Windows.Forms.DataGridView();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadurl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadlinedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadlinetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_tat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eservice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrcution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filestatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transcribe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // invoiceGrid
            // 
            this.invoiceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.invoiceGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.invoiceGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invoiceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.invoiceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoiceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.fileid,
            this.po_id,
            this.customer_id,
            this.FileName,
            this.duration,
            this.downloadurl,
            this.deadlinedate,
            this.deadlinetime,
            this.payrate,
            this.po_tat,
            this.eservice,
            this.instrcution,
            this.Filestatus,
            this.Transcribe});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.invoiceGrid.DefaultCellStyle = dataGridViewCellStyle17;
            this.invoiceGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.invoiceGrid.Location = new System.Drawing.Point(0, 27);
            this.invoiceGrid.Name = "invoiceGrid";
            this.invoiceGrid.RowTemplate.Height = 40;
            this.invoiceGrid.Size = new System.Drawing.Size(1604, 525);
            this.invoiceGrid.TabIndex = 1;
            this.invoiceGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoiceGrid_CellClick);
            this.invoiceGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoiceGrid_CellContentClick);
            // 
            // Slno
            // 
            this.Slno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N2";
            this.Slno.DefaultCellStyle = dataGridViewCellStyle2;
            this.Slno.FillWeight = 5F;
            this.Slno.Frozen = true;
            this.Slno.HeaderText = "#";
            this.Slno.Name = "Slno";
            this.Slno.ReadOnly = true;
            this.Slno.Width = 45;
            // 
            // fileid
            // 
            this.fileid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.fileid.DefaultCellStyle = dataGridViewCellStyle3;
            this.fileid.Frozen = true;
            this.fileid.HeaderText = "fileid";
            this.fileid.Name = "fileid";
            this.fileid.ReadOnly = true;
            this.fileid.Width = 71;
            // 
            // po_id
            // 
            this.po_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.po_id.DefaultCellStyle = dataGridViewCellStyle4;
            this.po_id.Frozen = true;
            this.po_id.HeaderText = "po_id";
            this.po_id.Name = "po_id";
            this.po_id.ReadOnly = true;
            this.po_id.Width = 79;
            // 
            // customer_id
            // 
            this.customer_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.customer_id.DefaultCellStyle = dataGridViewCellStyle5;
            this.customer_id.Frozen = true;
            this.customer_id.HeaderText = "customer_id";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.Width = 128;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.FileName.DefaultCellStyle = dataGridViewCellStyle6;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 101;
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.duration.DefaultCellStyle = dataGridViewCellStyle7;
            this.duration.HeaderText = "Duration";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            this.duration.Width = 99;
            // 
            // downloadurl
            // 
            this.downloadurl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.downloadurl.DefaultCellStyle = dataGridViewCellStyle8;
            this.downloadurl.HeaderText = "Downloadurl";
            this.downloadurl.Name = "downloadurl";
            this.downloadurl.ReadOnly = true;
            this.downloadurl.Width = 131;
            // 
            // deadlinedate
            // 
            this.deadlinedate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.deadlinedate.DefaultCellStyle = dataGridViewCellStyle9;
            this.deadlinedate.HeaderText = "Deadline Date";
            this.deadlinedate.Name = "deadlinedate";
            this.deadlinedate.ReadOnly = true;
            this.deadlinedate.Width = 126;
            // 
            // deadlinetime
            // 
            this.deadlinetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.deadlinetime.DefaultCellStyle = dataGridViewCellStyle10;
            this.deadlinetime.HeaderText = "Deadline Time";
            this.deadlinetime.Name = "deadlinetime";
            this.deadlinetime.ReadOnly = true;
            this.deadlinetime.Width = 129;
            // 
            // payrate
            // 
            this.payrate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = "0.00";
            this.payrate.DefaultCellStyle = dataGridViewCellStyle11;
            this.payrate.HeaderText = "Payrate";
            this.payrate.Name = "payrate";
            this.payrate.ReadOnly = true;
            this.payrate.Width = 90;
            // 
            // po_tat
            // 
            this.po_tat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.po_tat.DefaultCellStyle = dataGridViewCellStyle12;
            this.po_tat.HeaderText = "Language";
            this.po_tat.Name = "po_tat";
            this.po_tat.Width = 106;
            // 
            // eservice
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.eservice.DefaultCellStyle = dataGridViewCellStyle13;
            this.eservice.HeaderText = "Extra Services";
            this.eservice.Name = "eservice";
            this.eservice.ReadOnly = true;
            // 
            // instrcution
            // 
            this.instrcution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.instrcution.DefaultCellStyle = dataGridViewCellStyle14;
            this.instrcution.HeaderText = "File Instructions";
            this.instrcution.Name = "instrcution";
            this.instrcution.ReadOnly = true;
            this.instrcution.Width = 141;
            // 
            // Filestatus
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filestatus.DefaultCellStyle = dataGridViewCellStyle15;
            this.Filestatus.HeaderText = "File Status";
            this.Filestatus.Name = "Filestatus";
            this.Filestatus.ReadOnly = true;
            // 
            // Transcribe
            // 
            this.Transcribe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            this.Transcribe.DefaultCellStyle = dataGridViewCellStyle16;
            this.Transcribe.HeaderText = "Transcribe";
            this.Transcribe.Name = "Transcribe";
            this.Transcribe.ReadOnly = true;
            this.Transcribe.Text = "Transcribe";
            this.Transcribe.ToolTipText = "Click here to Transcribe";
            this.Transcribe.UseColumnTextForButtonValue = true;
            this.Transcribe.Width = 95;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::GMRTTranscription.Properties.Resources.cross1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1574, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NewVoiceFilelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 579);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.invoiceGrid);
            this.Name = "NewVoiceFilelist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewVoiceFilelist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewVoiceFilelist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.invoiceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView invoiceGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileid;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadurl;
        private System.Windows.Forms.DataGridViewTextBoxColumn deadlinedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn deadlinetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn payrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_tat;
        private System.Windows.Forms.DataGridViewTextBoxColumn eservice;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrcution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filestatus;
        private System.Windows.Forms.DataGridViewButtonColumn Transcribe;
        private System.Windows.Forms.Button btnClose;
    }
}