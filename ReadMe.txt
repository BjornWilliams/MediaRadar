============================
To get up and running:
============================
1.	Update the connection string setting in the Web.Config file in “Hosting.WebApp” application.
		a.	Add Server and user credentials for a SQL Server DB server.
		b.	User must have permission to create database.
2.	Using Visual Studio run the Entity Framework migration commands 
		a.	Update-database: this will use the file “201902250359392_InitialCreate.cs” to create the database on the server specified in the connection string.
3.	Load website and  Push the Load Data button.
