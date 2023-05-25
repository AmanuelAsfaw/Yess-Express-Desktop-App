using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class MainWindow : Form
    {
        public string currentFormName;
        private Form activeForm;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            currentFormName = "BillForm";
            buttonNewBill.Enabled = false;
            BillForm billForm = new BillForm(this);
            FormLoad(billForm);
            panelMain.AutoScroll = false;
            panelMain.HorizontalScroll.Enabled = false;
            panelMain.HorizontalScroll.Visible = false;
            panelMain.HorizontalScroll.Maximum = 0;
            panelMain.AutoScroll = true;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "ReportView" && !buttonReport.Enabled)
            {
                buttonReport.Enabled = true;
            }
            else if (currentFormName == "EmployeeView" && !buttonEmployee.Enabled)
            {
                buttonEmployee.Enabled = true;
            }
            else if (currentFormName == "EmptyBill" && !buttonEmptyBill.Enabled)
            {
                buttonEmptyBill.Enabled = true;
            }
            buttonSettings.Enabled = false;
            currentFormName = "SettingsForm";
            SettingsForm settingsForm = new SettingsForm();
            FormLoad(settingsForm);
        }

        private void FormLoad(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.AutoScroll = true;
            panelMain.Controls.Add(childForm);
            childForm.Dock = DockStyle.Left;
            childForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            childForm.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "SettingsForm" && !buttonSettings.Enabled)
            {
                buttonSettings.Enabled = true;
            }
            else if (currentFormName == "ReportView" && !buttonReport.Enabled)
            {
                buttonReport.Enabled = true;
            }
            else if (currentFormName == "EmployeeView" && !buttonEmployee.Enabled)
            {
                buttonEmployee.Enabled = true;
            }
            else if (currentFormName == "EmptyBill" && !buttonEmptyBill.Enabled)
            {
                buttonEmptyBill.Enabled = true;
            }
            buttonSearch.Enabled = false;
            currentFormName = "SearchView";
            SearchView searchView = new SearchView(this);
            FormLoad(searchView);
        }

        private void buttonNewBill_Click(object sender, EventArgs e)
        {
            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "SettingsForm" && !buttonSettings.Enabled)
            {
                buttonSettings.Enabled = true;
            }
            else if (currentFormName == "ReportView" && !buttonReport.Enabled)
            {
                buttonReport.Enabled = true;
            }
            else if (currentFormName == "EmployeeView" && !buttonEmployee.Enabled)
            {
                buttonEmployee.Enabled = true;
            }
            else if (currentFormName == "EmptyBill" && !buttonEmptyBill.Enabled)
            {
                buttonEmptyBill.Enabled = true;
            }
            buttonNewBill.Enabled = false;
            currentFormName = "BillForm";
            BillForm billForm = new BillForm(this);
            FormLoad(billForm);
        }
        public void change_to_print_view(PrintView printView)
        {
            if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            currentFormName = "PrintView";
            FormLoad(printView);
        }
        public void change_to_new_bill_form(BillForm billForm)
        {
            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            currentFormName = "BillForm";
            buttonNewBill.Enabled = false;
            FormLoad(billForm);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "SettingsForm" && !buttonSettings.Enabled)
            {
                buttonSettings.Enabled = true;
            }
            else if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "EmployeeView" && !buttonEmployee.Enabled)
            {
                buttonEmployee.Enabled = true;
            }
            else if (currentFormName == "EmptyBill" && !buttonEmptyBill.Enabled)
            {
                buttonEmptyBill.Enabled = true;
            }
            buttonReport.Enabled = false;
            currentFormName = "ReportView";
            ReportView reportView = new ReportView();
            FormLoad(reportView);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "SettingsForm" && !buttonSettings.Enabled)
            {
                buttonSettings.Enabled = true;
            }
            else if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "ReportView" && !buttonReport.Enabled)
            {
                buttonReport.Enabled = true;
            }
            else if (currentFormName == "EmptyBill" && !buttonEmptyBill.Enabled)
            {
                buttonEmptyBill.Enabled = true;
            }
            buttonEmployee.Enabled = false;
            currentFormName = "EmployeeView";
            EmployeeView employeeView = new EmployeeView();
            FormLoad(employeeView);
        }

        private void buttonEmptyBill_Click(object sender, EventArgs e)
        {

            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "SettingsForm" && !buttonSettings.Enabled)
            {
                buttonSettings.Enabled = true;
            }
            else if (currentFormName == "SearchView" && !buttonSearch.Enabled)
            {
                buttonSearch.Enabled = true;
            }
            else if (currentFormName == "BillForm" && !buttonNewBill.Enabled)
            {
                buttonNewBill.Enabled = true;
            }
            else if (currentFormName == "ReportView" && !buttonReport.Enabled)
            {
                buttonReport.Enabled = true;
            }
            else if (currentFormName == "EmployeeView" && !buttonEmployee.Enabled)
            {
                buttonEmployee.Enabled = true;
            }
            buttonEmptyBill.Enabled = false;
            currentFormName = "EmptyBill";
            PrintEmptyView printEmptyView = new PrintEmptyView();
            FormLoad(printEmptyView);
        }
    }
}
