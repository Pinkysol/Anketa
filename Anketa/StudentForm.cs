using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Anketa
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            string[] teacherNames = MySql.GetTeacherNames();
            string[] questionnaireNames = MySql.GetQuestionNames();
            for (int i = 0; i < teacherNames.Length; i++)
            {
                teacherNameСomboBox.Items.Add(teacherNames[i]);
                
            }
            for (int i = 0; i < questionnaireNames.Length; i++)
            {
                QuestionnaireNamesComboBox.Items.Add(questionnaireNames[i]);
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            if(teacherNameСomboBox.Text == string.Empty || QuestionnaireNamesComboBox.Text == string.Empty)
            {
                MessageBox.Show("Заполните все обязательные поля");
            }
            else
            {
                MySqlConnection connection = MySql.OpenConnection();
                MySqlCommand addCommand = new MySqlCommand("INSERT INTO `answers` (`Questionnaire_Id`,`Teacher_Id`,`Answer1`,`Answer2`,`Answer3`,`Answer4`,`Answer5`,`Answer6`,`Answer7`,`Answer8`,`Answer9`,`Comment`) VALUES (@QuestionnaireId,@TeacherId, @1Question, @2Question, @3Question, @4Question, @5Question, @6Question, @7Question, @8Question, @9Question, @Comment)", connection);
                int teacherId = MySql.GetTeacherId(teacherNameСomboBox.Text);
                int questionnaireId = MySql.GetQuestionnaireId(QuestionnaireNamesComboBox.Text);

                addCommand.Parameters.Add("@QuestionnaireId", MySqlDbType.Int32).Value
                    = questionnaireId;
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

                if (addCommand.ExecuteNonQuery() == 1)
                {
                    MySql.CloseConnection(connection);
                    MessageBox.Show("Ваши ответы отправлены");
                    Close();
                }
                else
                {
                    MySql.CloseConnection(connection);
                    MessageBox.Show("Ваши ответы не были отправлены");
                }
            }
        }

        private void UpdateLabels()
        {
            MySqlConnection connection = MySql.OpenConnection();
            int questionnaireId = MySql.GetQuestionnaireId(QuestionnaireNamesComboBox.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT `Question1`,`Question2`,`Question3`,`Question4`,`Question5`,`Question6`,`Question7`,`Question8`,`Question9` FROM questionnaire WHERE `Id` LIKE '%" + questionnaireId + "%'", connection);

            DataTable labelsValueTable = new DataTable();

            adapter.Fill(labelsValueTable);

            label2.Text = labelsValueTable.Rows[0][0].ToString();
            label3.Text = labelsValueTable.Rows[0][1].ToString();
            label4.Text = labelsValueTable.Rows[0][2].ToString();
            label5.Text = labelsValueTable.Rows[0][3].ToString();
            label6.Text = labelsValueTable.Rows[0][4].ToString();
            label7.Text = labelsValueTable.Rows[0][5].ToString();
            label8.Text = labelsValueTable.Rows[0][6].ToString();
            label9.Text = labelsValueTable.Rows[0][7].ToString();
            label10.Text = labelsValueTable.Rows[0][8].ToString();

            MySql.CloseConnection(connection);
        }

        private void QuestionnaireNamesComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateLabels();
        }
    }
}
