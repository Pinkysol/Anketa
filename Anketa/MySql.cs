using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Anketa
{
    class MySql
    {
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=8889;username=root;password=root;database=anketa");
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static string[] GetDepartmentNames()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Факультет From departments";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MySqlDataReader reader = command.ExecuteReader();
            string[] row = new string[table.Rows.Count];
            int i = 0;
            while (reader.Read())
            {
                row[i] = reader.GetString(0);
                i++;
            }
            reader.Close();
            MySql.CloseConnection(connection);
            return row;
        }

        public static string[] GetTeacherNames()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT `ФИО учителя` From teacher";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MySqlDataReader reader = command.ExecuteReader();
            string[] data = new string[table.Rows.Count];
            int i = 0;
            while (reader.Read())
            {
                data[i] = reader.GetString(0);
                i++;
            }
            reader.Close();
            MySql.CloseConnection(connection);
            return data;
        }


    }
}
