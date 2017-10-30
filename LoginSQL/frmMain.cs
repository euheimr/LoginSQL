using System;
using System.Windows.Forms;
using AppGlobals;
using LoginLib;

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
                    //the SetLogout method connects to the MSSQL server and changes the LoggedIn flag to 0 (false)
                    Login.SetLogout(Global.conn, Global.usrAcc, Global.usrPass, Global.tableName);
                    Global.LoggedIn = false;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
