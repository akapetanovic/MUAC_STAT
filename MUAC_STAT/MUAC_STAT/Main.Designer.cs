﻿namespace MUAC_STAT
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMySQL_Status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxHistoryLog = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxHistoryLog = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBatchLocation = new System.Windows.Forms.Label();
            this.chkBoxBatchProcessing = new System.Windows.Forms.CheckBox();
            this.ViewUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.btnClearDbm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDeleteTriggerFile = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(474, 24);
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
            this.groupBox1.Size = new System.Drawing.Size(337, 39);
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
            this.lblMySQL_Status.Click += new System.EventHandler(this.lblMySQL_Status_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxHistoryLog);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.checkBoxHistoryLog);
            this.groupBox2.Location = new System.Drawing.Point(13, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 290);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History log";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // listBoxHistoryLog
            // 
            this.listBoxHistoryLog.FormattingEnabled = true;
            this.listBoxHistoryLog.Location = new System.Drawing.Point(6, 51);
            this.listBoxHistoryLog.Name = "listBoxHistoryLog";
            this.listBoxHistoryLog.Size = new System.Drawing.Size(437, 238);
            this.listBoxHistoryLog.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(437, 20);
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
            this.checkBoxHistoryLog.Location = new System.Drawing.Point(67, 0);
            this.checkBoxHistoryLog.Name = "checkBoxHistoryLog";
            this.checkBoxHistoryLog.Size = new System.Drawing.Size(42, 17);
            this.checkBoxHistoryLog.TabIndex = 1;
            this.checkBoxHistoryLog.Text = "ON";
            this.checkBoxHistoryLog.UseVisualStyleBackColor = true;
            this.checkBoxHistoryLog.CheckedChanged += new System.EventHandler(this.checkBoxHistoryLog_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 387);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(437, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Save Log";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBatchLocation);
            this.groupBox3.Location = new System.Drawing.Point(13, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 33);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ESDM Trigger Location";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lblBatchLocation
            // 
            this.lblBatchLocation.AutoSize = true;
            this.lblBatchLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBatchLocation.Location = new System.Drawing.Point(6, 16);
            this.lblBatchLocation.Name = "lblBatchLocation";
            this.lblBatchLocation.Size = new System.Drawing.Size(93, 13);
            this.lblBatchLocation.TabIndex = 1;
            this.lblBatchLocation.Text = "Triger Location";
            // 
            // chkBoxBatchProcessing
            // 
            this.chkBoxBatchProcessing.AutoSize = true;
            this.chkBoxBatchProcessing.Location = new System.Drawing.Point(80, 69);
            this.chkBoxBatchProcessing.Name = "chkBoxBatchProcessing";
            this.chkBoxBatchProcessing.Size = new System.Drawing.Size(42, 17);
            this.chkBoxBatchProcessing.TabIndex = 0;
            this.chkBoxBatchProcessing.Text = "ON";
            this.chkBoxBatchProcessing.UseVisualStyleBackColor = true;
            this.chkBoxBatchProcessing.CheckedChanged += new System.EventHandler(this.chkBoxBatchProcessing_CheckedChanged);
            // 
            // ViewUpdateTimer
            // 
            this.ViewUpdateTimer.Interval = 1000;
            this.ViewUpdateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClearDbm
            // 
            this.btnClearDbm.Location = new System.Drawing.Point(355, 33);
            this.btnClearDbm.Name = "btnClearDbm";
            this.btnClearDbm.Size = new System.Drawing.Size(101, 33);
            this.btnClearDbm.TabIndex = 12;
            this.btnClearDbm.Text = "Clear Database";
            this.btnClearDbm.UseVisualStyleBackColor = true;
            this.btnClearDbm.Click += new System.EventHandler(this.btnClearDbm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Processing ";
            // 
            // checkBoxDeleteTriggerFile
            // 
            this.checkBoxDeleteTriggerFile.AutoSize = true;
            this.checkBoxDeleteTriggerFile.Location = new System.Drawing.Point(367, 428);
            this.checkBoxDeleteTriggerFile.Name = "checkBoxDeleteTriggerFile";
            this.checkBoxDeleteTriggerFile.Size = new System.Drawing.Size(105, 17);
            this.checkBoxDeleteTriggerFile.TabIndex = 2;
            this.checkBoxDeleteTriggerFile.Text = "Delete trigger file";
            this.checkBoxDeleteTriggerFile.UseVisualStyleBackColor = true;
            this.checkBoxDeleteTriggerFile.CheckedChanged += new System.EventHandler(this.checkBoxDeleteTriggerFile_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 457);
            this.Controls.Add(this.checkBoxDeleteTriggerFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearDbm);
            this.Controls.Add(this.chkBoxBatchProcessing);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MUAC STATISTICS 1.0";
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMySQL_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxHistoryLog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBoxHistoryLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxBatchProcessing;
        private System.Windows.Forms.Label lblBatchLocation;
        private System.Windows.Forms.Timer ViewUpdateTimer;
        private System.Windows.Forms.Button btnClearDbm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDeleteTriggerFile;
    }
}

