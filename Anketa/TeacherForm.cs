using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Anketa
{
    public partial class TeacherForm : Form
    {
        int selectedRow;
        public TeacherForm()
        {
            InitializeComponent();

            string[] departmentNames = MySql.GetDepartmentNames();

            for (int i = 0; i < departmentNames.Length; i++)
            {
                searchComboBox1.Items.Add(departmentNames[i]);
                editComboBox.Items.Add(departmentNames[i]);
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
        }
        
        private void TeacherListCreateColumns()
        {
            TeacherListDataGridView.Columns.Add("TeacherName", "ФИО преподавателя");
            TeacherListDataGridView.Columns.Add("DepartmentName", "Кафедра");
        }

        private void UpdateTeacherListDataGridView()
        {
            TeacherListDataGridView.Rows.Clear();
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT `TeacherName`,`DepartmentName` FROM `departments`,`teacher` WHERE departments.Id = teacher.Department_Id AND `TeacherName` LIKE '%" + searchTextBox1.Text + "%' AND `DepartmentName` LIKE '%" + searchComboBox1.Text + "%'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MySql.TeacherListReadSingleRow(TeacherListDataGridView,reader);
            }

            reader.Close();
            MySql.CloseConnection(connection);
        }
        private void TestCreateColumns()
        {
            TestDataGridView.Columns.Add("QuestionnaireName", "Название анкеты");
            TestDataGridView.Columns.Add("TeacherName", "ФИО преподавателя");
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
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT `Question1`,`Question2`,`Question3`,`Question4`,`Question5`,`Question6`,`Question7`,`Question8`,`Question9` FROM questionnaire WHERE `Id` LIKE '%" + questionnaireId + "%'", connection);

                DataTable labelsValueTable = new DataTable();

                adapter.Fill(labelsValueTable);

                TestDataGridView.Columns.Add("QuestionnaireName", "Название анкеты");
                TestDataGridView.Columns.Add("TeacherName", "ФИО преподавателя");
                TestDataGridView.Columns.Add("DepartmentName", "Кафедра");
                TestDataGridView.Columns.Add("Answer1", labelsValueTable.Rows[0][0].ToString());
                TestDataGridView.Columns.Add("Answer2", labelsValueTable.Rows[0][1].ToString());
                TestDataGridView.Columns.Add("Answer3", labelsValueTable.Rows[0][2].ToString());
                TestDataGridView.Columns.Add("Answer4", labelsValueTable.Rows[0][3].ToString());
                TestDataGridView.Columns.Add("Answer5", labelsValueTable.Rows[0][4].ToString());
                TestDataGridView.Columns.Add("Answer6", labelsValueTable.Rows[0][5].ToString());
                TestDataGridView.Columns.Add("Answer7", labelsValueTable.Rows[0][6].ToString());
                TestDataGridView.Columns.Add("Answer8", labelsValueTable.Rows[0][7].ToString());
                TestDataGridView.Columns.Add("Answer9", labelsValueTable.Rows[0][8].ToString());
                TestDataGridView.Columns.Add("Comment", "Комментарий");
            }

            MySqlCommand command = new MySqlCommand($"SELECT `QuestionnaireName`,`TeacherName`,`DepartmentName`,`Answer1`,`Answer2`,`Answer3`,`Answer4`,`Answer5`,`Answer6`,`Answer7`,`Answer8`,`Answer9`,`Comment` FROM `answers`,`teacher`,`departments`,`questionnaire` WHERE answers.Teacher_Id = teacher.Id AND teacher.Department_Id = departments.Id AND questionnaire.Id = answers.Questionnaire_Id AND `TeacherName` LIKE '%" + searchTextBox2.Text + "%'AND `DepartmentName` LIKE '%" + searchComboBox2.Text + "%'AND `QuestionnaireName` LIKE '%" + SearchComboBox3.Text + "%'", connection);
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
            StatisticsDataGridView.Columns.Add("TeacherName", "ФИО преподавателя");
            StatisticsDataGridView.Columns.Add("DepartmentName", "Кафедра");
            StatisticsDataGridView.Columns.Add("AverageValue", "Среднее значение");
        }
        private void UpdateStatisticsDataGridView()
        {
            StatisticsDataGridView.Rows.Clear();
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `TeacherName`,`DepartmentName`,`AverageValue` FROM `teacher`,`departments`,`statistics` WHERE statistics.Teacher_Id = teacher.Id AND teacher.Department_Id = departments.Id AND `TeacherName` LIKE '%" + searchTextBox3.Text + "%' AND `DepartmentName` LIKE '%" + searchComboBox4.Text + "%'", connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MySql.StatisticsReadSingleRow(StatisticsDataGridView, reader);
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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand addCommand = new MySqlCommand($"INSERT INTO `teacher`" +
                " (`TeacherName`,`Department_Id`) VALUES (@teacherName, " +
                "@departmentId)", connection);
            MySqlCommand command = new MySqlCommand($"SELECT Id FROM departments" +
                $" WHERE `DepartmentName` LIKE '%" + editComboBox.Text + "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int departmentId = 1;
            while (reader.Read())
            {
                departmentId = reader.GetInt32(0);
            }

            reader.Close();

            addCommand.Parameters.Add("@teacherName", MySqlDbType.VarChar).Value
                = editTextBox.Text;
            addCommand.Parameters.Add("@departmentId", MySqlDbType.Int32).Value
                = departmentId;

            if (addCommand.ExecuteNonQuery() == 1)
            {
                MySql.CloseConnection(connection);
                MessageBox.Show("Преподаватель был добавлен");
            }
            else
            {
                MySql.CloseConnection(connection);
                MessageBox.Show("Преподаватель не был добавлен");
            }
        }

        private void EditRowTeacherListDataGridView()
        {
            int index = TeacherListDataGridView.CurrentCell.RowIndex;

            MySqlConnection connection = MySql.OpenConnection();

            int teacherId = 0;
            teacherId = MySql.GetTeacherId(TeacherListDataGridView.Rows[index].Cells[0].Value.ToString());

            int departmentId = MySql.GetDepartmentsId(editComboBox.Text);

            if (teacherId != 0)
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM `answers`" +
                    $" WHERE `Teacher_Id` LIKE '%" + teacherId + "%'", connection);
                command.ExecuteNonQuery();
                command = new MySqlCommand($" UPDATE `teacher` SET `TeacherName` = '%" + editTextBox.Text + "%', `Department_Id` = '%" + departmentId + "%' WHERE Id LIKE '%" + teacherId + "%'", connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Преподаватель был изменён");
            }
            else
            {
                MessageBox.Show("Преподаватель не был изменён");
            }

        }

        private void DeleteRowTeacherListDataGridView()
        {
            int index = TeacherListDataGridView.CurrentCell.RowIndex;

            MySqlConnection connection = MySql.OpenConnection();
            int teacherId = 0;
            teacherId = MySql.GetTeacherId(TeacherListDataGridView.Rows[index].Cells[0].Value.ToString());

            if (teacherId != 0)
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM `answers`" +
                    $" WHERE `Teacher_Id` LIKE '%" + teacherId +
                "%'", connection);
                command.ExecuteNonQuery();
                command = new MySqlCommand($"DELETE FROM `teacher` WHERE " +
                    $"`TeacherName` LIKE '%" + TeacherListDataGridView.Rows[index].Cells[0].Value.ToString() + "%'", connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Преподаватель был изменён");
            }
            else
            {
                MessageBox.Show("Преподаватель не был изменён");
            }

            MySql.CloseConnection(connection);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            EditRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void TeacherListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex>=0)
            {
                DataGridViewRow row = TeacherListDataGridView.Rows[selectedRow];

                editTextBox.Text = row.Cells[0].Value.ToString();
                editComboBox.Text = row.Cells[1].Value.ToString();

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
    }
}
