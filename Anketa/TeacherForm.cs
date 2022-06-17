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
                this.searchComboBox1.Items.Add(departmentNames[i]);
            }
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.editComboBox.Items.Add(departmentNames[i]);
            }

            UpdateTeacherListDataGridView();
            UpdateTestDataGridView();
            MySql.CountStatistics();
            UpdateStatisticsDataGridView();
        }

        private void UpdateTeacherListDataGridView()
        {
            MySqlConnection connection = MySql.OpenConnection();

            MySqlCommand command = new MySqlCommand("SELECT" +
                " `ФИО учителя`,`Кафедра` FROM `departments`," +
                " `teacher` WHERE departments.id = teacher." +
                "Department_id AND `ФИО учителя` LIKE '%" + 
                searchTextBox1.Text + "%' AND `Кафедра` LIKE '" +
                "%" + searchComboBox1.Text + "%'", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable teacherListTable = new DataTable();

            adapter.Fill(teacherListTable);

            dataGridView1.DataSource = teacherListTable;

            MySql.CloseConnection(connection);
        }

        private void UpdateTestDataGridView()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT" +
                $" questionnaire.id,`ФИО учителя`,`Кафедра`,`Владеет культурной" +
                $" речью`, `Уважителен к студентам`, `Доступно излогает" +
                $" материал`, `Соблюдает логическую последовательность" +
                $" в изложении`, `Теоретический материал подкрепляет" +
                $" примерами`, `Использует новый подход в обучении`," +
                $" `Проводит индивидуальную работу со студентами`, " +
                $"`Поддерживает студентов`, `Объективная оценка студентов`," +
                $" `Комментарий` FROM `questionnaire`, `teacher`, `departments` WHERE" +
                $" questionnaire.TeacherInitials_id = teacher.id AND teacher." +
                $"Department_id = departments.id AND `ФИО учителя` LIKE '%" 
                + searchTextBox2.Text + "%'AND `Кафедра` LIKE '%" + searchComboBox2.Text + "%'",
                connection);
            DataTable testTable = new DataTable();

            adapter.Fill(testTable);

            testDataGridView.DataSource = testTable;

            MySql.CloseConnection(connection);
        }

        private void UpdateStatisticsDataGridView()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT" +
                $" `ФИО учителя`,`Кафедра`,`Среднее значение` FROM " +
                $"`teacher`,`departments`,`statistics` WHERE statistics" +
                $".Teacher_id = teacher.id AND statistics.Department_id " +
                $"= departments.id AND `ФИО учителя` LIKE '%" + 
                searchTextBox3.Text + "%' AND `Кафедра` LIKE '" +
                "%" + searchComboBox3.Text + "%'", connection);
            
            DataTable statisticsTable = new DataTable();

            adapter.Fill(statisticsTable);

            statisticsDataGridView.DataSource = statisticsTable;

            MySql.CloseConnection(connection);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
            UpdateTestDataGridView();
            MySql.CountStatistics();
            UpdateStatisticsDataGridView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand addCommand = new MySqlCommand($"INSERT INTO `teacher`" +
                " (`ФИО учителя`,`Department_id`) VALUES (@teacherName, " +
                "@departmentId)", connection);
            MySqlCommand command = new MySqlCommand($"SELECT id FROM departments" +
                $" WHERE `Кафедра` LIKE '{editComboBox.Text}'", connection);
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
            int index = dataGridView1.CurrentCell.RowIndex;
            string teacherName = dataGridView1.Rows[index].Cells[0]
                .Value.ToString();

            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT `id` FROM teacher WHERE" +
                $" `ФИО учителя` LIKE '{teacherName}'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int teacherId = 0;
            while (reader.Read())
            {
                teacherId = reader.GetInt32(0);
            }
            reader.Close();
            command = new MySqlCommand($"SELECT id FROM departments" +
                $" WHERE `Кафедра` LIKE '{editComboBox.Text}'", connection);
            reader = command.ExecuteReader();

            int departmentId = 1;
            while (reader.Read())
            {
                departmentId = reader.GetInt32(0);
            }
            
            reader.Close();

            if (teacherId != 0)
            {
                command = new MySqlCommand($"DELETE FROM `questionnaire`" +
                    $" WHERE `TeacherInitials_id` LIKE '{teacherId}'", connection);
                command.ExecuteNonQuery();
                command = new MySqlCommand($" UPDATE `teacher` SET " +
                    $"`ФИО учителя` = '{editTextBox.Text}', `Department_id`" +
                    $" = '{departmentId}' WHERE id LIKE '{teacherId}'", connection);
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
            int index = dataGridView1.CurrentCell.RowIndex;
            string teacherName = dataGridView1.Rows[index].
                Cells[0].Value.ToString();

            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT `id` FROM " +
                "teacher WHERE `ФИО учителя` LIKE '%" + teacherName +
                "%'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int teacherId = 0;
            while (reader.Read())
            {
                teacherId = reader.GetInt32(0);
            }
            reader.Close();

            if (teacherId != 0)
            {
                command = new MySqlCommand($"DELETE FROM `questionnaire`" +
                    $" WHERE `TeacherInitials_id` LIKE '{teacherId}'", connection);
                command.ExecuteNonQuery();
                command = new MySqlCommand($"DELETE FROM `teacher` WHERE " +
                    $"`ФИО учителя` LIKE '{teacherName}'", connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Преподаватель был изменён");
            }
            else
            {
                MessageBox.Show("Преподаватель не был изменён");
            }

            MySql.CloseConnection(connection);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            EditRowTeacherListDataGridView();
            UpdateTeacherListDataGridView();
        }

        private void TeacherListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex>=0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                editTextBox.Text = row.Cells[0].Value.ToString();
                editComboBox.Text = row.Cells[1].Value.ToString();

            }
        }

        private void searchTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }

        private void searchTextBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateTestDataGridView();
        }

        private void searchTextBox3_TextChanged(object sender, EventArgs e)
        {
            MySql.CountStatistics();
            UpdateStatisticsDataGridView();
        }

        private void searchComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
