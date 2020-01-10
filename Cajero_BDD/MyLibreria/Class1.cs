using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection con = new SqlConnection(@"Data Source =LAPTOP-MUS3J725 ;Initial Catalog=CajeroAutomatico1;User ID=andrea;Password=andrea");
            con.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd,con);

            DP.Fill(DS);
            con.Close();

            return DS;
        }
    }
}
