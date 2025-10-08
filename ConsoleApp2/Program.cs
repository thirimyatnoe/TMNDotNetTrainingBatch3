// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "DESKTOP-T9TCP3A\\SQL2014,2014"; //serverName
sqlConnectionStringBuilder.InitialCatalog = "testpos";// ီdatabaeName
sqlConnectionStringBuilder.UserID = "sa"; //username
sqlConnectionStringBuilder.Password = "global";//Pw
sqlConnectionStringBuilder.TrustServerCertificate = true;

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
connection.Open();

string query = @"SELECT [ProductId]
      ,[ProductName]
      ,[Quantity]
      ,[Price]
      ,[DeleteFlag]
  FROM [testpos].[dbo].[tbl_Product]";

SqlCommand cmd= new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt); //Excute tbe Query Fill the table

connection.Close();
for (int i = 0; i < dt.Rows.Count; i++)
{ 
    var row = dt.Rows[i];
    //Console.WriteLine(row["ProductId"]);
    int rowNo = i + 1;
    decimal price =Convert.ToDecimal(row["Price"]);
    Console.WriteLine( rowNo.ToString() +". " +row["ProductName"] + "(" + price.ToString("n0") + ")");
    //Console.WriteLine(row["Quantity"]);
    //Console.WriteLine("Price =>" +row["Price"]);
   // Console.WriteLine("--------------------------------------");

}
Console.ReadLine();


