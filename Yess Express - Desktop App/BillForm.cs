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
using System.Collections;

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
            comboBoxYesExpressReceiver.Text = billModel.YesExpressReceiver;
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
            textBoxShipperTIN.Text = billModel.ShipperTIN;
            textBoxConsigneeTIN.Text = billModel.ConsigneeTIN;
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
            LoadEmployee("SELECT * FROM Employees;");
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
            if(Settings1.Default.prvs_trackingno >= Settings1.Default.end_trck_no)
            {
                DialogResult res = MessageBox.Show("Tracking No outoff range.");
                return;
            }
            if (Settings1.Default.prvs_trackingno < Settings1.Default.strt_trck_no-1)
            {
                DialogResult res = MessageBox.Show("Tracking No outoff range.");
                return;
            }
            if (textBoxSenderPhone.Text.ToString().Length <= 0)
            {
                DialogResult res = MessageBox.Show("Sender Phone Required.");
                return;
            }
            if (textBoxReceiverPhone.Text.ToString().Length <= 0)
            {
                DialogResult res = MessageBox.Show("Consignee Phone Required.");
                return;
            }
            string sender_phone = textBoxSenderPhone.Text.ToString();
            string receiver_phone = textBoxReceiverPhone.Text.ToString();
            if (sender_phone.Substring(0, 1) == "0")
            {
                string second_str = sender_phone.Remove(0, 1);
                sender_phone = "+251" + second_str;
            }
            if (receiver_phone.Substring(0, 1) == "0")
            {
                string second_str = receiver_phone.Remove(0, 1);
                receiver_phone = "+251" + second_str;
            }
            int current_tracking_no = Settings1.Default.prvs_trackingno + 1;
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            string db_str;
            db_str = ConfigurationManager.AppSettings.Get("DatabaseString");
            try {
                string sender_query = "INSERT INTO Senders (Name, Phone, CompanyNamdeAddress, ShipperTIN, SenderCountry) VALUES (@Name, @Phone, @CompanyNamdeAddress, @ShipperTIN, @SenderCountry)";
                

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
                            cmd.Parameters.Add(new SQLiteParameter("@Phone", sender_phone));
                            cmd.Parameters.Add(new SQLiteParameter("@CompanyNamdeAddress", textBoxSenderCompanyNameAndAddress.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@ShipperTIN", textBoxShipperTIN.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@SenderCountry", textBoxSenderCountry.Text));
                            int Status_ = cmd.ExecuteNonQuery();
                            cmd.CommandText = "select last_insert_rowid()";
                            Int64 LastRowID64 = (Int64)cmd.ExecuteScalar();
                            LastRowID = (int)LastRowID64;
                        }
                        
                        string bill_query = "insert into Bills (tracking_no,sender_id, shipper_signed_date, yes_express_receiver, yes_express_received_datetime, item_killo, item_gram, item_length, item_width, " +
                            "item_height, item_volum, description_of_goods, consignee_contact_person,consignee_phone, consignee_company_name_address, consignee_received_datatime, receiver_name, service_type, amount_received, payment_method, special_instructions, ConsigneeTIN, Country) values(" +
                            current_tracking_no + ",'" + LastRowID.ToString() + "','" + dateTimePickerShiipperDate.Value.ToString("dd-MMM-yyyy") + "','" + comboBoxYesExpressReceiver.Text + "','" + dateTimePickerReceivedDateTime.Value.ToString("dd-MMM-yyyy") + " : " + timePickerReceivedTime.Text + "'," +
                            Double.Parse(textBoxKillo.Text) + "," + Double.Parse(textBoxGram.Text) + "," + Double.Parse(textBoxLength.Text) + "," + Double.Parse(textBoxWidth.Text) + "," + Double.Parse(textBoxHeight.Text) + "," + Double.Parse(labelForVolum.Text) + ",'" + textBoxGoodsDescription.Text + "','" +
                            textBoxReceiverContactPerson.Text + "','" + receiver_phone + "','" + textBoxReceiverCompanyNameAndAddress.Text + "','" + dateTimePickerReceiverConsignee.Value.Date.ToString("dd/MM/yyyy") + " : " + timePickerReceiverConsignee.Text + "','" + textBoxReceiverName.Text + "','" + comboBoxServiceType.Text + "'," + Double.Parse(textBoxAmountReceived.Text) + ",'" +
                            comboBoxPaymentMethod.Text + "','" + textBoxSpecialInstructions.Text + "','" + textBoxConsigneeTIN.Text+"','"+ textBoxCountry.Text + "')";
                        
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
                printView.senderPhone = sender_phone;
                printView.senderCompanyNameAndAddress = textBoxSenderCompanyNameAndAddress.Text;
                printView.senderSendDate = dateTimePickerShiipperDate.Value.ToString("dd-MMM-yyyy");
                printView.yesExpressReceivedPerson = comboBoxYesExpressReceiver.Text;
                printView.yesExpressReceivedDateTime = dateTimePickerReceivedDateTime.Value.ToString("dd-MMM-yyyy") + " : "+ timePickerReceivedTime.Text;
                printView.killo = textBoxKillo.Text;
                printView.gram = textBoxGram.Text;
                printView.shipmentLength = textBoxLength.Text;
                printView.shipmentWidth = textBoxWidth.Text;
                printView.shipmentHeight = textBoxHeight.Text;
                printView.shipmentVolume = labelForVolum.Text;
                printView.descriptionOfGoods = textBoxGoodsDescription.Text;
                printView.consigneePerson = textBoxReceiverContactPerson.Text;
                printView.consigneePhone = receiver_phone;
                printView.consigneeCompanyNameAndAddress = textBoxReceiverCompanyNameAndAddress.Text;
                printView.receiverName = textBoxReceiverName.Text;
                printView.receivedDateTime = dateTimePickerReceiverConsignee.Value.Date.ToString("dd/MM/yyyy") + " : "+ timePickerReceiverConsignee.Text;
                printView.receiverServiceType = comboBoxServiceType.Text;
                printView.amountReceived = textBoxAmountReceived.Text;
                printView.paymentMethod = comboBoxPaymentMethod.Text;
                printView.specialInstruction = textBoxSpecialInstructions.Text;
                printView.shipper_tin = textBoxShipperTIN.Text;
                printView.consignee_tin = textBoxConsigneeTIN.Text;
                printView.sender_country = textBoxSenderCountry.Text;
                printView.country = textBoxCountry.Text;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && textBoxAmountReceived.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
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

        private void LoadEmployee(string query)
        {
            ArrayList employees = new ArrayList();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader read = cmd.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                employees.Add(read.GetValue(1).ToString());
                            }
                        }

                    }
                }
                comboBoxYesExpressReceiver.DataSource = employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
