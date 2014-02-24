using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KreateIT.Data
{
    class DAL
    {
        public static DataSet GetDataset(string SQLString, params SQLArg[] args)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Properties.Connection.Default.SQLConnString))
            using (SqlCommand cmd = new SqlCommand(SQLString, con))
            {
                con.Open();
                cmd.CommandType = (SQLString.Contains(' ')) ? CommandType.Text : CommandType.StoredProcedure;
                foreach (SQLArg a in args)
                {
                    cmd.Parameters.AddWithValue(a.SQLVariable, a.Value ?? DBNull.Value);
                }

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                con.Close();
            }
            return ds;
        }

        public static int GetDataInt(string SQLString, params SQLArg[] args)
        {
            int? s = 0;
            using (SqlConnection con = new SqlConnection(Properties.Connection.Default.SQLConnString))
            using (SqlCommand cmd = new SqlCommand(SQLString, con))
            {
                con.Open();
                cmd.CommandType = (SQLString.Contains(' ')) ? CommandType.Text : CommandType.StoredProcedure;
                foreach (SQLArg a in args)
                {
                    cmd.Parameters.AddWithValue(a.SQLVariable, a.Value ?? DBNull.Value);
                }
                s = (int?)cmd.ExecuteScalar();
                
                con.Close();
            }
            return s ?? 0;
        }

        public static int GetDataInt(string SQLString, List<SQLArg> args)
        {
            
            int? s = 0;
            using (SqlConnection con = new SqlConnection(Properties.Connection.Default.SQLConnString))
            using (SqlCommand cmd = new SqlCommand(SQLString, con))
            {
                con.Open();
                cmd.CommandType = (SQLString.Contains(' ')) ? CommandType.Text : CommandType.StoredProcedure;
                foreach (SQLArg a in args)
                {
                    cmd.Parameters.AddWithValue(a.SQLVariable, a.Value ?? DBNull.Value);
                }
                s = (int?)cmd.ExecuteScalar();

                con.Close();
            }
            return s ?? 0;
        }

    }

    public class SQLArg
    {
        public string SQLVariable { get; set; }
        public object Value { get; set; }
        public SQLArg(string SQLVariable, object Value)
        {
            this.SQLVariable = SQLVariable;
            this.Value = Value;
        }
    }
}
