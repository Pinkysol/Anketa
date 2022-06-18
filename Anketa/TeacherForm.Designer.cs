
namespace Anketa
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.searchComboBox4 = new System.Windows.Forms.ComboBox();
            this.searchTextBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.StatisticsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.SearchComboBox3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.searchComboBox2 = new System.Windows.Forms.ComboBox();
            this.TestDataGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.searchTextBox2 = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TeacherListDataGridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.editTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchComboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticsDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherListDataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(12, 415);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.searchComboBox4);
            this.tabPage2.Controls.Add(this.searchTextBox3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.StatisticsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 371);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Статистика преподавателей";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Поиск по кафедре";
            // 
            // searchComboBox4
            // 
            this.searchComboBox4.FormattingEnabled = true;
            this.searchComboBox4.Location = new System.Drawing.Point(331, 6);
            this.searchComboBox4.Name = "searchComboBox4";
            this.searchComboBox4.Size = new System.Drawing.Size(121, 21);
            this.searchComboBox4.TabIndex = 3;
            this.searchComboBox4.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox4_SelectedIndexChanged);
            // 
            // searchTextBox3
            // 
            this.searchTextBox3.Location = new System.Drawing.Point(96, 6);
            this.searchTextBox3.Name = "searchTextBox3";
            this.searchTextBox3.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox3.TabIndex = 2;
            this.searchTextBox3.TextChanged += new System.EventHandler(this.SearchTextBox3_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Поиск по ФИО";
            // 
            // statisticsDataGridView
            // 
            this.StatisticsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StatisticsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.StatisticsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatisticsDataGridView.Location = new System.Drawing.Point(6, 32);
            this.StatisticsDataGridView.Name = "statisticsDataGridView";
            this.StatisticsDataGridView.Size = new System.Drawing.Size(756, 333);
            this.StatisticsDataGridView.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.SearchComboBox3);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.searchComboBox2);
            this.tabPage4.Controls.Add(this.TestDataGridView);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.searchTextBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 371);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Результаты анкетирования";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "По названию анкеты";
            // 
            // SearchComboBox3
            // 
            this.SearchComboBox3.FormattingEnabled = true;
            this.SearchComboBox3.Location = new System.Drawing.Point(614, 6);
            this.SearchComboBox3.Name = "SearchComboBox3";
            this.SearchComboBox3.Size = new System.Drawing.Size(121, 21);
            this.SearchComboBox3.TabIndex = 6;
            this.SearchComboBox3.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox3_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Поиск по кафедре";
            // 
            // searchComboBox2
            // 
            this.searchComboBox2.FormattingEnabled = true;
            this.searchComboBox2.Location = new System.Drawing.Point(331, 6);
            this.searchComboBox2.Name = "searchComboBox2";
            this.searchComboBox2.Size = new System.Drawing.Size(121, 21);
            this.searchComboBox2.TabIndex = 4;
            this.searchComboBox2.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox2_SelectedIndexChanged);
            // 
            // TestDataGridView
            // 
            this.TestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestDataGridView.Location = new System.Drawing.Point(6, 32);
            this.TestDataGridView.Name = "TestDataGridView";
            this.TestDataGridView.Size = new System.Drawing.Size(756, 333);
            this.TestDataGridView.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Поиск по ФИО";
            // 
            // searchTextBox2
            // 
            this.searchTextBox2.Location = new System.Drawing.Point(96, 6);
            this.searchTextBox2.Name = "searchTextBox2";
            this.searchTextBox2.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox2.TabIndex = 1;
            this.searchTextBox2.TextChanged += new System.EventHandler(this.SearchTextBox2_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TeacherListDataGridView);
            this.tabPage1.Controls.Add(this.deleteButton);
            this.tabPage1.Controls.Add(this.changeButton);
            this.tabPage1.Controls.Add(this.addButton);
            this.tabPage1.Controls.Add(this.editComboBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.editTextBox);
            this.tabPage1.Controls.Add(this.searchTextBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.searchComboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Редактировать список преподавателей";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TeacherListDataGridView
            // 
            this.TeacherListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TeacherListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TeacherListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeacherListDataGridView.Location = new System.Drawing.Point(307, 6);
            this.TeacherListDataGridView.Name = "TeacherListDataGridView";
            this.TeacherListDataGridView.Size = new System.Drawing.Size(455, 359);
            this.TeacherListDataGridView.TabIndex = 14;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(226, 342);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(118, 342);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 12;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 342);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // editComboBox
            // 
            this.editComboBox.FormattingEnabled = true;
            this.editComboBox.Location = new System.Drawing.Point(4, 289);
            this.editComboBox.Name = "editComboBox";
            this.editComboBox.Size = new System.Drawing.Size(297, 21);
            this.editComboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Кафедра";
            // 
            // editTextBox
            // 
            this.editTextBox.Location = new System.Drawing.Point(6, 225);
            this.editTextBox.Name = "editTextBox";
            this.editTextBox.Size = new System.Drawing.Size(295, 20);
            this.editTextBox.TabIndex = 8;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Location = new System.Drawing.Point(10, 53);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(291, 20);
            this.searchTextBox1.TabIndex = 2;
            this.searchTextBox1.TextChanged += new System.EventHandler(this.SearchTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ФИО преподавателя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Редактировать";
            // 
            // searchComboBox1
            // 
            this.searchComboBox1.FormattingEnabled = true;
            this.searchComboBox1.Location = new System.Drawing.Point(10, 107);
            this.searchComboBox1.Name = "searchComboBox1";
            this.searchComboBox1.Size = new System.Drawing.Size(291, 21);
            this.searchComboBox1.TabIndex = 5;
            this.searchComboBox1.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "По кафедре";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "По фамилии преподавателя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Найти";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TeacherForm";
            this.Text = "Анкета: Преподаватель";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticsDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherListDataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox searchComboBox4;
        private System.Windows.Forms.TextBox searchTextBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView StatisticsDataGridView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox searchComboBox2;
        private System.Windows.Forms.DataGridView TestDataGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchTextBox2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView TeacherListDataGridView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox editComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox editTextBox;
        private System.Windows.Forms.TextBox searchTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox searchComboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox SearchComboBox3;
    }
}