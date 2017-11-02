using AppGlobals;
using LoginLib;
using PasswordHash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSQL
{
    public partial class frmAuth : Form
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        private void frmAuth_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //check auth password
            //if valid, close form, send auth result to frmMain

            //prompt "are you sure?"
            try
            {
                if (String.IsNullOrEmpty(tbAuthPass.Text))
                {
                    MessageBox.Show("Please enter the password to create a login.");
                    return;
                }
                else
                {
                    string authPass = Hash.GetMD5Hash(tbAuthPass.Text.Trim());
                    //then INSERT new info, on submitting -yes-
                    if (Login.CheckAuthPass(authPass))
                    {
                        Global.authPass = true;
                        this.Close();
                    }
                    else
                    {
                        Global.authPass = false;
                        MessageBox.Show("Invalid auth password.", "AUTH ERROR", MessageBoxButtons.OK);
                        this.Close();
                    }


                }
            }
            catch (SqlException SqlEx)
            {
                MessageBox.Show("Sql Error: " + SqlEx.Message, "SQL ERROR", MessageBoxButtons.OK);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                return;
            }

            

        }
    }
}
