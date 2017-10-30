namespace LoginSQL
{
    partial class frmLogin
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblCnn = new System.Windows.Forms.Label();
            this.Waiting = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblCnnString = new System.Windows.Forms.Label();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbPassHash = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.Waiting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(12, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(206, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(14, 89);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(78, 52);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(203, 20);
            this.tbUsername.TabIndex = 1;
            this.tbUsername.WordWrap = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(78, 86);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(203, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.WordWrap = false;
            // 
            // lblCnn
            // 
            this.lblCnn.AutoSize = true;
            this.lblCnn.Location = new System.Drawing.Point(13, 13);
            this.lblCnn.Name = "lblCnn";
            this.lblCnn.Size = new System.Drawing.Size(77, 13);
            this.lblCnn.TabIndex = 0;
            this.lblCnn.Text = "Connected to: ";
            // 
            // Waiting
            // 
            this.Waiting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.Waiting.Location = new System.Drawing.Point(0, 170);
            this.Waiting.Name = "Waiting";
            this.Waiting.Size = new System.Drawing.Size(519, 22);
            this.Waiting.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "Waiting..";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(97, 12);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(10, 13);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = ".";
            this.lblServerIP.Click += new System.EventHandler(this.lblServerIP_Click);
            // 
            // lblCnnString
            // 
            this.lblCnnString.AutoSize = true;
            this.lblCnnString.Location = new System.Drawing.Point(16, 30);
            this.lblCnnString.Name = "lblCnnString";
            this.lblCnnString.Size = new System.Drawing.Size(0, 13);
            this.lblCnnString.TabIndex = 8;
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Location = new System.Drawing.Point(100, 121);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(0, 13);
            this.lblRowsCount.TabIndex = 9;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(322, 111);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(128, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create Password Hash";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbPassHash
            // 
            this.tbPassHash.Location = new System.Drawing.Point(287, 86);
            this.tbPassHash.Name = "tbPassHash";
            this.tbPassHash.Size = new System.Drawing.Size(163, 20);
            this.tbPassHash.TabIndex = 11;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(456, 84);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(50, 23);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(519, 192);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbPassHash);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblRowsCount);
            this.Controls.Add(this.lblCnnString);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.Waiting);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCnn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Waiting.ResumeLayout(false);
            this.Waiting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblCnn;
        private System.Windows.Forms.StatusStrip Waiting;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblCnnString;
        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbPassHash;
        private System.Windows.Forms.Button btnCopy;
    }
}

