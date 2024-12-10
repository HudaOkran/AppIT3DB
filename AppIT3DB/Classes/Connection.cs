using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace AppIT3DB.Classes
{
    class Connection
    {
        public SqlConnection cn;
        public OleDbConnection cn2;
        public static string UserName;
        DataTable dt;
        SqlDataAdapter da;
      public Connection()
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-PO13V8K;Initial Catalog=DB_IT3;Integrated Security=True");
            cn2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB_IT3.mdb");
        }

     public   DataTable Execute_Select(string sql)
        {
            dt = new DataTable();
            da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }



    }
}
