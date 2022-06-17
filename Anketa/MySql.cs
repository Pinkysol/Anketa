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
            MySqlConnection connection = new MySqlConnection
                ("server=localhost;port=8889;username=root;" +
                "password=root;database=anketa");
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
            command.CommandText = "SELECT Кафедра From departments";
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

        public static void CountStatistics()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            string commandText = "SELECT `TeacherInitials_id`,`Department_id`,`Владеет культурной " +
                $"речью`,`Уважителен к студентам`,`Доступно излогает " +
                $"материал`,`Соблюдает логическую последовательность " +
                $"в изложении`,`Теоретический материал подкрепляет " +
                $"примерами`,`Использует новый подход в обучении`,`" +
                $"Проводит индивидуальную работу со студентами`,`" +
                $"Поддерживает студентов`,`Объективная оценка " +
                $"студентов` FROM " +
                $"questionnaire, teacher WHERE questionnaire." +
                $"TeacherInitials_id = teacher.id";
            command.CommandText = commandText;
            MySqlDataAdapter adapter = new MySqlDataAdapter(commandText, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            double[,] tableArray = new double[table.Rows.Count, 4];

            List<string> row = new List<string>();
            int x = table.Rows.Count;
            int y = table.Columns.Count;

            for (int i = 0; i < x; i++)
            {
                tableArray[i, 3] = 0;
                for (int j = 0; j < y; j++)
                {
                    if (j >= 2)
                    {
                        tableArray[i, 2] += double.Parse(table.Rows[i][j].ToString());

                    }
                    else
                    {
                        row.Add(table.Rows[i][j].ToString());
                        tableArray[i, j] = double.Parse(table.Rows[i][j].ToString());
                    }
                    
                }
            }

            for (int i = 0; 
                i < x; i++)
            {
                tableArray[i, 2] = Math.Round((tableArray[i, 2] / 9), 2);
            }

            double[,] tempArray;

            for (int i = 0; i < x-1; i++)
            {
                for (int j = i + 1; j < x; j++)
                {
                    if (tableArray[i, 0] == tableArray[j, 0])
                    {
                        tableArray[i, 3] += 1;
                        tableArray[i, 2] = tableArray[j, 2] + tableArray[i, 2];
                        x--;
                        tempArray = new double[x, 4];

                        for (int k = 0; k < j; k++)
                        {
                            for (int c = 0; c < 4; c++)
                            {
                                tempArray[k, c] = tableArray[k, c];
                            }
                        }

                        for (int k = j; k < x; k++)
                        {
                            for (int c = 0; c < 4; c++)
                            {
                                tempArray[k, c] = tableArray[k+1, c];
                            }
                        }

                        tableArray = new double[x, 4];
                        for (int k = 0; k < x; k++)
                        {
                            for (int c = 0; c < 4; c++)
                            {
                                tableArray[k, c] = tempArray[k,c];
                            }
                        }
                        j--;
                    }
                }
            }

            for (int i = 0; i < x; i++)
            {
                if (tableArray[i, 3] != 0)
                {
                    tableArray[i, 2] = Math.Round(tableArray[i, 2] / (tableArray[i, 3] + 1),2);
                }
            }

            for (int i = 0; i < x; i++)
            {
                command = new MySqlCommand("SELECT `Teacher_id` FROM `statistics` WHERE `Teacher_id` LIKE @TeacherId", connection);
                command.Parameters.Add("@TeacherId", MySqlDbType.Int32).Value = tableArray[i, 0];
                MySqlDataReader reader = command.ExecuteReader();

                int teacherId = 0;
                while (reader.Read())
                {
                    teacherId = reader.GetInt32(0);
                }
                reader.Close();
                Console.WriteLine(teacherId);
                if (teacherId==0)
                {
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO `statistics` (`Teacher_id`,`Department_id`,`Среднее значение`) VALUES ({tableArray[i, 0]},{tableArray[i, 1]},@averageValue)", connection);
                    addCommand.Parameters.Add("@averageValue", MySqlDbType.Double).Value = tableArray[i, 2];
                    addCommand.ExecuteNonQuery();
                }
                else
                {
                    command = new MySqlCommand($"UPDATE `statistics` SET `Среднее значение` = @averageValue WHERE `Teacher_id` LIKE {teacherId}", connection);
                    command.Parameters.Add("@averageValue", MySqlDbType.Double).Value = tableArray[i, 2];
                    command.ExecuteNonQuery();
                }
            }
            MySql.CloseConnection(connection);
        }
    }
}
