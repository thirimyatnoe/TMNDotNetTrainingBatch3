using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModelFirst
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlconnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-T9TCP3A\\SQL2014,2014", //serverName
                InitialCatalog = "testpos",// ီdatabaeName
                UserID = "sa", //username
                Password = "global",//Pw
                TrustServerCertificate = true

            };

            
            optionsBuilder.UseSqlServer(sqlconnectionStringBuilder.ConnectionString);

        }
       
        public DbSet<tbl_Product> Products { get; set; }

    }

    [Table("tbl_Product")]//table name need to change if you change schema
    public class tbl_Product
    {
        [Key]
        public int ProductId { get; set; } 

        public string ProductName { get; set; }

        public int Quantity { get; set; } 

        public decimal Price { get; set; } 

        public bool DeleteFlag { get; set; } 

        public DateTime? CreatedDateTime { get; set; } 

        public DateTime? ModifiedDateTime { get; set; } 
    }



}
