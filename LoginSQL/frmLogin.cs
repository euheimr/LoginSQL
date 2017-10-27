using AppGlobals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginLib;

namespace LoginSQL
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            
            InitializeComponent();
            lblServerIP.Text = Global.serverName;
            lblCnnString.Text = Global.conn;
        }
        
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbUsername.Text == "" || tbUsername.Text == String.Empty || tbPassword.Text == "" || tbPassword.Text == String.Empty)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Please a valid username and password.";
                
                return;
            }

            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = "Waiting..";

            try
            {
                
                //create connection
                using (SqlConnection cnn = new SqlConnection(Global.conn))
                {
                    lblStatus.ForeColor = Color.Blue;
                    lblStatus.Text = "Logging in..";

                    SqlDataAdapter da = new SqlDataAdapter();
                    //run an SQL query to grab the info, then compare the info to the returned data in that table
                    Login.SelectLogin(Global.conn, tbUsername.Text.Trim(), tbPassword.Text.Trim(), Global.tableName);

                    //sets the IsLoggedIn flag in MSSQL server column to 1 (true)
                    Login.SetLogin(Global.conn, tbUsername.Text.Trim(), tbPassword.Text.Trim(), Global.tableName);

                    //set the global variable to true, since we have successfully logged in
                    Global.LoggedIn = true;


                } //end using

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error. " + ex.Message;
            }



            lblStatus.ForeColor = Color.Yellow;
            lblStatus.Text = "Logged in";
        } //end of btnLogin_Click

        private void btnExit_Click(object sender, EventArgs e)
        {   
            Application.Exit();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblServerIP_Click(object sender, EventArgs e)
        {

        }
    }
}
