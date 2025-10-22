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
              
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + "(" + price.ToString("n0") + ")");
              

            }
            Console.ReadLine();
        }
        public void Create() 
        {
            string query = @"INSERT INTO [dbo].[tbl_Product]
                           ([ProductName]
                           ,[Quantity]
                           ,[Price]
                           ,[DeleteFlag] 
                           ,[CreatedDateTime]
                           ,[ModifiedDateTime])
                     VALUES
                           ('WaterMelon'
                           ,350
                           ,3500
                           ,False
                           ,GETDATE()
                           ,GETDATE())";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd=new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Save Product Successful." : "Save Product Failed.";
       
            Console.WriteLine(message);
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[tbl_Product]
                           SET [ProductName] = 'Test Update'
                              ,[Quantity] = 2
                              ,[Price] = 400
                              ,[DeleteFlag] = 0
                              ,[ModifiedDateTime] =GetDate()
                         WHERE ProductID=6";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Update Product Successful." : "Update Product Failed.";

            Console.WriteLine(message);


        }
        public void Delete() 
        {
            string query = @"UPDATE [dbo].[tbl_Product]
                           SET [DeleteFlag] = 1
                           WHERE ProductID=6";
            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Delete Product Successful." : "Delete Product Failed.";

            Console.WriteLine(message);

        }
    }
}
