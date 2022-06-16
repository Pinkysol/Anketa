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
        public static MySqlConnection openConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=anketa");
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static void closeConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static string[] getDepartmentNames()
        {
            MySqlConnection connection = MySql.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT departmentName From departments";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MySqlDataReader reader = command.ExecuteReader();
            string[] row = new string[table.Rows.Count];
            Console.Write("\t{0}", table.Rows.Count);
            int i = 0;
            while (reader.Read())
            {
                Console.Write("\t{0}", i);
                Console.WriteLine("\t{0}", reader.GetString(0));
                row[i] = reader.GetString(0);
                i++;
            }
            reader.Close();
            MySql.closeConnection(connection);
            return row;
        }
    }
}
