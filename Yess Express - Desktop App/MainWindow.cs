﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (currentFormName == "SearchView" && !buttonSearch.Enabled)
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
    }
}
