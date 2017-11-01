namespace LoginSQL
{
    partial class frmAuth
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
            this.tbAuthPass = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblEnterAuth = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAuthPass
            // 
            this.tbAuthPass.Location = new System.Drawing.Point(38, 37);
            this.tbAuthPass.MaxLength = 50;
            this.tbAuthPass.Name = "tbAuthPass";
            this.tbAuthPass.PasswordChar = '*';
            this.tbAuthPass.Size = new System.Drawing.Size(218, 20);
            this.tbAuthPass.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(181, 63);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Submit";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblEnterAuth
            // 
            this.lblEnterAuth.AutoSize = true;
            this.lblEnterAuth.Location = new System.Drawing.Point(12, 13);
            this.lblEnterAuth.Name = "lblEnterAuth";
            this.lblEnterAuth.Size = new System.Drawing.Size(267, 13);
            this.lblEnterAuth.TabIndex = 2;
            this.lblEnterAuth.Text = "To create an account, please enter the auth password:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(38, 63);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAuth
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 98);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblEnterAuth);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbAuthPass);
            this.Name = "frmAuth";
            this.Text = "Auth";
            this.Load += new System.EventHandler(this.frmAuth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAuthPass;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblEnterAuth;
        private System.Windows.Forms.Button btnExit;
    }
}