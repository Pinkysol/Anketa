using MySql.Data.MySqlClient;
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
                this.teacherNameСomboBox.Items.Add(teacherNames[i]);
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            MySqlConnection connection = MySql.OpenConnection();
            MySqlCommand addCommand = new MySqlCommand("INSERT INTO " +
                "`questionnaire` (`TeacherInitials_id`,`Владеет " +
                "культурной речью`,`Уважителен к студентам`,`Доступно " +
                "излогает материал`,`Соблюдает логическую последовательность " +
                "в изложении`,`Теоретический материал подкрепляет примерами`" +
                ",`Использует новый подход в обучении`,`Проводит индивидуальную " +
                "работу со студентами`,`Поддерживает студентов`,`Объективная оценка " +
                "студентов`,`Комментарий`) VALUES (@TeacherId, @1Question, @2Question," +
                " @3Question, @4Question, @5Question, @6Question, @7Question, " +
                "@8Question, @9Question, @Comment)", connection);
            MySqlCommand command = new MySqlCommand($"SELECT `id` FROM teacher WHERE" +
                $" `ФИО учителя` LIKE '{teacherNameСomboBox.Text}'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            int teacherId = 1;
            while (reader.Read())
            {
                teacherId = reader.GetInt32(0);
            }

            reader.Close();

            addCommand.Parameters.Add("@TeacherId", MySqlDbType.Int32).Value 
                = teacherId;
            addCommand.Parameters.Add("@1Question", MySqlDbType.Int32).Value 
                = numericUpDown1.Value;
            addCommand.Parameters.Add("@2Question", MySqlDbType.Int32).Value 
                = numericUpDown2.Value;
            addCommand.Parameters.Add("@3Question", MySqlDbType.Int32).Value
                = numericUpDown3.Value;
            addCommand.Parameters.Add("@4Question", MySqlDbType.Int32).Value
                = numericUpDown4.Value;
            addCommand.Parameters.Add("@5Question", MySqlDbType.Int32).Value
                = numericUpDown5.Value;
            addCommand.Parameters.Add("@6Question", MySqlDbType.Int32).Value
                = numericUpDown6.Value;
            addCommand.Parameters.Add("@7Question", MySqlDbType.Int32).Value
                = numericUpDown7.Value;
            addCommand.Parameters.Add("@8Question", MySqlDbType.Int32).Value
                = numericUpDown8.Value;
            addCommand.Parameters.Add("@9Question", MySqlDbType.Int32).Value
                = numericUpDown9.Value;
            addCommand.Parameters.Add("@Comment", MySqlDbType.VarChar).Value
                = CommentTextBox.Text;

            if(addCommand.ExecuteNonQuery() == 1)
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
