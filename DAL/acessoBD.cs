using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using DTO;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class AcessoBD
    {
        private static OleDbConnection GetDbConnection()
        {

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["CadastroConnectionString"].ConnectionString;
                OleDbConnection connection = new OleDbConnection(conString);
                return connection;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDataTable(string sql)
        {
            OleDbConnection connection = GetDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;

        }


        public int Alterar(string sql)
        {

            OleDbConnection connection = GetDbConnection();
            connection.Open();
            OleDbCommand da = new OleDbCommand(sql, connection);
            int ex = da.ExecuteNonQuery();
            connection.Close();


            return ex;
        }
    }


}
