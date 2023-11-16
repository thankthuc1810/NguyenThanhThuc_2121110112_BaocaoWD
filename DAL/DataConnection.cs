using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source=QuynhAnh\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
