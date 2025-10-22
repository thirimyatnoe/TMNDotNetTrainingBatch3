using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet
{
    public class SaleService
    {
        SqlConnectionStringBuilder sqlconnectionStringBuilder = new SqlConnectionStringBuilder()
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

            string query = @"SELECT [SaleId]
                          ,[ProductId]
                          ,[Quantity]
                          ,[Price]
                          ,[DeleteFlag]
                          ,[CreatedDateTime]
                          ,[ModifiedDateTime]
                      FROM [dbo].[tbl_Sale] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); 

            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                //Console.WriteLine(row["ProductId"]);
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["SaleId"] + " - " + row["ProductId"] + "(" + price.ToString("n0") + ")");
               

            }
            Console.ReadLine();
        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[tbl_Sale]
                           ([ProductId]
                           ,[Quantity]
                           ,[Price]
                           ,[DeleteFlag]
                           ,[CreatedDateTime]
                           ,[ModifiedDateTime])
                     VALUES
                           (3
                           ,1
                           ,1000
                           ,0
                           ,GETDATE()
                           ,GETDATE())";

            SqlConnection connection = new SqlConnection(sqlconnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Save Invoice Successfully." : "Save Invoice Failed.";

            Console.WriteLine(message);
        }

       


    }
}
