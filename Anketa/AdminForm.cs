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

            string[] departmentNames = MySql.getDepartmentNames();
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.comboBox1.Items.Add(departmentNames[i]);
            }
            for (int i = 0; i < departmentNames.Length; i++)
            {
                this.comboBox2.Items.Add(departmentNames[i]);
            }
        }

    }
}
