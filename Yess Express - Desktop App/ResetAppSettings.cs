using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class ResetAppSettings : Form
    {
        public ResetAppSettings()
        {
            InitializeComponent();
        }

        private void ResetAppSettings_Load(object sender, EventArgs e)
        {
            Settings1.Default.prvs_trackingno = 0;
            Settings1.Default.DatabaseCreated = false;
            Settings1.Default.Save();
            if (Settings1.Default.DatabaseCreated)
            {
                labelCreatedDB.Text = "Database Is Created!";
            }
            else
            {
                labelCreatedDB.Text = "Database Is not Created!";
            }
            labelProviousIs.Text = "Provious TrackingNo is "+ Settings1.Default.prvs_trackingno.ToString();
        }
    }
}
