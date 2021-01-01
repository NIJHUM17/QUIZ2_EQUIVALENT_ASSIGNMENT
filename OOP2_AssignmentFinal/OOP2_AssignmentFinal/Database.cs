using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_AssignmentFinal
{
    class Database
    {
        public static SqlConnection ConnectDB()
        {
            string connString = @"Server=LAPTOP-2U5ORHDR\SQLEXPRESS1;Database=Books;User Id=sa;Password=database;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
