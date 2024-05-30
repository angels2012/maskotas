# CRUD application for pet management 
This is a simple application developed in ASP.NET Core 8.0.
It uses controllers for the backend, and the frontend is server through the wwwroot folder.

## Caution
As far as I can tell, there are 2 problems with this app:
1. It reads the token signing key from appsettings.json, where it's stored in plain-text.
2. It reads the database connection string from appsettings.json, where it's stored in plain-text.
Since this is a development build I made to help me learn some ASP.NET and vanilla front-end, I'm gonna let this work as it is for the time being.
For others' use, I removed the connection string and signing key from appsettings.json, so you have to put in your own.

# How to use
1. Install the .NET SDK 8.0
2. Install SQL Server and SQL Server Management Studio 19 (SSMS)
3. Setup a user in SSMS for this app to use
4. Create the connection string and add it to appsettings.json, under "DefaultConnection":
5. Securely generate a random string of characters and put it in the signing key in appsettings.json, under "SigningKey":. It has to be at least 64 characters long.
6. Run with `dotnet watch` or `dotnet run`