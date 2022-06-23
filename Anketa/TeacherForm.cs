using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Anketa
{
    public partial class TeacherForm : Form
    {
       
        public TeacherForm()
        {
            InitializeComponent();

            string[] departmentNames = MySql.GetDepartmentNames();

            for (int i = 0; i < departmentNames.Length; i++)
            {
                searchComboBox1.Items.Add(departmentNames[i]);
                EditComboBox.Items.Add(departmentNames[i]);
                searchComboBox2.Items.Add(departmentNames[i]);
                searchComboBox4.Items.Add(departmentNames[i]);
            }

            string[] questionnaireNames = MySql.GetQuestionNames();
            for (int i = 0; i < questionnaireNames.Length; i++)
            {
                SearchComboBox3.Items.Add(questionnaireNames[i]);
            }

            TeacherListCreateColumns();
            UpdateTeacherListDataGridView();
            TestCreateColumns();
            UpdateTestDataGridView();
            MySql.CountStatistics();
            StatisticsCreateColumns();
            UpdateStatisticsDataGridView();
            QuestionsDataGridViewCreateColumns();
            UpdateQuestionsDataGridView();
        }
        
        private void TeacherListCreateColumns()
        {
            TeacherListDataGridView.Columns.Add("TeacherName", 
                "ФИО преподавателя");
            TeacherListDataGridView.Columns.Add("DepartmentName", 
                "Кафедра");
        }

        private void UpdateTeacherListDataGridView()
        {
            //Очистка строк в DataGridView
            TeacherListDataGridView.Rows.Clear();
            //Открытие соединения
            MySqlConnection connection = MySql.OpenConnection();
            //Создание команды с командной строкой MySql
            MySqlCommand command = new MySqlCommand("SELECT " +
                "`TeacherName`,`DepartmentName` FROM `departments`" +
                ",`teacher` WHERE departments.Id = teacher." +
                "Department_Id AND `TeacherName` LIKE '%" + 
                searchTextBox1.Text + "%' AND `DepartmentName` " +
                "LIKE '%" + searchComboBox1.Text + "%'", connection);
            //Создать Data Reader и выполнить команду чтения
            MySqlDataReader reader = command.ExecuteReader();
            //Прочитать данные и записать их в DataGridView построчно
            while (reader.Read())
            {
                MySql.TeacherListReadSingleRow(TeacherListDataGridView
                    ,reader);
            }
            //Закрыть Data Reader
            reader.Close();
            //Закрыть соединение
            MySql.CloseConnection(connection);
        }

        private void TestCreateColumns()
        {
            TestDataGridView.Columns.Add("QuestionnaireName", 
                "Название анкеты");
            TestDataGridView.Columns.Add("TeacherName", 
                "ФИО преподавателя");
            TestDataGridView.Columns.Add("DepartmentName", "Кафедра");
            TestDataGridView.Columns.Add("Answer1", "Ответ1");
            TestDataGridView.Columns.Add("Answer2", "Ответ2");
            TestDataGridView.Columns.Add("Answer3", "Ответ3");
            TestDataGridView.Columns.Add("Answer4", "Ответ4");
            TestDataGridView.Columns.Add("Answer5", "Ответ5");
            TestDataGridView.Columns.Add("Answer6", "Ответ6");
            TestDataGridView.Columns.Add("Answer7", "Ответ7");
            TestDataGridView.Columns.Add("Answer8", "Ответ8");
            TestDataGridView.Columns.Add("Answer9", "Ответ9");
            TestDataGridView.Columns.Add("Comment", "Комментарий");
        }

        private void UpdateTestDataGridView()
        {
            TestDataGridView.Rows.Clear();
            MySqlConnection connection = MySql.OpenConnection();
            

            if (SearchComboBox3.Text != string.Empty)
            {
                int columnCount = TestDataGridView.Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    TestDataGridView.Columns.RemoveAt(0);
                }

                int questionnaireId = MySql.GetQuestionnaireId(SearchComboBox3.Text);
                MySqlDataAdapter adapter = new MySqlDataAdapter
                    ($"SELECT `Question1`,`Question2`,`Question3`," +
                    $"`Question4`,`Question5`,`Question6`,`Question7`" +
                    $",`Question8`,`Question9` FROM questionnaire " +
                    $"WHERE `Id` LIKE '%" + questionnaireId + "%'",
                    connection);

                DataTable labelsValueTable = new DataTable();

                adapter.Fill(labelsValueTable);

                TestDataGridView.Columns.Add("QuestionnaireName",
                    "Название анкеты");
                TestDataGridView.Columns.Add("TeacherName", "ФИО " +
                    "преподавателя");
                TestDataGridView.Columns.Add("DepartmentName", 
                    "Кафедра");
                TestDataGridView.Columns.Add("Answer1", 
                    labelsValueTable.Rows[0][0].ToString());
                TestDataGridView.Columns.Add("Answer2", 
                    labelsValueTable.Rows[0][1].ToString());
                TestDataGridView.Columns.Add("Answer3", 
                    labelsValueTable.Rows[0][2].ToString());
                TestDataGridView.Columns.Add("Answer4", 
                    labelsValueTable.Rows[0][3].ToString());
                TestDataGridView.Columns.Add("Answer5", 
                    labelsValueTable.Rows[0][4].ToString());
                TestDataGridView.Columns.Add("Answer6", 
                    labelsValueTable.Rows[0][5].ToString());
                TestDataGridView.Columns.Add("Answer7", 
                    labelsValueTable.Rows[0][6].ToString());
                TestDataGridView.Columns.Add("Answer8", 
                    labelsValueTable.Rows[0][7].ToString());
                TestDataGridView.Columns.Add("Answer9", 
                    labelsValueTable.Rows[0][8].ToString());
                TestDataGridView.Columns.Add("Comment", 
                    "Комментарий");
            }

            MySqlCommand command = new MySqlCommand($"SELECT" +
                $" `QuestionnaireName`,`TeacherName`,`DepartmentName`" +
                $",`Answer1`,`Answer2`,`Answer3`,`Answer4`,`Answer5`" +
                $",`Answer6`,`Answer7`,`Answer8`,`Answer9`,`Comment`" +
                $" FROM `answers`,`teacher`,`departments`," +
                $"`questionnaire` WHERE answers.Teacher_Id = " +
                $"teacher.Id AND teacher.Department_Id = " +
                $"departments.Id AND questionnaire.Id = " +
                $"answers.Questionnaire_Id AND `TeacherName` LIKE " +
                $"'%" + searchTextBox2.Text + "%'AND `DepartmentName`" +
                " LIKE '%" + searchComboBox2.Text + "%'AND " +
                "`QuestionnaireName` LIKE '%" + SearchComboBox3.Text 
                + "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MySql.TestReadSingleRow(TestDataGridView, reader);
            }

            reader.Close();

            MySql.CloseConnection(connection);
        }

        private void StatisticsCreateColumns()
        {
            StatisticsDataGridView.Columns.Add("TeacherName", 
                "ФИО преподавателя");
            StatisticsDataGridView.Columns.Add("DepartmentName",
                "Кафедра");
            StatisticsDataGridView.Columns.Add("AverageValue",
                "Среднее значение");
        }

        private void UpdateStatisticsDataGridView()
        {
            StatisticsDataGridView.Rows.Clear();
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT" +
                $" `TeacherName`,`DepartmentName`,`AverageValue`" +
                $" FROM `teacher`,`departments`,`statistics` WHERE" +
                $" statistics.Teacher_Id = teacher.Id AND teacher" +
                $".Department_Id = departments.Id AND `TeacherName`" +
                $" LIKE '%" + SearchTextBox3.Text + "%' AND " +
                "`DepartmentName` LIKE '%" + searchComboBox4.Text
                + "%'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MySql.StatisticsReadSingleRow(StatisticsDataGridView, reader);
            }

            reader.Close();

            MySql.CloseConnection(connection);
        }
        private void QuestionsDataGridViewCreateColumns()
        {
            QuestionsDataGridView.Columns.Add("QuestionnaireName",
                "Кафедра");
            QuestionsDataGridView.Columns.Add("Question1", "Вопрос1");
            QuestionsDataGridView.Columns.Add("Question2", "Вопрос2");
            QuestionsDataGridView.Columns.Add("Question3", "Вопрос3");
            QuestionsDataGridView.Columns.Add("Question4", "Вопрос4");
            QuestionsDataGridView.Columns.Add("Question5", "Вопрос5");
            QuestionsDataGridView.Columns.Add("Question6", "Вопрос6");
            QuestionsDataGridView.Columns.Add("Question7", "Вопрос7");
            QuestionsDataGridView.Columns.Add("Question8", "Вопрос8");
            QuestionsDataGridView.Columns.Add("Question9", "Вопрос9");
        }
        private void UpdateQuestionsDataGridView()
        {
            QuestionsDataGridView.Rows.Clear();
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT " +
                "`QuestionnaireName`,`Question1`,`Question2`" +
                ",`Question3`,`Question4`,`Question5`,`Question6`" +
                ",`Question7`,`Question8`,`Question9` FROM " +
                "`questionnaire` WHERE `QuestionnaireName` LIKE " +
                "'%" + SearchTextBox4.Text + "%'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MySql.QuestionsReadSingleRow(QuestionsDataGridView,
                    reader);
            }

            reader.Close();
            MySql.CloseConnection(connection);
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
            UpdateTestDataGridView();
            MySql.CountStatistics();
            UpdateStatisticsDataGridView();
            UpdateQuestionsDataGridView();
        }

        private void AddRowTeacherListDataGridView()
        {
            //Если TextBox и ComboBox не пусты, выполнить алгоритм, иначе вывести сообщение
            if (EditComboBox.Text != string.Empty || EditTextBox.Text != string.Empty)
            {
                //Открытие соединения
                MySqlConnection connection = MySql.OpenConnection();

                //Создание команды добавления с командной строкой MySql
                MySqlCommand addCommand = new MySqlCommand($"INSERT" +
                    $" INTO `teacher` (`TeacherName`,`Department_Id`)" +
                    $" VALUES (@teacherName, @departmentId)", connection);

                //Поиск Id выбранной кафедры, используя метод из вспомогательного класса
                int departmentId = MySql.GetDepartmentsId(EditComboBox.Text);
                
                //Замена параметров на значения переменных
                addCommand.Parameters.Add("@teacherName",
                    MySqlDbType.VarChar).Value
                    = EditTextBox.Text;
                addCommand.Parameters.Add("@departmentId",
                    MySqlDbType.Int32).Value
                    = departmentId;

                //Проверка выполнения команды
                if (addCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Преподаватель был добавлен");
                }
                else
                {
                    MessageBox.Show("Преподаватель не был добавлен");
                }
                MySql.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Введите данные для добавления");
            }
        }

        private void EditRowTeacherListDataGridView()
        {
            int index = - 1;
            index = TeacherListDataGridView.CurrentCell.RowIndex;
            if (index != -1)
            {
                MySqlConnection connection = MySql.OpenConnection();

                int teacherId = 0;
                teacherId = MySql.GetTeacherId(TeacherListDataGridView.
                    Rows[index].Cells[0].Value.ToString());

                int departmentId = MySql.GetDepartmentsId
                    (EditComboBox.Text);

                if (teacherId != 0)
                {
                    MySqlCommand command = new MySqlCommand($"DELETE " +
                        $"FROM `answers`" +
                        $" WHERE `Teacher_Id` LIKE '%" + teacherId +
                        "%'", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand($"DELETE FROM " +
                        $"`statistics` WHERE " +
                        $"`Teacher_Id` LIKE '%" + teacherId + 
                        "%'", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand($" UPDATE `teacher`" +
                        $" SET `TeacherName` = '{EditTextBox.Text}'," +
                        $" `Department_Id` = '{ departmentId }'" +
                        $" WHERE Id LIKE '{teacherId}'", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Преподаватель был изменён");
                }
                else
                {
                    MessageBox.Show("Преподаватель не был изменён");
                }

                MySql.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Выберите преподавателя для изменения");
            }
        }

        private void DeleteRowTeacherListDataGridView()
        {
            int index = -1;
            index = TeacherListDataGridView.CurrentCell.RowIndex;
            if (index != -1)
            {
                MySqlConnection connection = MySql.OpenConnection();
                int teacherId = 0;
                teacherId = MySql.GetTeacherId(TeacherListDataGridView
                    .Rows[index].Cells[0].Value.ToString());

                if (teacherId != 0)
                {
                    MySqlCommand command = new MySqlCommand($"DELETE " +
                        $"FROM `answers`" +
                        $" WHERE `Teacher_Id` LIKE '%" + teacherId +
                    "%'", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand($"DELETE FROM" +
                        $" `statistics` WHERE " +
                        $"`Teacher_Id` LIKE '%" + teacherId + 
                        "%'", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand($"DELETE FROM " +
                        $"`teacher` WHERE " +
                        $"`Id` LIKE '%" + teacherId + "%'", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Преподаватель был удалён");
                }
                else
                {
                    MessageBox.Show("Преподаватель не был удалён");
                }

                MySql.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Выберите преподавателя для удаления");
            }
        }

        private void AddRowQuestionsDataGridView()
        {
            if (QuestionnaireEditTextBox1.Text != string.Empty ||
                QuestionnaireEditTextBox2.Text != string.Empty ||
                QuestionnaireEditTextBox3.Text != string.Empty ||
                QuestionnaireEditTextBox4.Text != string.Empty ||
                QuestionnaireEditTextBox5.Text != string.Empty ||
                QuestionnaireEditTextBox6.Text != string.Empty ||
                QuestionnaireEditTextBox7.Text != string.Empty ||
                QuestionnaireEditTextBox8.Text != string.Empty ||
                QuestionnaireEditTextBox9.Text != string.Empty ||
                QuestionnaireEditTextBox10.Text != string.Empty)
            {
                MySqlConnection connection = MySql.OpenConnection();
                MySqlCommand addCommand = new MySqlCommand($"INSERT" +
                    $" INTO `questionnaire` (`QuestionnaireName`" +
                    $",`Question1`,`Question2`,`Question3`," +
                    $"`Question4`,`Question5`,`Question6`," +
                    $"`Question7`,`Question8`,`Question9`) " +
                    $"VALUES (@QuestionnaireName, @q1,@q2," +
                    $"@q3,@q4,@q5,@q6,@q7,@q8,@q9)", connection);

                addCommand.Parameters.Add("@QuestionnaireName", MySqlDbType.VarChar).Value
                    = QuestionnaireEditTextBox1.Text;
                addCommand.Parameters.Add("@q1", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox2.Text; 
                addCommand.Parameters.Add("@q2", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox3.Text; 
                addCommand.Parameters.Add("@q3", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox4.Text; 
                addCommand.Parameters.Add("@q4", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox5.Text; 
                addCommand.Parameters.Add("@q5", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox6.Text; 
                addCommand.Parameters.Add("@q6", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox7.Text; 
                addCommand.Parameters.Add("@q7", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox8.Text; 
                addCommand.Parameters.Add("@q8", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox9.Text; 
                addCommand.Parameters.Add("@q9", MySqlDbType.VarChar)
                    .Value = QuestionnaireEditTextBox10.Text;


                if (addCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Анкета была добавлена");
                }
                else
                {
                    MessageBox.Show("Анкета не была добавлена");
                }
                MySql.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Введите данные для добавления");
            }
        }

        private void EditRowQuestionsDataGridView()
        {
            int index = -1;
            index = QuestionsDataGridView.CurrentCell.RowIndex;
            if (index != -1)
            {
                if (QuestionnaireEditTextBox1.Text != string.Empty || QuestionnaireEditTextBox2.Text != string.Empty || QuestionnaireEditTextBox3.Text != string.Empty || QuestionnaireEditTextBox4.Text != string.Empty || QuestionnaireEditTextBox5.Text != string.Empty || QuestionnaireEditTextBox6.Text != string.Empty || QuestionnaireEditTextBox7.Text != string.Empty || QuestionnaireEditTextBox8.Text != string.Empty || QuestionnaireEditTextBox9.Text != string.Empty || QuestionnaireEditTextBox10.Text != string.Empty)
                {
                    ;
                    MySqlConnection connection = MySql.OpenConnection();

                    MySqlCommand command = new MySqlCommand($"UPDATE" +
                        $" `questionnaire` SET `QuestionnaireName` " +
                        $"= '{QuestionnaireEditTextBox1.Text}', " +
                        $"`Question1` = '" +
                        $"{QuestionnaireEditTextBox2.Text}', " +
                        $"`Question2` = '" +
                        $"{QuestionnaireEditTextBox3.Text}', " +
                        $"`Question3` = '" +
                        $"{QuestionnaireEditTextBox4.Text}', " +
                        $"`Question4` = '" +
                        $"{QuestionnaireEditTextBox5.Text}', " +
                        $"`Question5` = '" +
                        $"{QuestionnaireEditTextBox6.Text}', " +
                        $"`Question6` = '" +
                        $"{QuestionnaireEditTextBox7.Text}', " +
                        $"`Question7` = '" +
                        $"{QuestionnaireEditTextBox8.Text}', " +
                        $"`Question8` = '" +
                        $"{QuestionnaireEditTextBox9.Text}', " +
                        $"`Question9` = " +
                        $"'{QuestionnaireEditTextBox10.Text}' " +
                        $"WHERE `QuestionnaireName` LIKE '%" 
                        + QuestionsDataGridView.Rows[index].
                        Cells[0].Value.ToString() + "%'", connection);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Анкета была изменена");
                    }
                    else
                    {
                        MessageBox.Show("Анкета не была изменена");
                    }

                    MySql.CloseConnection(connection);
                }
                else
                {
                    MessageBox.Show("Заполните текстбоксы выше для " +
                        "изменения");
                }
            }
            else
            {
                MessageBox.Show("Выберите анкету для изменения");
            }
        }

        private void DeleteRowQuestionsDataGridView()
        {
            int index = -1;
            index = QuestionsDataGridView.CurrentCell.RowIndex;
            if (index != -1)
            {
                MySqlConnection connection = MySql.OpenConnection();
                int questionnaireId = 0;
                questionnaireId = MySql.GetQuestionnaireId(QuestionsDataGridView.Rows[index].Cells[0].Value.ToString());

                if (questionnaireId != 0)
                {
                    MySqlCommand command = new MySqlCommand($"DELETE " +
                        $"FROM `answers`" +
                        $" WHERE `Questionnaire_Id` LIKE '%" 
                        + questionnaireId + "%'", connection);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand($"DELETE FROM " +
                        $"`questionnaire` WHERE `Id` LIKE '%"
                        + questionnaireId + "%'", connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Анкета была удалёна");
                }
                else
                {
                    MessageBox.Show("Анкета не была удалёна");
                }

                MySql.CloseConnection(connection);
            }
            else
            {
                MessageBox.Show("Выберите анкету для удаления");
            }
        }
        private void AddButton1_Click(object sender, EventArgs e)
        {
            AddRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }
        private void ChangeButton1_Click(object sender, EventArgs e)
        {
            EditRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void DeleteButton1_Click(object sender, EventArgs e)
        {
            DeleteRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void TeacherListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            Console.Write(selectedRow);
            if(selectedRow >= 0)
            {
                DataGridViewRow row = TeacherListDataGridView.Rows[selectedRow];
                EditTextBox.Text = row.Cells[0].Value.ToString();
                EditComboBox.Text = row.Cells[1].Value.ToString();
            }
        }

        private void QuestionsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = QuestionsDataGridView.Rows[selectedRow];

                QuestionnaireEditTextBox1.Text = row.Cells[0].Value.ToString();
                QuestionnaireEditTextBox2.Text = row.Cells[1].Value.ToString();
                QuestionnaireEditTextBox3.Text = row.Cells[2].Value.ToString();
                QuestionnaireEditTextBox4.Text = row.Cells[3].Value.ToString();
                QuestionnaireEditTextBox5.Text = row.Cells[4].Value.ToString();
                QuestionnaireEditTextBox6.Text = row.Cells[5].Value.ToString();
                QuestionnaireEditTextBox7.Text = row.Cells[6].Value.ToString();
                QuestionnaireEditTextBox8.Text = row.Cells[7].Value.ToString();
                QuestionnaireEditTextBox9.Text = row.Cells[8].Value.ToString();
                QuestionnaireEditTextBox10.Text = row.Cells[9].Value.ToString();

            }
        }
        private void SearchTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }

        private void SearchTextBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateTestDataGridView();
        }

        private void SearchTextBox3_TextChanged(object sender, EventArgs e)
        {
            MySql.CountStatistics();
            UpdateStatisticsDataGridView();
        }

        private void SearchComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }

        private void SearchComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTestDataGridView();
        }

        private void SearchComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTestDataGridView();
        }

        private void SearchComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatisticsDataGridView();
        }

        private void SearchTextBox4_TextChanged(object sender, EventArgs e)
        {
            UpdateQuestionsDataGridView();
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            AddRowQuestionsDataGridView();
            UpdateQuestionsDataGridView();
        }

        private void EditButton2_Click(object sender, EventArgs e)
        {
            EditRowQuestionsDataGridView();
            UpdateQuestionsDataGridView();
        }

        private void DeleteButton2_Click(object sender, EventArgs e)
        {
            DeleteRowQuestionsDataGridView();
            UpdateQuestionsDataGridView();
        }
    }
}