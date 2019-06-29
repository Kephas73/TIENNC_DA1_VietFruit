using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DATA
{
    public class KetNoiSQL
    {
        SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["StringCon"]);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public DataTable Tai_Du_lieu(string sql)
        {
            da = new SqlDataAdapter(sql, conn);
            var tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public void Thao_Tac_Du_Lieu(string sql)
        {

            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
