using System;
using System.Windows.Forms;
using AppGlobals;
using LoginLib;
using System.Data.SqlClient;
using System.Drawing;

namespace LoginSQL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Global.LoggedIn)
            {
                try
                {
                    lblStatusMain.ForeColor = Color.Black;
                    lblStatusMain.Text = "Logging out..";
                    //the SetLogout method connects to the MSSQL server and changes the LoggedIn flag to 0 (false)
                    Login.SetLogout(Global.conn, Global.usrAcc, Global.usrPass, Global.tableName);
                    Global.LoggedIn = false;

                    this.Close();
                }
                catch (SqlException SqlEx)
                {
                    MessageBox.Show("Sql error: " + SqlEx.Message);
                    return;

                }
                catch (Exception ex)
                {
                    lblStatusMain.ForeColor = Color.Red;
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }
                
            }
            else
            {
                //don't open the form, dummy!
                this.Close();
            }
            
        }
    }
}
