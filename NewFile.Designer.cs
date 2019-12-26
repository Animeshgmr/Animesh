namespace GMRTTranscription
{
    partial class NewFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFile));
            this.lblFileLists = new System.Windows.Forms.Label();
            this.dataGridFileLists = new System.Windows.Forms.DataGridView();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.advancedTextEditor1 = new TextRuler.AdvancedTextEditorControl.AdvancedTextEditor();
            this.tableLayoutPanelForSaveAndPartialSaveButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnVertical = new System.Windows.Forms.Button();
            this.btnPartialSave = new System.Windows.Forms.Button();
            this.btnSaveTask = new System.Windows.Forms.Button();
            this.btnHorizontal = new System.Windows.Forms.Button();
            this.panelForPdfViewer = new System.Windows.Forms.Panel();
            this.transparentControlForPdfViewer = new Text2TextTranscription.Model.UserControl.TransparentPanel();
            this.transparentpanelLeft = new Text2TextTranscription.Model.UserControl.TransparentControl();
            this.pdfViewer = new AxAcroPDFLib.AxAcroPDF();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPerc = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.lblFileId = new System.Windows.Forms.Label();
            this.tlp_Header = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_deadline = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_tat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Filename = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileLists)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelForSaveAndPartialSaveButtons.SuspendLayout();
            this.panelForPdfViewer.SuspendLayout();
            this.transparentControlForPdfViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewer)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlp_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileLists
            // 
            this.lblFileLists.AutoSize = true;
            this.lblFileLists.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFileLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileLists.Location = new System.Drawing.Point(3, 88);
            this.lblFileLists.Name = "lblFileLists";
            this.lblFileLists.Size = new System.Drawing.Size(1, 24);
            this.lblFileLists.TabIndex = 0;
            this.lblFileLists.Text = "File Lists";
            // 
            // dataGridFileLists
            // 
            this.dataGridFileLists.AllowUserToAddRows = false;
            this.dataGridFileLists.AllowUserToDeleteRows = false;
            this.dataGridFileLists.AllowUserToResizeRows = false;
            this.dataGridFileLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFileLists.ColumnHeadersVisible = false;
            this.dataGridFileLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFileLists.Location = new System.Drawing.Point(3, 115);
            this.dataGridFileLists.Name = "dataGridFileLists";
            this.dataGridFileLists.ReadOnly = true;
            this.dataGridFileLists.RowHeadersVisible = false;
            this.dataGridFileLists.Size = new System.Drawing.Size(1, 566);
            this.dataGridFileLists.TabIndex = 1;
            this.dataGridFileLists.Visible = false;
            this.dataGridFileLists.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFileLists_CellClick);
            this.dataGridFileLists.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFileLists_CellContentClick);
            this.dataGridFileLists.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridFileLists_KeyDown);
            // 
            // lblDownloading
            // 
            this.lblDownloading.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDownloading.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloading.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDownloading.Location = new System.Drawing.Point(10, 45);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(103, 21);
            this.lblDownloading.TabIndex = 1;
            this.lblDownloading.Text = "Loading File";
            this.lblDownloading.Visible = false;
            this.lblDownloading.Click += new System.EventHandler(this.lblDownloading_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4512126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.50085F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.04794F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridFileLists, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerId, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.advancedTextEditor1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFileLists, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelForSaveAndPartialSaveButtons, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelForPdfViewer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFileId, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDownloading, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.72471F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.16005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1773, 781);
            this.tableLayoutPanel1.TabIndex = 25;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(3, 684);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(1, 24);
            this.lblCustomerId.TabIndex = 24;
            this.lblCustomerId.Text = "Customer Id";
            this.lblCustomerId.Visible = false;
            this.lblCustomerId.Click += new System.EventHandler(this.lblCustomerId_Click);
            // 
            // advancedTextEditor1
            // 
            this.advancedTextEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedTextEditor1.AutoSize = true;
            this.advancedTextEditor1.Location = new System.Drawing.Point(799, 115);
            this.advancedTextEditor1.Name = "advancedTextEditor1";
            this.advancedTextEditor1.Size = new System.Drawing.Size(971, 566);
            this.advancedTextEditor1.TabIndex = 3;
            // 
            // tableLayoutPanelForSaveAndPartialSaveButtons
            // 
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ColumnCount = 4;
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Controls.Add(this.btnVertical, 3, 0);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Controls.Add(this.btnPartialSave, 0, 0);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Controls.Add(this.btnSaveTask, 1, 0);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Controls.Add(this.btnHorizontal, 2, 0);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Location = new System.Drawing.Point(799, 687);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Name = "tableLayoutPanelForSaveAndPartialSaveButtons";
            this.tableLayoutPanelForSaveAndPartialSaveButtons.RowCount = 1;
            this.tableLayoutPanelForSaveAndPartialSaveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForSaveAndPartialSaveButtons.Size = new System.Drawing.Size(971, 70);
            this.tableLayoutPanelForSaveAndPartialSaveButtons.TabIndex = 25;
            // 
            // btnVertical
            // 
            this.btnVertical.BackColor = System.Drawing.Color.Green;
            this.btnVertical.BackgroundImage = global::GMRTTranscription.Properties.Resources.green4;
            this.btnVertical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVertical.ForeColor = System.Drawing.Color.White;
            this.btnVertical.Location = new System.Drawing.Point(729, 3);
            this.btnVertical.Name = "btnVertical";
            this.btnVertical.Size = new System.Drawing.Size(239, 64);
            this.btnVertical.TabIndex = 24;
            this.btnVertical.Text = "Vertical";
            this.btnVertical.UseVisualStyleBackColor = false;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // btnPartialSave
            // 
            this.btnPartialSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPartialSave.BackgroundImage = global::GMRTTranscription.Properties.Resources.partial_save45;
            this.btnPartialSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPartialSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPartialSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartialSave.ForeColor = System.Drawing.Color.White;
            this.btnPartialSave.Location = new System.Drawing.Point(2, 2);
            this.btnPartialSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnPartialSave.Name = "btnPartialSave";
            this.btnPartialSave.Size = new System.Drawing.Size(238, 66);
            this.btnPartialSave.TabIndex = 22;
            this.btnPartialSave.Text = "Partial Save";
            this.btnPartialSave.UseVisualStyleBackColor = false;
            this.btnPartialSave.Click += new System.EventHandler(this.btnPartialSave_Click);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSaveTask.BackgroundImage = global::GMRTTranscription.Properties.Resources.save9;
            this.btnSaveTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTask.ForeColor = System.Drawing.Color.White;
            this.btnSaveTask.Location = new System.Drawing.Point(244, 2);
            this.btnSaveTask.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(238, 66);
            this.btnSaveTask.TabIndex = 21;
            this.btnSaveTask.Text = "SAVE";
            this.btnSaveTask.UseVisualStyleBackColor = false;
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // btnHorizontal
            // 
            this.btnHorizontal.BackColor = System.Drawing.Color.Green;
            this.btnHorizontal.BackgroundImage = global::GMRTTranscription.Properties.Resources.green5;
            this.btnHorizontal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorizontal.ForeColor = System.Drawing.Color.White;
            this.btnHorizontal.Location = new System.Drawing.Point(487, 3);
            this.btnHorizontal.Name = "btnHorizontal";
            this.btnHorizontal.Size = new System.Drawing.Size(236, 64);
            this.btnHorizontal.TabIndex = 23;
            this.btnHorizontal.Text = "Horizontal";
            this.btnHorizontal.UseVisualStyleBackColor = false;
            this.btnHorizontal.Click += new System.EventHandler(this.btnHorizontal_Click);
            // 
            // panelForPdfViewer
            // 
            this.panelForPdfViewer.Controls.Add(this.transparentControlForPdfViewer);
            this.panelForPdfViewer.Controls.Add(this.pdfViewer);
            this.panelForPdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForPdfViewer.Location = new System.Drawing.Point(10, 115);
            this.panelForPdfViewer.Name = "panelForPdfViewer";
            this.panelForPdfViewer.Size = new System.Drawing.Size(783, 566);
            this.panelForPdfViewer.TabIndex = 26;
            // 
            // transparentControlForPdfViewer
            // 
            this.transparentControlForPdfViewer.BackColor = System.Drawing.Color.Transparent;
            this.transparentControlForPdfViewer.Controls.Add(this.transparentpanelLeft);
            this.transparentControlForPdfViewer.ForeColor = System.Drawing.Color.Green;
            this.transparentControlForPdfViewer.Location = new System.Drawing.Point(115, 0);
            this.transparentControlForPdfViewer.Name = "transparentControlForPdfViewer";
            this.transparentControlForPdfViewer.Opacity = 0;
            this.transparentControlForPdfViewer.Size = new System.Drawing.Size(725, 616);
            this.transparentControlForPdfViewer.TabIndex = 1;
            this.transparentControlForPdfViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.transparentControlForPdfViewer_Paint);
            // 
            // transparentpanelLeft
            // 
            this.transparentpanelLeft.BackColor = System.Drawing.Color.Transparent;
            this.transparentpanelLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.transparentpanelLeft.Location = new System.Drawing.Point(0, 0);
            this.transparentpanelLeft.Name = "transparentpanelLeft";
            this.transparentpanelLeft.Opacity = 100;
            this.transparentpanelLeft.Size = new System.Drawing.Size(725, 53);
            this.transparentpanelLeft.TabIndex = 0;
            this.transparentpanelLeft.Text = resources.GetString("transparentpanelLeft.Text");
            this.transparentpanelLeft.Click += new System.EventHandler(this.transparentpanelLeft_Click);
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Enabled = true;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfViewer.OcxState")));
            this.pdfViewer.Size = new System.Drawing.Size(783, 566);
            this.pdfViewer.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.progressBar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelPerc, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelDownloaded, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 687);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(783, 70);
            this.tableLayoutPanel2.TabIndex = 27;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(159, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(463, 21);
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // labelPerc
            // 
            this.labelPerc.AutoSize = true;
            this.labelPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerc.Location = new System.Drawing.Point(3, 0);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(75, 24);
            this.labelPerc.TabIndex = 26;
            this.labelPerc.Text = "Percent";
            this.labelPerc.Visible = false;
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownloaded.Location = new System.Drawing.Point(628, 0);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(132, 24);
            this.labelDownloaded.TabIndex = 27;
            this.labelDownloaded.Text = "DownloadText";
            // 
            // lblFileId
            // 
            this.lblFileId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFileId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileId.Location = new System.Drawing.Point(799, 41);
            this.lblFileId.Name = "lblFileId";
            this.lblFileId.Size = new System.Drawing.Size(453, 30);
            this.lblFileId.TabIndex = 23;
            this.lblFileId.Text = "File Id";
            this.lblFileId.Visible = false;
            this.lblFileId.Click += new System.EventHandler(this.lblFileId_Click);
            // 
            // tlp_Header
            // 
            this.tlp_Header.ColumnCount = 4;
            this.tlp_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tlp_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlp_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Header.Controls.Add(this.btnClose, 3, 0);
            this.tlp_Header.Controls.Add(this.label4, 0, 2);
            this.tlp_Header.Controls.Add(this.label1, 0, 1);
            this.tlp_Header.Controls.Add(this.label6, 2, 2);
            this.tlp_Header.Controls.Add(this.label2, 2, 1);
            this.tlp_Header.Controls.Add(this.lbl_deadline, 1, 2);
            this.tlp_Header.Controls.Add(this.lbl_Filename, 1, 1);
            this.tlp_Header.Controls.Add(this.lbl_status, 3, 2);
            this.tlp_Header.Controls.Add(this.lbl_tat, 3, 1);
            this.tlp_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Header.Location = new System.Drawing.Point(0, 0);
            this.tlp_Header.Name = "tlp_Header";
            this.tlp_Header.RowCount = 3;
            this.tlp_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Header.Size = new System.Drawing.Size(1773, 110);
            this.tlp_Header.TabIndex = 26;
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_status.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_status.ForeColor = System.Drawing.Color.Black;
            this.lbl_status.Location = new System.Drawing.Point(1067, 74);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(703, 33);
            this.lbl_status.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(894, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Status:";
            // 
            // lbl_deadline
            // 
            this.lbl_deadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_deadline.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_deadline.ForeColor = System.Drawing.Color.Black;
            this.lbl_deadline.Location = new System.Drawing.Point(186, 74);
            this.lbl_deadline.Name = "lbl_deadline";
            this.lbl_deadline.Size = new System.Drawing.Size(702, 33);
            this.lbl_deadline.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "DeadLine Date & time :";
            // 
            // lbl_tat
            // 
            this.lbl_tat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tat.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_tat.ForeColor = System.Drawing.Color.Black;
            this.lbl_tat.Location = new System.Drawing.Point(1067, 37);
            this.lbl_tat.Name = "lbl_tat";
            this.lbl_tat.Size = new System.Drawing.Size(703, 33);
            this.lbl_tat.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(894, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "TAT:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name :";
            // 
            // lbl_Filename
            // 
            this.lbl_Filename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Filename.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Filename.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_Filename.ForeColor = System.Drawing.Color.Black;
            this.lbl_Filename.Location = new System.Drawing.Point(186, 37);
            this.lbl_Filename.Name = "lbl_Filename";
            this.lbl_Filename.Size = new System.Drawing.Size(702, 33);
            this.lbl_Filename.TabIndex = 1;
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
            this.btnClose.Location = new System.Drawing.Point(1743, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 26);
            this.btnClose.TabIndex = 28;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1773, 781);
            this.Controls.Add(this.tlp_Header);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "NewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Lists";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximizedBoundsChanged += new System.EventHandler(this.NewFile_MaximizedBoundsChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewFile_FormClosed);
            this.Load += new System.EventHandler(this.NewFile_Load);
            this.Shown += new System.EventHandler(this.NewFile_Shown);
            this.ResizeEnd += new System.EventHandler(this.NewFile_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewFile_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFileLists)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelForSaveAndPartialSaveButtons.ResumeLayout(false);
            this.panelForPdfViewer.ResumeLayout(false);
            this.transparentControlForPdfViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewer)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlp_Header.ResumeLayout(false);
            this.tlp_Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFileLists;
        private System.Windows.Forms.DataGridView dataGridFileLists;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelForPdfViewer;
        private System.Windows.Forms.Label lblCustomerId;
        private TextRuler.AdvancedTextEditorControl.AdvancedTextEditor advancedTextEditor1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForSaveAndPartialSaveButtons;
        private System.Windows.Forms.Button btnVertical;
        private System.Windows.Forms.Button btnPartialSave;
        private System.Windows.Forms.Button btnSaveTask;
        private System.Windows.Forms.Button btnHorizontal;
        private System.Windows.Forms.Label lblFileId;
        protected AxAcroPDFLib.AxAcroPDF pdfViewer;
        private System.Windows.Forms.TableLayoutPanel tlp_Header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Filename;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_deadline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_tat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.Label labelDownloaded;
        private Text2TextTranscription.Model.UserControl.TransparentPanel transparentControlForPdfViewer;
        private Text2TextTranscription.Model.UserControl.TransparentControl transparentpanelLeft;
        private System.Windows.Forms.Button btnClose;
    }
}