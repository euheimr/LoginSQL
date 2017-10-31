namespace LoginSQL
{
    partial class frmMain
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.tsStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(99, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tsStatus
            // 
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMain});
            this.tsStatus.Location = new System.Drawing.Point(0, 224);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(284, 22);
            this.tsStatus.TabIndex = 1;
            this.tsStatus.Text = "tsStatus";
            // 
            // lblStatusMain
            // 
            this.lblStatusMain.Name = "lblStatusMain";
            this.lblStatusMain.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.btnLogout);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.StatusStrip tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMain;
    }
}