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
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.btnProcessFile = new System.Windows.Forms.Button();
            this.txtBoxDebug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(13, 13);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(653, 20);
            this.SourcePath.TabIndex = 1;
            // 
            // btnProcessFile
            // 
            this.btnProcessFile.Location = new System.Drawing.Point(672, 13);
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Size = new System.Drawing.Size(98, 23);
            this.btnProcessFile.TabIndex = 2;
            this.btnProcessFile.Text = "Set Source File";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);
            // 
            // txtBoxDebug
            // 
            this.txtBoxDebug.Location = new System.Drawing.Point(13, 57);
            this.txtBoxDebug.Multiline = true;
            this.txtBoxDebug.Name = "txtBoxDebug";
            this.txtBoxDebug.Size = new System.Drawing.Size(653, 199);
            this.txtBoxDebug.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 264);
            this.Controls.Add(this.txtBoxDebug);
            this.Controls.Add(this.btnProcessFile);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "MUAC STATISTICS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.TextBox txtBoxDebug;
    }
}

