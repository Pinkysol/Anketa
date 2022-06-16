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
                this.searchComboBox.Items.Add(departmentNames[i]);
            }
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.editComboBox.Items.Add(departmentNames[i]);
            }

            UpdateTeacherListDataGridView();

            UpdateTestDataGridView();
        }

        private void UpdateTeacherListDataGridView()
        {
            MySqlConnection connection = MySql.OpenConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT " +
                "`ФИО учителя`,`Кафедра` FROM departments , teacher " +
                "WHERE departments.id = teacher.Department_id AND `ФИО учителя` " +
                "LIKE '%" + searchTextBox1.Text + "%' AND `Кафедра` " +
                "LIKE '%" + searchComboBox.Text + "%'", connection);

            DataTable table = new DataTable();

            adapter.Fill(table);

            TeacherListDataGridView.DataSource = table;

            MySql.CloseConnection(connection);
        }

        private void UpdateTestDataGridView()
        {
            MySqlConnection connection = MySql.OpenConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT " +
                "questionnaire.id,`ФИО учителя`,`Владеет культурной " +
                "речью`,`Уважителен к студентам`,`Доступно излогает " +
                "материал`,`Соблюдает логическую последовательность в " +
                "изложении`,``.`Теоретический материал подкрепляет примерами`,`" +
                "`.`Использует новый подход в обучении`,`" +
                "`.`Проводит индивидуальную работу со студентами`,`" +
                "`.`Поддерживает студентов`,``.`Объективная оценка студентов`,`" +
                "`.`Комментарий` FROM questionnaire , teacher WHERE " +
                "questionnaire.TeacherInitials_id = teacher.id AND `ФИО учителя` " +
                "LIKE '%" + searchTextBox2.Text + "%'", connection);

            DataTable table = new DataTable();

            adapter.Fill(table);

            TestDataGridView.DataSource = table;

            MySql.CloseConnection(connection);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
            UpdateTestDataGridView();
        }
        private void searchTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }

        private void searchTextBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateTestDataGridView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand addCommand = new MySqlCommand("INSERT INTO `teacher`" +
                " (`ФИО учителя`,`Department_id`) VALUES (@teacherName, " +
                "@departmentId)", connection);
            MySqlCommand command = new MySqlCommand("SELECT id FROM departments" +
                " WHERE `Кафедра` LIKE '%" + editComboBox.Text + "%'", connection);
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

        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTeacherListDataGridView();
        }
    }
}
