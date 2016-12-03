namespace Quantopus
{
	partial class Window
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quantizeWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.qunatizeWithDynamicTreeReductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label2 = new System.Windows.Forms.Label();
			this.originalPictureBox = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.quantizedPictureBox = new System.Windows.Forms.PictureBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.quantizeProgressBar = new System.Windows.Forms.ProgressBar();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.quantizedPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(805, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quantizeWithToolStripMenuItem,
            this.qunatizeWithDynamicTreeReductionToolStripMenuItem});
			this.editToolStripMenuItem.Enabled = false;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
			this.editToolStripMenuItem.Text = "Quantization";
			// 
			// quantizeWithToolStripMenuItem
			// 
			this.quantizeWithToolStripMenuItem.Name = "quantizeWithToolStripMenuItem";
			this.quantizeWithToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.quantizeWithToolStripMenuItem.Text = "Octree";
			this.quantizeWithToolStripMenuItem.Click += new System.EventHandler(this.quantizeWithToolStripMenuItem_Click);
			// 
			// qunatizeWithDynamicTreeReductionToolStripMenuItem
			// 
			this.qunatizeWithDynamicTreeReductionToolStripMenuItem.Name = "qunatizeWithDynamicTreeReductionToolStripMenuItem";
			this.qunatizeWithDynamicTreeReductionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.qunatizeWithDynamicTreeReductionToolStripMenuItem.Text = "Octree dynamic";
			this.qunatizeWithDynamicTreeReductionToolStripMenuItem.Click += new System.EventHandler(this.qunatizeWithDynamicTreeReductionToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(552, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Palette";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 27);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.originalPictureBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.quantizedPictureBox);
			this.splitContainer1.Size = new System.Drawing.Size(805, 428);
			this.splitContainer1.SplitterDistance = 399;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Liberation Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(399, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "ORIGINAL IMAGE";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// originalPictureBox
			// 
			this.originalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.originalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.originalPictureBox.Location = new System.Drawing.Point(0, 35);
			this.originalPictureBox.Name = "originalPictureBox";
			this.originalPictureBox.Size = new System.Drawing.Size(399, 393);
			this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.originalPictureBox.TabIndex = 0;
			this.originalPictureBox.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("Liberation Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(401, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "QUANTIZED IMAGE";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// quantizedPictureBox
			// 
			this.quantizedPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.quantizedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.quantizedPictureBox.Location = new System.Drawing.Point(0, 35);
			this.quantizedPictureBox.Name = "quantizedPictureBox";
			this.quantizedPictureBox.Size = new System.Drawing.Size(401, 393);
			this.quantizedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.quantizedPictureBox.TabIndex = 0;
			this.quantizedPictureBox.TabStop = false;
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(598, 1);
			this.trackBar1.Maximum = 4096;
			this.trackBar1.Minimum = 1;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(148, 45);
			this.trackBar1.TabIndex = 5;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.Value = 16;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown1.BackColor = System.Drawing.SystemColors.Control;
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.numericUpDown1.Location = new System.Drawing.Point(752, 3);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(41, 18);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// quantizeProgressBar
			// 
			this.quantizeProgressBar.Location = new System.Drawing.Point(132, 4);
			this.quantizeProgressBar.Name = "quantizeProgressBar";
			this.quantizeProgressBar.Size = new System.Drawing.Size(100, 18);
			this.quantizeProgressBar.TabIndex = 6;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 458);
			this.Controls.Add(this.quantizeProgressBar);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Window";
			this.Text = "Quantopus";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.quantizedPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quantizeWithToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem qunatizeWithDynamicTreeReductionToolStripMenuItem;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox quantizedPictureBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.ProgressBar quantizeProgressBar;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

