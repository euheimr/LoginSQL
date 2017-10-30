using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LoginLib;
using PasswordHash;
using AppGlobals;

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
            Cursor.Current = Cursors.WaitCursor;
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
                    if (!Global.LoggedIn)
                    {
                        
                        lblStatus.ForeColor = Color.Blue;
                        lblStatus.Text = "Logging in..";

                        SqlDataAdapter da = new SqlDataAdapter();
                        //run an SQL query to grab the info, then compare the info to the returned data in that table
                        Login.SelectLogin(Global.conn, tbUsername.Text.Trim(), tbPassword.Text.Trim(), Global.tableName);

                        //this will tell me how many rows are selected on SelectLogin. This will then display on the frmLogin as a number
                        //between buttons Exit and Login. It -should- be 1, as we are SELECTing one record
                        lblRowsCount.Text = Login.rowCount;
                        Global.usrAcc = tbUsername.Text.Trim();

                        //sets the IsLoggedIn flag in MSSQL server column to 1 (true)
                        Global.LoggedIn = true;

                    }
                }
                       
            }
               
            catch (SqlException SqlEx)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Sql error: " + SqlEx.Message + "";
                return;
            }

            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error: " + ex.Message + "";
                return;
            }
            
            if (Global.LoggedIn)
            {
                lblStatus.ForeColor = Color.Violet;
                lblStatus.Text = "Logged in";
                //show the main form
                var mainForm = new frmMain();
                mainForm.Show();
            }
            
            
            
            Cursor.Current = Cursors.Arrow;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    string pw = tbPassword.Text;
                    tbPassHash.Text = Hash.GetMD5Hash(pw);
                }
                
            } 
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbPassHash.Text);
        }
    }
}
