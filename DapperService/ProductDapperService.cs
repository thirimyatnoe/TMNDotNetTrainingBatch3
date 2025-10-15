using System;
using System.Collections.Generic;
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
    }
}
