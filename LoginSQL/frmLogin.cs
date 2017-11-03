using System;
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
                    tbPasswordHash.Text = Hash.GetMD5Hash(pw);
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
                    btnCreateHash.PerformClick();
                    Clipboard.SetText(tbPasswordHash.Text);
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
                else if(Login.CheckUsername(tbUsername.Text))
                {

                    var authForm = new frmAuth();
                    authForm.ShowDialog();

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
                            if (result == DialogResult.Yes && Login.CheckUsername(tbUsername.Text))
                            {
                                //generate the hashed password, then grab the output from PassHash textbox
                                btnCreateHash.PerformClick();
                                //CREATE
                                Login.CreateLogin(Global.tblLogins, tbUsername.Text.Trim(), tbPasswordHash.Text.Trim());
                            }
                            else if(result == DialogResult.No)
                            {
                                MessageBox.Show("The account was not created.", "CREATE ACCOUNT", MessageBoxButtons.OK);
                                
                            }
                            else if(!Login.CheckUsername(tbUsername.Text))
                            {
                                MessageBox.Show("The account was not created. \nThe account with the username of '" + tbUsername.Text + "' currently exists.", "CREATE ACCOUNT", MessageBoxButtons.OK);
                            }
                        }

                    }
                    else
                    {

                    }
                }
                else
                {

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

        private void btnCheckUsername_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.CheckUsername(tbUsername.Text))
                {
                    //if this method returns true, then the username does not exist in the database.
                    MessageBox.Show("Your username is available!", "Username Check", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Your username is not available.", "Username Check", MessageBoxButtons.OK);
                }
            }
            catch (SqlException SqlEx)
            {
                MessageBox.Show("SQL ERROR:\n" + SqlEx.Message, "SQL ERROR", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:\n" + ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }
    }
}
