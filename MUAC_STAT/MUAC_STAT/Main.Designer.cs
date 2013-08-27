namespace MUAC_STAT
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtBoxDebug = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMySQL_Status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxHistoryLog = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxHistoryLog = new System.Windows.Forms.CheckBox();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBoxBatchProcessing = new System.Windows.Forms.CheckBox();
            this.lblBatchLocation = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxDebug
            // 
            this.txtBoxDebug.Location = new System.Drawing.Point(286, 28);
            this.txtBoxDebug.Multiline = true;
            this.txtBoxDebug.Name = "txtBoxDebug";
            this.txtBoxDebug.Size = new System.Drawing.Size(667, 353);
            this.txtBoxDebug.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMySQL_Status);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 39);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My SQL";
            // 
            // lblMySQL_Status
            // 
            this.lblMySQL_Status.AutoSize = true;
            this.lblMySQL_Status.Location = new System.Drawing.Point(121, 16);
            this.lblMySQL_Status.Name = "lblMySQL_Status";
            this.lblMySQL_Status.Size = new System.Drawing.Size(23, 13);
            this.lblMySQL_Status.TabIndex = 1;
            this.lblMySQL_Status.Text = "GO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxHistoryLog);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.checkBoxHistoryLog);
            this.groupBox2.Location = new System.Drawing.Point(13, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 289);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History log";
            // 
            // listBoxHistoryLog
            // 
            this.listBoxHistoryLog.FormattingEnabled = true;
            this.listBoxHistoryLog.Location = new System.Drawing.Point(6, 45);
            this.listBoxHistoryLog.Name = "listBoxHistoryLog";
            this.listBoxHistoryLog.Size = new System.Drawing.Size(249, 212);
            this.listBoxHistoryLog.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(249, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Save Log";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(249, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxHistoryLog
            // 
            this.checkBoxHistoryLog.AutoSize = true;
            this.checkBoxHistoryLog.Checked = true;
            this.checkBoxHistoryLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHistoryLog.Location = new System.Drawing.Point(64, 0);
            this.checkBoxHistoryLog.Name = "checkBoxHistoryLog";
            this.checkBoxHistoryLog.Size = new System.Drawing.Size(42, 17);
            this.checkBoxHistoryLog.TabIndex = 1;
            this.checkBoxHistoryLog.Text = "ON";
            this.checkBoxHistoryLog.UseVisualStyleBackColor = true;
            this.checkBoxHistoryLog.CheckedChanged += new System.EventHandler(this.checkBoxHistoryLog_CheckedChanged);
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(286, 387);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(517, 20);
            this.SourcePath.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBatchLocation);
            this.groupBox3.Controls.Add(this.chkBoxBatchProcessing);
            this.groupBox3.Location = new System.Drawing.Point(13, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 39);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch Processing";
            // 
            // chkBoxBatchProcessing
            // 
            this.chkBoxBatchProcessing.AutoSize = true;
            this.chkBoxBatchProcessing.Checked = true;
            this.chkBoxBatchProcessing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxBatchProcessing.Location = new System.Drawing.Point(96, 0);
            this.chkBoxBatchProcessing.Name = "chkBoxBatchProcessing";
            this.chkBoxBatchProcessing.Size = new System.Drawing.Size(42, 17);
            this.chkBoxBatchProcessing.TabIndex = 0;
            this.chkBoxBatchProcessing.Text = "ON";
            this.chkBoxBatchProcessing.UseVisualStyleBackColor = true;
            this.chkBoxBatchProcessing.CheckedChanged += new System.EventHandler(this.chkBoxBatchProcessing_CheckedChanged);
            // 
            // lblBatchLocation
            // 
            this.lblBatchLocation.AutoSize = true;
            this.lblBatchLocation.Location = new System.Drawing.Point(6, 16);
            this.lblBatchLocation.Name = "lblBatchLocation";
            this.lblBatchLocation.Size = new System.Drawing.Size(43, 13);
            this.lblBatchLocation.TabIndex = 1;
            this.lblBatchLocation.Text = "BATCH";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 416);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBoxDebug);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MUAC STATISTICS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBoxDebug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMySQL_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBoxHistoryLog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBoxHistoryLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxBatchProcessing;
        private System.Windows.Forms.Label lblBatchLocation;
    }
}

