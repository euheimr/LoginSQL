*A program which uses a form that grabs and compares login credentials to a SQL database.*

If the credentials match, the main Form will come up, and prompt the user to log out.

When logging in, the program sends an SQL UPDATE command to change the "isLoggedIn" (datatype: bit) to a 1. 
Logging out (by pressing the logout button) will change the "isLoggedIn" field for the user currently logged in to a 0. 

If successful, frmMain closes and it returns you to the login form.  
