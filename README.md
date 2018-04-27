#*A program which uses a form that grabs and compares login credentials to a SQL database.*
##The server for this program is currently offline

If the credentials match, the main Form will come up, and prompt the user to log out.

When logging in, the program sends an SQL UPDATE command to change the "isLoggedIn" (datatype: bit) to a 1. 
Logging out (by pressing the logout button) will change the "isLoggedIn" field for the user currently logged in to a 0. 

If successful, frmMain closes and it returns you to the login form.  


This also supports login creation on my server. Duplicate usernames are not allowed, and all passwords entered are never sent in plain text to the server, but rather the passwords are all hashed! 

Currently, there is no real point in "logging in", but it's more of a demonstration of understanding concepts. This was a personal goal of mine.

[<img src="https://github.com/jacobbetz/LoginSQL/blob/master/login.png">]
