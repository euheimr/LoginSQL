using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Login.SetLogout(Global.conn, Global.tableName);
            }
        }
    }
}
