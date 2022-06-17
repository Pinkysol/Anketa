using System;
using System.Windows.Forms;

namespace Anketa
{
    
    public partial class LoginForm : Form
    {
        const string Password = "12345";
        public LoginForm()
        {
            InitializeComponent();
            logInButton.Enabled = false;
            label4.Enabled = false;
            passwordTextBox.Enabled = false;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (studentRadioButton.Checked)
            {
                StudentForm newForm = new StudentForm();
                newForm.Show();
            }
            if (teacherRadioButton.Checked)
            {
                if (passwordTextBox.Text == Password)
                {
                    TeacherForm newForm = new TeacherForm();
                    newForm.Show();
                }
                else
                {
                    MessageBox.Show(
                    "Неверный пароль",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }

            }
        }

        private void StudentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            logInButton.Enabled = true;
            label4.Enabled = false;
            passwordTextBox.Enabled = false;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            logInButton.Enabled = true;
        }

        private void TeacherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            passwordTextBox.Enabled = true;

        }
    }
}
