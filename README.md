# EPHT-API
.Net Core API test project for MDH EPHT using Swagger. This test application is used to test pulling configuration  
data from MDHEPHTDBDEV2 using the MDHEPHT_Test database instead of from the topics.js configuration file.  

This application uses classes to serialize JSON output from the endpoints and recreate the nested structure of topics.js  

## Requirments
- .Net Core 3.1
- Swashbuckle.AspNetCore 5.6.3
- Microsoft.EntityFrameworkCore 3.1.32
- Microsoft.EntityFrameworkCored.Design 3.1.32
- Microsoft.EntityFrameworkCore.SqlServer 3.1.32
- Microsoft.EntityFrameworkCore.Tools 3.1.32

## Swagger 
SwaggerUI default url: https://localhost:44309/index.html.  
Swagger provides a GUI which provides an easy way to interact with an API and is self-documenting. 

## App Settings
appsettings.json is currently added to the .gitignore until a credential management method is setup.  
Reach out to a member of the CGIS development team for a copy of this file if you are looking to  
setup and run this project.
