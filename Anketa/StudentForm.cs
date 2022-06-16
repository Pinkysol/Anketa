using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Anketa
{
    public partial class StudentForm : Form
    {
        string[] teacherNames;
        public StudentForm()
        {
            InitializeComponent();
            teacherNames = MySql.GetTeacherNames();
            for (int i = 0; i < teacherNames.Length; i++)
            {
                this.comboBox1.Items.Add(teacherNames[i]);
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `questionnaire` (`TeacherInitials_id`,`Владеет культурной речью`,`Уважителен к студентам`,`Доступно излогает материал`,`Соблюдает логическую последовательность в изложении`,`Теоретический материал подкрепляет примерами`,`Использует новый подход в обучении`,`Проводит индивидуальную работу со студентами`,`Поддерживает студентов`,`Объективная оценка студентов`,`Комментарий`) VALUES (@TeacherId, @1Question, @2Question, @3Question, @4Question, @5Question, @6Question, @7Question, @8Question, @9Question, @Comment)", connection);
            //Console.WriteLine("\t{0}", comboBox1.Text);
            int teacherId = 0;

            for (int i = 0; i < teacherNames.Length; i++)
            {
                if (teacherNames[i] == comboBox1.Text)
                {
                    teacherId = i + 1;
                    break;
                }
            }

            command.Parameters.Add("@TeacherId", MySqlDbType.Int32).Value = teacherId;
            command.Parameters.Add("@1Question", MySqlDbType.Int32).Value = numericUpDown1.Value;
            command.Parameters.Add("@2Question", MySqlDbType.Int32).Value = numericUpDown2.Value;
            command.Parameters.Add("@3Question", MySqlDbType.Int32).Value = numericUpDown3.Value;
            command.Parameters.Add("@4Question", MySqlDbType.Int32).Value = numericUpDown4.Value;
            command.Parameters.Add("@5Question", MySqlDbType.Int32).Value = numericUpDown5.Value;
            command.Parameters.Add("@6Question", MySqlDbType.Int32).Value = numericUpDown6.Value;
            command.Parameters.Add("@7Question", MySqlDbType.Int32).Value = numericUpDown7.Value;
            command.Parameters.Add("@8Question", MySqlDbType.Int32).Value = numericUpDown8.Value;
            command.Parameters.Add("@9Question", MySqlDbType.Int32).Value = numericUpDown9.Value;
            command.Parameters.Add("@Comment", MySqlDbType.VarChar).Value = CommentTextBox.Text;

            if(command.ExecuteNonQuery() == 1)
            {
                MySql.CloseConnection(connection);
                MessageBox.Show("Ваши ответы отправлены");
                this.Close();
            }
            else
            {
                MySql.CloseConnection(connection);
                MessageBox.Show("Ваши ответы не были отправлены");
            }
        }
    }
}
