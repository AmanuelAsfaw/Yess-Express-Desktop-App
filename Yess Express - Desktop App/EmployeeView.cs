using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class EmployeeView : Form
    {
        public Boolean is_add = true;
        public int update_id = -1;
        EmployeeModel updated_employee = null;
        List<EmployeeModel> employeeList = new List<EmployeeModel>();
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            if (is_add)
            {
                button_add.Visible = false;
                button_save.Text = "Add";
            }
            LoadWithQuery("SELECT * FROM Employees;");
        }
        public void LoadWithQuery(string query)
        {
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader read = cmd.ExecuteReader())
                        {
                            dataGridView1.Rows.Clear();
                            employeeList.Clear();

                            while (read.Read())
                            {
                                Button edit_button = new Button();
                                edit_button.Text = "Edit";

                                employeeList.Add(new EmployeeModel(int.Parse(read.GetValue(0).ToString()), read.GetValue(1).ToString()));

                                int rowIndex = dataGridView1.Rows.Add(new object[]
                                {
                                    read.GetValue(1),
                                    edit_button
                                });
                                dataGridView1.Rows[rowIndex].Cells[1].Value = "Edit";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void AddEmployee()
        {
            try
            {
                string sender_query = "INSERT INTO Employees (Name) VALUES (@Name)";
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sender_query;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SQLiteParameter("@Name", textBox_emp_name.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateEmployee()
        {
            try
            {
                string sender_query = "UPDATE Employees SET Name=" + textBox_emp_name.Text+  " WHERE ID == " + updated_employee.Id ;
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Employees SET Name ='" + textBox_emp_name.Text + "' WHERE ID = " + update_id;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.ToString() == "1")
            {
                try
                {
                    int row_index = dataGridView1.CurrentCell.RowIndex;
                    EmployeeModel employeeModel = new EmployeeModel(employeeList[row_index].Id, employeeList[row_index].Name);
                    updated_employee = employeeModel;
                    update_id = employeeModel.Id;
                    is_add = false;
                    button_add.Visible = true;
                    button_save.Text = "Update";
                    textBox_emp_name.Text = employeeModel.Name;
                }
                catch { }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (is_add)
            {
                // add employee
                MessageBox.Show("Add Employee " + textBox_emp_name.Text);
                AddEmployee();
            }
            else
            {
                // update employee
                MessageBox.Show("Update Employee " + textBox_emp_name.Text);
                UpdateEmployee();
                is_add = true;
            }
            LoadWithQuery("SELECT * FROM Employees;");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            is_add = true;
            button_add.Visible = false;
            updated_employee = null;
            textBox_emp_name.Text = "";
            button_save.Text = "Add";
        }
    }
}
