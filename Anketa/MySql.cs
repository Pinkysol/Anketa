using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
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
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static string[] GetDepartmentNames()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT `DepartmentName` From departments";
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
            command.CommandText = "SELECT `TeacherName` From teacher";
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

        public static string[] GetQuestionnaireNames()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT `QuestionnaireName` From questionnaire";
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

        public static int GetTeacherId(string teacherName)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `Id` FROM teacher WHERE `TeacherName` LIKE '%" + teacherName + "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int teacherId = 1;
            while (reader.Read())
            {
                teacherId = reader.GetInt32(0);
            }

            reader.Close();
            MySql.CloseConnection(connection);
            return teacherId;
        }

        public static int GetDepartmentsId(string departmentName)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT Id FROM departments WHERE `DepartmentName` LIKE '%" + departmentName + "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int departmentId = 1;
            while (reader.Read())
            {
                departmentId = reader.GetInt32(0);
            }

            reader.Close();
            MySql.CloseConnection(connection);
            return departmentId;
        }

        public static int GetQuestionnaireId(string questionnaireName)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT Id FROM questionnaire WHERE `QuestionnaireName` LIKE '%" + questionnaireName + "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int departmentId = 1;
            while (reader.Read())
            {
                departmentId = reader.GetInt32(0);
            }

            reader.Close();
            MySql.CloseConnection(connection);
            return departmentId;
        }

        public static void TeacherListReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            dataGridView.Rows.Add(record.GetString(0), record.GetString(1));
        }

        public static void TestReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            dataGridView.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetInt32(6), record.GetInt32(7), record.GetInt32(8), record.GetInt32(9), record.GetInt32(10), record.GetInt32(11), record.GetString(12));
        }

        public static void StatisticsReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            dataGridView.Rows.Add(record.GetString(0), record.GetString(1), record.GetDouble(2));
        }

        public static void QuestionsReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            dataGridView.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9));
        }

        public static void CountStatistics()
        {
            //Открытие соединения
            MySqlConnection connection = MySql.OpenConnection();

            //Создание текста команды
            string commandText = "SELECT `Teacher_Id`," +
                "`Department_Id`,`Answer1`,`Answer2`,`Answer3`," +
                "`Answer4`,`Answer5`,`Answer6`,`Answer7`,`Answer8`," +
                "`Answer9` FROM answers, teacher WHERE answers.Teacher_Id" +
                " = teacher.Id";

            //Создание команды
            MySqlCommand command = new MySqlCommand(commandText, connection);

            //Создание адаптера
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            //Заполнение таблицы адаптером
            adapter.Fill(table);

            //Создание числового массива
            double[,] tableArray = new double[table.Rows.Count, 4];

            //Упрощение переменных x-вертикаль y-горизонталь
            int x = table.Rows.Count;
            int y = table.Columns.Count;

            //Заполнение числового массива значениями из таблицы
            for (int i = 0; i < x; i++)
            {
                tableArray[i, 3] = 0;
                for (int j = 0; j < y; j++)
                {
                    if (j >= 2)
                    {
                        //Запись суммы ответов на вопросы
                        tableArray[i, 2] += double.Parse(table.Rows[i][j].ToString());
                    }
                    else
                    {
                        //Запись уникальных идентификаторов из таблицы в массив
                        tableArray[i, j] = double.Parse(table.Rows[i][j].ToString());
                    }
                    
                }
            }

            for (int i = 0; i < x; i++)
            {
                //Разделить сумму на количество элементов
                tableArray[i, 2] = Math.Round((tableArray[i, 2] / 9), 2);
            }

            //Создание временного массива
            double[,] tempArray;

            //найти количество повторений преподавателей и вычислить их суммы
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
                    //Разделить сумму на количество повторений записей + 1
                    tableArray[i, 2] = Math.Round(tableArray[i, 2] / (tableArray[i, 3] + 1),2);
                }
            }

            for (int i = 0; i < x; i++)
            {
                //Создать команду поиска записи по Teacher_Id
                command = new MySqlCommand("SELECT `Teacher_Id` FROM `statistics` WHERE `Teacher_Id` LIKE @TeacherId", connection);
                //Задать значение заглушке
                command.Parameters.Add("@TeacherId", MySqlDbType.Int32).Value = tableArray[i, 0];
                //Создать DataReader
                MySqlDataReader reader = command.ExecuteReader();

                int teacherId = 0;
                while (reader.Read())
                {
                    teacherId = reader.GetInt32(0);
                }
                reader.Close();
                //Проверить существование записи, если записи нет в таблице, то добавить её
                if (teacherId==0)
                {
                    //Создать команду добавления записи статистики
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO `statistics` (`Teacher_Id`,`AverageValue`) VALUES (@teacher_id,@averageValue)", connection);
                    addCommand.Parameters.Add("@teacher_id", MySqlDbType.Double).Value = tableArray[i, 0];
                    addCommand.Parameters.Add("@averageValue", MySqlDbType.Double).Value = tableArray[i, 2];
                    //Выполнить команду
                    addCommand.ExecuteNonQuery();
                }
                else
                {
                    //Создать команду обновления статистики
                    command = new MySqlCommand($"UPDATE `statistics` SET `AverageValue` = @averageValue WHERE `Teacher_Id` LIKE '%" + teacherId + "%'", connection);
                    command.Parameters.Add("@averageValue", MySqlDbType.Double).Value = tableArray[i, 2];
                    //Выполнить команду
                    command.ExecuteNonQuery();
                }
            }
            MySql.CloseConnection(connection);
        }
    }
}
