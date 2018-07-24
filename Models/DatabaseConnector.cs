using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SCSDataBase.Models
{
    public class DatabaseConnector
    {

        private static readonly SqlConnection _connection =
            new SqlConnection(
                "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SCSKnowlegeBase;Data Source=Jonathan-Wolf");

        public static void ExecuteNonQuery(string sql, Dictionary<string, string> parameters)
        {
            ResetConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _connection))
            {
                var cmd = CreateCommand(sql, parameters);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();

        }


        public static SqlDataReader ExecuteReader(string sql, Dictionary<string, string> parameters)
        {
            ResetConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _connection))
            {
                var cmd = CreateCommand(sql, parameters);
                var result = cmd.ExecuteReader();
                return result;
            }

        }

        public static SqlDataReader ExecuteReader(string sql)
        {
            ResetConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _connection))
            {

                var cmd = CreateCommand(sql);
                var result = cmd.ExecuteReader();
                return result;

            }
        }

        private static SqlCommand CreateCommand(string sql)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            return cmd;
        }


        private static SqlCommand CreateCommand(string sql, Dictionary<string, string> parameters)
        {
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            foreach (var p in parameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }
            return cmd;
        }


        private static void ResetConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Open();

            }
            catch (Exception e)

            {

            }


        }


    }
}

