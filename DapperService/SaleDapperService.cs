using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperService
{
    public class SaleDapperService
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
                string query = @"SELECT [SaleId]
                              ,[ProductId]
                              ,[Quantity]
                              ,[Price]
                              ,[DeleteFlag]
                              ,[CreatedDateTime]
                              ,[ModifiedDateTime]
                          FROM [dbo].[tbl_Sale] where DeleteFlag=0 ";
                List<SaleDTO> lst = db.Query<SaleDTO>(query).ToList();

                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].SaleID);
                    Console.WriteLine(lst[i].ProductID);
                    Console.WriteLine(lst[i].Quantity);
                    Console.WriteLine(lst[i].Price);

                }
            }

        }
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlconnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"INSERT INTO [dbo].[tbl_Sale]
                           ([ProductId]
                           ,[Quantity]
                           ,[Price]
                           ,[DeleteFlag]
                           ,[CreatedDateTime]
                           ,[ModifiedDateTime])
                     VALUES
                           (1
                           ,1
                           ,3000
                           ,0
                           ,GETDATE()
                           ,GETDATE())";

                db.Execute(query);
                int result = db.Execute(query);
                string message = result > 0 ? "Save Invoice Successfully." : "Save Invoice Failed.";
                Console.WriteLine(message);

            }
    }
        
    }
    public class SaleDTO
    {

        public string SaleID { get; set; }
        public string ProductID { get; set; }
        public string Quantity { get; set; }

        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }



    }

}
