ADO.Net
Dapper
EFCore
-Model First
-Code First
-Database First

Entity
MS.Entity.Framework.Core
MS.Entity.Framework.Core.Design
MS.Entity.Framework.Core.Tools
MS.Entity.Framework.Core.SQLServer -Depend on Server SQL Type

AppDbContext =>DBContext come from EF
App may be other class Name eg:Product or sale

DbContext 
Connection Configure
dbset Configure
table declare /configure
and then fields for class

Linq
.ToList
.FirstToDefault ရှိရင်ရှိတာပေး မရှိရင် null ပေး


Database First 
need to run cmd
dotnet tool install --global dotnet-ef

-f replace for all table and content
dotnet ef dbcontext scaffold "Server=DESKTOP-T9TCP3A\SQL2014;Database=testpos;User ID = sa;Password = global;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f