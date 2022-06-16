using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Anketa
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            string[] departmentNames = MySql.GetDepartmentNames();
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.comboBox1.Items.Add(departmentNames[i]);
            }
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.comboBox2.Items.Add(departmentNames[i]);
            }
            UpdateDataGridView2();
        }
        private void UpdateDataGridView2()
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT questionnaire.id,`ФИО учителя`,`Владеет культурной речью`,`Уважителен к студентам`,`Доступно излогает материал`,`Соблюдает логическую последовательность в изложении`,``.`Теоретический материал подкрепляет примерами`,``.`Использует новый подход в обучении`,``.`Проводит индивидуальную работу со студентами`,``.`Поддерживает студентов`,``.`Объективная оценка студентов`,``.`Комментарий` FROM questionnaire , teacher WHERE questionnaire.TeacherInitials_id = teacher.id;", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            MySql.CloseConnection(connection);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDataGridView2();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
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
                "LIKE '%" + searchTextBox.Text +"%'", connection);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView2.DataSource = table;

            MySql.CloseConnection(connection);
        }
    }
}
