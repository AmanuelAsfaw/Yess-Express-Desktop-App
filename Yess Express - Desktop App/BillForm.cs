using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillForm_Load(object sender, EventArgs e)
        {

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
                        Int64 volum = Int64.Parse(textBoxLength.Text) * Int64.Parse(textBoxWidth.Text) * Int64.Parse(textBoxHeight.Text);
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
            PrintView printView = new PrintView();
            printView.tracking_no = textBoxTrackingNo.Text;
            printView.senderName = textBoxNameOfSender.Text;
            printView.senderPhone = textBoxSenderPhone.Text;
            printView.senderCompanyNameAndAddress = textBoxSenderCompanyNameAndAddress.Text;
            printView.senderSendDate = dateTimePickerShiipperDate.Text;
            printView.yesExpressReceivedPerson = textBoxNameOfSender.Text;
            printView.yesExpressReceivedDateTime = dateTimePickerReceivedDateTime.Text;
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
            printView.receivedDateTime = dateTimePickerReceiverConsignee.Text;
            printView.receiverServiceType = comboBoxServiceType.Text;
            printView.amountReceived = textBoxAmountReceived.Text;
            printView.paymentMethod = comboBoxPaymentMethod.Text;
            printView.specialInstruction = textBoxSpecialInstructions.Text;
            printView.ShowDialog();
        }
    }
}
