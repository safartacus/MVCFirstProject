using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.dal
{
    public class SqlDataProcess : IDisposable
    {
        SqlConnection conn;
        SqlCommand cmd;

        public SqlDataProcess()
        {
            conn = new SqlConnection(ConnectionString.Connection);
        }
        private void SqlConnectionOpen()
        {
            if (ConnectionState.Open != conn.State)
            {
                conn.Open();
            }
        }
        private void SqlConnectionClose()
        {
            if (ConnectionState.Open == conn.State)
            {
                conn.Close();
            }
        }
        public DataTable GetExecuteDataTable(string _cmd, CommandType commandType)
        {
            using (cmd = new SqlCommand(_cmd, conn))
            {
                SqlConnectionOpen();
                DataTable dataTable = new DataTable();
                cmd.CommandType = commandType;
                dataTable.Load(cmd.ExecuteReader());
                return dataTable;
            }
        }
        public DataTable GetExecuteDataTable(string _cmd, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            using (cmd = new SqlCommand(_cmd, conn))
            {
                SqlConnectionOpen();
                DataTable dataTable = new DataTable();
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);
                dataTable.Load(cmd.ExecuteReader());
                return dataTable;
            }
        }
        public bool SetExecuteNonQuery(string _cmd, CommandType commandType)
        {
            try
            {
                using (cmd = new SqlCommand(_cmd, conn))
                {
                    SqlConnectionOpen();
                    cmd.CommandType = commandType;
                    cmd.ExecuteNonQuery();
                    SqlConnectionClose();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool SetExecuteNonQuery(string _cmd, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (cmd = new SqlCommand(_cmd, conn))
                {
                    SqlConnectionOpen();
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                    SqlConnectionClose();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            SqlConnectionClose();
        }
    }
}