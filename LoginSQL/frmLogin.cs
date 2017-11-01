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
            lblServerIP.Text = Global.liveServerName;
            tbCnnString.Text = Global.conn;
            lblCurrentDateTime.Text = DateTime.Now.ToString();
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
                        try
                        {
                            Login.SelectLogin(Global.conn, tbUsername.Text.Trim(), tbPassword.Text.Trim(), Global.tableName, 15);
                        }
                        catch (SqlException SqlEx)
                        {
                            throw SqlEx;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        //this will tell me how many rows are selected on SelectLogin. This will then display on the frmLogin as a number
                        //between buttons Exit and Login. It -should- be 1, as we are SELECTing one record
                        lblRowCount.Text = Global.rowCount;
                        Global.usrAcc = tbUsername.Text.Trim();

                        //sets the IsLoggedIn flag in MSSQL server column to 1 (true)
                        Global.LoggedIn = true;

                    }
                    
                }

                //launching frmMain
                if (Global.LoggedIn && Global.rowCount == "1")
                {
                    try
                    {
                        lblStatus.ForeColor = Color.Violet;
                        lblStatus.Text = "Logged in";
                        //show the main form
                        var mainForm = new frmMain();
                        mainForm.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Invalid login.";
                    MessageBox.Show("Invalid login.");
                    return;
                }
            }
               
            catch (SqlException SqlEx)
            {
                lblStatus.Text = "Login failed!";
                MessageBox.Show("Sql error: \n\n" + SqlEx.Message.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex.Message.ToString());
                
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
                    return;
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Please enter a password.";
                    return;
                }
                
            } 
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
                return;
            }
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Enter a password to generate a hash.";
                    return;
                }
                else
                {
                    //simulate the hash generation button to be clicked
                    btnCreate.PerformClick();
                    Clipboard.SetText(tbPassHash.Text);
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void btnCreateLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbUsername.Text) || String.IsNullOrEmpty(tbPassword.Text))
                {
                    MessageBox.Show("Please enter a username and password in the fields, then click 'Create Login'.");
                    return;
                }
                else
                {
                    var authForm = new frmAuth();
                    authForm.Show();
                    
                    if (Global.authPass)
                    {
                        DialogResult result;
                        if (String.IsNullOrEmpty(tbUsername.Text) || String.IsNullOrEmpty(tbPassword.Text))
                        {
                            MessageBox.Show("Invalid username and/or password.");
                            return;
                        }
                        else
                        {
                            result = MessageBox.Show("Please confirm your entry: \n\n Username: " + tbUsername.Text + "\n\n Password: " + tbPassword.Text, "Create login", MessageBoxButtons.YesNo);
                            if (result == DialogResult.OK)
                            {
                                //generate the hashed password, then grab the output from PassHash textbox
                                btnCreate.PerformClick();
                                //CREATE
                                Login.CreateLogin(Global.tblLogins, tbUsername.Text.Trim(), tbPassHash.Text.Trim(), 0);
                            }
                            else
                            {
                                this.Close();
                            }
                        }

                    }
                    else
                    {

                    }
                }
               
            }
            catch (SqlException SqlEx)
            {
                MessageBox.Show("SQL error: " + SqlEx.Message, "SQL ERROR", MessageBoxButtons.OK);
                lblStatus.Text = SqlEx.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SQL ERROR", MessageBoxButtons.OK);
                lblStatus.Text = ex.Message;
            }
            
        }
    }
}
