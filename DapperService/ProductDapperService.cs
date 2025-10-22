using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DapperService
{
    public class ProductDapperService
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
            using (IDbConnection db = new SqlConnection(sqlconnectionStringBuilder.ConnectionString)) 
            { 
                db.Open();
                string query = @"SELECT [ProductId]
                              ,[ProductName]
                              ,[Quantity]
                              ,[Price]
                              ,[DeleteFlag]
                               FROM [testpos].[dbo].[tbl_Product] where DeleteFlag=0 ";
               List<ProductDTO> lst= db.Query<ProductDTO>(query).ToList();

                for (int i = 0; i < lst.Count; i++) 
                {
                    Console.WriteLine(lst[i].ProductName);
                    Console.WriteLine(lst[i].ProductID);

                }
            }
            
        }
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlconnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"INSERT INTO [dbo].[tbl_Product] ([ProductName],[Quantity],[Price],[DeleteFlag],[CreatedDateTime],[ModifiedDateTime]) 
                                VALUES('Banana Dapper' ,200,1000,0,GetDate(),GetDate())";
               
                db.Execute(query);
                int result =db.Execute(query);
                string message = result > 0 ? "Save Product Successful." : "Save Product Failed.";
                Console.WriteLine(message);

            }
           

        }
        public void Update()
        {
            using (IDbConnection db = new SqlConnection(sqlconnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"UPDATE [dbo].[tbl_Product]
                               SET [ProductName] = 'Test Update From Dapper' ,[Quantity] = 2,[Price] = 200,[DeleteFlag] = 0
                               WHERE ProductID=4";

                db.Execute(query);
                int result = db.Execute(query);
                string message = result > 0 ? "Update Successful." : "Update Failed.";
                Console.WriteLine(message);

            }

        }
        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sqlconnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"UPDATE [dbo].[tbl_Product]
                               SET [DeleteFlag] = 1
                               WHERE ProductID=4";

                db.Execute(query);
                int result = db.Execute(query);
                string message = result > 0 ? "Delete Successful." : "Delete Failed.";
                Console.WriteLine(message);

            }
        }
    }

    public class ProductDTO
    {
      
        public string ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public bool DeleteFlag { get; set; }

        

    }
}
