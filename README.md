
<h1>A program which uses a form that grabs and compares login credentials to an Azure and/or Microsoft SQL database.</h1>

<h2><i>NOTE: The server for this program is currently offline.</i></h2>
However, the server configuration can be changed easily by changing the connection properties in the AppGlobals libarary. 


<h3>Functionality:</h3>
If the credentials match, the main Form will come up, and prompt the user to log out.

When logging in, the program sends an SQL UPDATE command to change the "isLoggedIn" (datatype: bit) to a 1. 
Logging out (by pressing the logout button) will change the "isLoggedIn" field for the user currently logged in to a 0. 

If successful, frmMain closes and it returns you to the login form.  

This also supports login creation on my server. Duplicate usernames are not allowed, and all passwords entered are never sent in plain text to the server, but rather the passwords are all salt hashed! 



<h3>Snapshots:</h3>
<img src="https://github.com/jacobbetz/LoginSQL/blob/master/login.png">
<img src="https://github.com/jacobbetz/LoginSQL/blob/master/auth.png">
<img src="https://github.com/jacobbetz/LoginSQL/blob/master/logout.png">
