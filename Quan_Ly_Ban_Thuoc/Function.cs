using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Thuoc
{
    internal class Function
    { 
        public void connection(SqlConnection conn)
        {
            string sqlconn = "Server = MSI; Database =QUANlY_NHATHUOC ; Integrated Security = True; MultipleActiveResultSets=True;";
            conn.ConnectionString = sqlconn;
            conn.Open();                          
        }

    }
}
