using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            textBoxStartTrackingNo.Text = Settings1.Default.strt_trck_no.ToString();
            textBoxEndTrackingNo.Text = Settings1.Default.end_trck_no.ToString();
            textBoxPrivousTrakcingNo.Text = Settings1.Default.prvs_trackingno.ToString();
        }

        private void textBoxStartTrackingNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void textBoxEndTrackingNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            Settings1.Default.strt_trck_no = int.Parse(textBoxStartTrackingNo.Text);
            Settings1.Default.end_trck_no = int.Parse(textBoxEndTrackingNo.Text);
            Settings1.Default.prvs_trackingno = int.Parse(textBoxPrivousTrakcingNo.Text);
            Settings1.Default.Save();
        }
    }
}
