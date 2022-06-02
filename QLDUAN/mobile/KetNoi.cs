using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Thư viện SqlDataProvider
using System.Data; // Thư viện DataSet


namespace mobile
{
    class KetNoi
    {
        private string con_str = "";
        private SqlConnection conn = null;
        public KetNoi()
        {
            con_str = @"Data Source=DESKTOP-OVVLJQ8\SQLEXPRESS;Initial Catalog=Dienthoai;Integrated Security=True";
            conn = new SqlConnection(con_str);
        }
        public bool thucthi(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
            public DataSet laydulieu(string sql,string name)
        {
            DataSet ds = new DataSet();
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(ds, name);
                }
                catch
                {

                }
                return ds;
            }
        }
        
    }
}
