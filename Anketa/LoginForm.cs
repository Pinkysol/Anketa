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
    
    public partial class LoginForm : Form
    {
        const string Password = "12345";
        public LoginForm()
        {
            InitializeComponent();
            button1.Enabled = false;
            label4.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                StudentForm newForm = new StudentForm();
                newForm.Show();
            }
            if (radioButton2.Checked)
            {
                if (textBox1.Text == Password)
                {
                    // Запустить форму администратора
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label4.Enabled = false;
            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Enabled = true;
            textBox1.Enabled = true;

        }
    }
}
