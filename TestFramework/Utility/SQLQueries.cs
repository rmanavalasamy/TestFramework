using Npgsql;
using System;

namespace TestFramework.Utility
{
    public class SQLQueries
    {
        #region SQL Queries
        #endregion

        #region postgres Sql Methods
        Npgsql.NpgsqlConnection con;

        public Npgsql.NpgsqlConnection OpenConnection(string host, string userName, string password, string dataBase)
        {
            var cs = "Host=" + host + ";Username=" + userName + ";Password=" + password + ";Database=" + dataBase;
            using var con = new NpgsqlConnection(cs);
            con.Open();
            this.con = con;
            return con;
        }

        public string ReadFromDB(string query)
        {
            using var cmd = new NpgsqlCommand(query, con);
            Console.WriteLine(cmd.ExecuteScalar().ToString());
            return cmd.ExecuteScalar().ToString();
        }
        #endregion

        #region Sql Methods


        #endregion
    }
}
