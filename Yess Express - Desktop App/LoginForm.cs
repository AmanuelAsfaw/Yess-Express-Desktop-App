using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonPassCode_Click(object sender, EventArgs e)
        {
            if (textBoxPassCode.Text.ToString() == "0719mele@yesexpress")
            {
                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Pass-Code");
            }
        }
    }
}
