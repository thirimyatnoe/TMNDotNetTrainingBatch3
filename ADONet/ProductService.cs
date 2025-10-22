using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADONet
{
    public class ProductService
    {
        SqlConnectionStringBuilder sqlconnectionStringBuilder =new SqlConnectionStringBuilder() 
        {
            DataSource = "DESKTOP-T9TCP3A\\SQL2014,2014", //serverName
            InitialCatalog = "testpos",// ီdatabaeName
            UserID = "sa", //username
            Password = "global",//Pw
            TrustServerCertificate = true
             
        };
 
        public void Read()
        {

            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [ProductId]
                          ,[ProductName]
                          ,[Quantity]
                          ,[Price]
                          ,[DeleteFlag]
                          FROM [testpos].[dbo].[tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); //Excute tbe Query Fill the table

            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                //Console.WriteLine(row["ProductId"]);
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + "(" + price.ToString("n0") + ")");
                //Console.WriteLine(row["Quantity"]);
                //Console.WriteLine("Price =>" +row["Price"]);
                // Console.WriteLine("--------------------------------------");

            }
            Console.ReadLine();
        }
        public void Create() 
        {
            string query = @"INSERT INTO [dbo].[tbl_Product]
           ([ProductName]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag])
     VALUES
           ('Test'
           ,100
           ,1000
           ,0)";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd=new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
       
            Console.WriteLine(message);
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[tbl_Product]
   SET [ProductName] = 'Test Update'
      ,[Quantity] = 2
      ,[Price] = 400
      ,[DeleteFlag] = 0
 WHERE ProductID=4;";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Update Successful." : "Update Failed.";

            Console.WriteLine(message);


        }
        public void Delete() 
        {
            string query = @"Delete From  tbl_Product WHERE ProductID=2;";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";

            Console.WriteLine(message);

        }
    }
}
