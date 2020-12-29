# BlogTest
Developed in Vistual Studio 2019 with framework .NET 5.0 (Microsoft.AspNetCore.App) and MVC
Used Microsoft SQLServer 2019 Developer edition as Database (configuration for connection is in the appsettings.json - user and password must be created)

Used Packages
Microsoft.AspNetCore
Microsoft.EntityFramework
Microsoft.VisualStudio.Web.CodeGeneration

Total develop time: 32 hours

Database backup added at DBBlog.bak

Users: (passwords are the same user)
Editor-> mjimenez
Writer-> mjimenez2

Query endpoint example: https://localhost:44307/Blogs/IndexJSON
Approval endpoint example: https://localhost:44307/Blogs/EditJSON/14?BlogStatus=2 
(Where 14 is the id of the Blog and BlogStatus is the status: 1 for pending, 2 for approved and 3 for rejected)
