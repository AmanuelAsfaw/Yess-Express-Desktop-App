using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace Yess_Express___Desktop_App
{
    public partial class BillForm : Form
    {
        private string StringConnection = Application.StartupPath + "local_database.db;";
        private MainWindow rootWindow;
        private int sender_id = -1;

        public BillForm(MainWindow mainWindow, BillModel billModel)
        {
            this.rootWindow = mainWindow;
            InitializeComponent();
            this.sender_id = billModel.SenderId;
            textBoxNameOfSender.Text = billModel.SenderName;
            textBoxSenderPhone.Text = billModel.SenderPhone;
            textBoxSenderCompanyNameAndAddress.Text = billModel.SenderCompanyNameAndAddress;
            textBoxReceiverOnExpress.Text = billModel.YesExpressReceiver;
            textBoxKillo.Text = billModel.ItemKillo.ToString();
            textBoxGram.Text = billModel.ItemGram.ToString();
            textBoxLength.Text = billModel.ItemLength.ToString();
            textBoxWidth.Text = billModel.ItemWidth.ToString();
            textBoxHeight.Text = billModel.ItemHeight.ToString();
            labelForVolum.Text = billModel.ItemVolum.ToString();
            textBoxGoodsDescription.Text = billModel.DescriptionOfGoods;

            textBoxReceiverContactPerson.Text = billModel.ConsigneeContactPerson;
            textBoxReceiverPhone.Text = billModel.ConsigneePhone;
            textBoxReceiverCompanyNameAndAddress.Text = billModel.ConsigneeCompanyNameAndAddress;
            textBoxReceiverName.Text = billModel.ReceiverName;
            comboBoxServiceType.Text = billModel.ServiceType;
            textBoxAmountReceived.Text = billModel.AmountReceived.ToString();
            comboBoxPaymentMethod.Text = billModel.PaymentMethod;
            textBoxSpecialInstructions.Text = billModel.SpecialInstructions;
        }

        public BillForm(MainWindow mainWindow)
        {
            this.rootWindow = mainWindow;
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            textBoxTrackingNo.Text = (Settings1.Default.prvs_trackingno + 1).ToString();
            textBoxTrackingNo.Enabled = false;
            timePickerReceivedTime.ShowUpDown = true;
            timePickerReceiverConsignee.ShowUpDown = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTrackingNo_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Tracking No on Change.");
        }

        private void textBoxLength_TextChanged(object sender, EventArgs e)
        {
            sumVolumPutResult();
        }
        private void sumVolumPutResult()
        {
            if (textBoxLength.Text != "" && textBoxLength.Text != null)
            {
                if (textBoxWidth.Text != "" && textBoxWidth.Text != null)
                {
                    if (textBoxHeight.Text != "" && textBoxHeight.Text != null)
                    {
                        Double volum = Double.Parse(textBoxLength.Text) * Double.Parse(textBoxWidth.Text) * Double.Parse(textBoxHeight.Text);
                        labelForVolum.Text = volum.ToString();
                    }
                    else
                    {
                        labelForVolum.Text = "0";
                    }
                }
                else
                {
                    labelForVolum.Text = "0";
                }
            }
            else
            {
                labelForVolum.Text = "0";
            }
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            sumVolumPutResult();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            sumVolumPutResult();
        }

        private void buttonSaveBill_Click(object sender, EventArgs e)
        {
            int current_tracking_no = Settings1.Default.prvs_trackingno + 1;
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string db_str;
            db_str = ConfigurationManager.AppSettings.Get("DatabaseString");
            try {
                string sender_query = "INSERT INTO Senders (Name, Phone, CompanyNamdeAddress) VALUES (@Name, @Phone, @CompanyNamdeAddress)";
                

                using(SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {

                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        int LastRowID = this.sender_id;
                        if(this.sender_id < 1)
                        {
                            cmd.CommandText = sender_query;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.Add(new SQLiteParameter("@Name", textBoxNameOfSender.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@Phone", textBoxSenderPhone.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@CompanyNamdeAddress", textBoxSenderCompanyNameAndAddress.Text));
                            int Status_ = cmd.ExecuteNonQuery();
                            cmd.CommandText = "select last_insert_rowid()";
                            Int64 LastRowID64 = (Int64)cmd.ExecuteScalar();
                            LastRowID = (int)LastRowID64;
                        }
                        
                        string bill_query = "insert into Bills (tracking_no,sender_id, shipper_signed_date, yes_express_receiver, yes_express_received_datetime, item_killo, item_gram, item_length, item_width, " +
                            "item_height, item_volum, description_of_goods, consignee_contact_person,consignee_phone, consignee_company_name_address, consignee_received_datatime, receiver_name, service_type, amount_received, payment_method, special_instructions) values(" +
                            current_tracking_no + ",'" + LastRowID.ToString() + "','" + dateTimePickerShiipperDate.Text + "','" + textBoxReceiverOnExpress.Text + "','" + dateTimePickerReceivedDateTime.Text + " : " + timePickerReceivedTime.Text + "'," +
                            Double.Parse(textBoxKillo.Text) + "," + Double.Parse(textBoxGram.Text) + "," + Double.Parse(textBoxLength.Text) + "," + Double.Parse(textBoxWidth.Text) + "," + Double.Parse(textBoxHeight.Text) + "," + Double.Parse(labelForVolum.Text) + ",'" + textBoxGoodsDescription.Text + "','" +
                            textBoxReceiverContactPerson.Text + "','" + textBoxReceiverPhone.Text + "','" + textBoxReceiverCompanyNameAndAddress.Text + "','" + dateTimePickerReceiverConsignee.Text + " : " + timePickerReceiverConsignee.Text + "','" + textBoxReceiverName.Text + "','" + comboBoxServiceType.Text + "'," + Double.Parse(textBoxAmountReceived.Text) + ",'" +
                            comboBoxPaymentMethod.Text + "','" + textBoxSpecialInstructions.Text + "')";
                        Console.WriteLine(bill_query);
                        cmd.CommandText = bill_query;
                        cmd.ExecuteNonQuery();
                    }
                }
                


                Settings1.Default.prvs_trackingno = current_tracking_no;
                Settings1.Default.Save();

                PrintView printView = new PrintView();
                printView.tracking_no = current_tracking_no.ToString();
                printView.senderName = textBoxNameOfSender.Text;
                printView.senderPhone = textBoxSenderPhone.Text;
                printView.senderCompanyNameAndAddress = textBoxSenderCompanyNameAndAddress.Text;
                printView.senderSendDate = dateTimePickerShiipperDate.Text;
                printView.yesExpressReceivedPerson = textBoxReceiverOnExpress.Text;
                printView.yesExpressReceivedDateTime = dateTimePickerReceivedDateTime.Text + " : "+ timePickerReceivedTime.Text;
                printView.killo = textBoxKillo.Text;
                printView.gram = textBoxGram.Text;
                printView.shipmentLength = textBoxLength.Text;
                printView.shipmentWidth = textBoxWidth.Text;
                printView.shipmentHeight = textBoxHeight.Text;
                printView.shipmentVolume = labelForVolum.Text;
                printView.descriptionOfGoods = textBoxGoodsDescription.Text;
                printView.consigneePerson = textBoxReceiverContactPerson.Text;
                printView.consigneePhone = textBoxReceiverPhone.Text;
                printView.consigneeCompanyNameAndAddress = textBoxReceiverCompanyNameAndAddress.Text;
                printView.receiverName = textBoxReceiverName.Text;
                printView.receivedDateTime = dateTimePickerReceiverConsignee.Text+ " : "+ timePickerReceiverConsignee.Text;
                printView.receiverServiceType = comboBoxServiceType.Text;
                printView.amountReceived = textBoxAmountReceived.Text;
                printView.paymentMethod = comboBoxPaymentMethod.Text;
                printView.specialInstruction = textBoxSpecialInstructions.Text;
                rootWindow.change_to_print_view(printView);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private void textBoxKillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxKillo.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxGram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxGram.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxLength.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxWidth.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxHeight.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxAmountReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void textBoxReceiverPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '+' && textBoxReceiverPhone.Text.LastIndexOf('+') == 0)
            {
                e.Handled = true;
            }
        }

        private void textBoxSenderPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '+' && textBoxSenderPhone.Text.LastIndexOf('+') == 0)
            {
                e.Handled = true;
            }
        }

    }
}
