using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class PrintView : Form
    {
        public string senderName, senderPhone, senderCompanyNameAndAddress, senderSendDate, yesExpressReceivedPerson, yesExpressReceivedDateTime, descriptionOfGoods, killo, gram, shipmentLength, shipmentWidth, shipmentHeight, shipmentVolume,
                consigneePerson, consigneePhone, consigneeCompanyNameAndAddress, receivedDateTime, receiverName, receiverServiceType, amountReceived, specialInstruction, paymentMethod, tracking_no;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Print(this.panelPrint);
        }
        private Bitmap memoryimg;
        private void Print(Panel pnl)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            panelPrint = pnl;
            getPrintArea(pnl);
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
        }
        private void getPrintArea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        public PrintView()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PrintView_Load(object sender, EventArgs e)
        {
            /*labelTrackingNo.Text = tracking_no;
            labelSenderName.Text = senderName;
            labelSenderPhone.Text = senderPhone;
            labelShipperCompnyNameAndAddress.Text = senderCompanyNameAndAddress;
            labelShipperSignedDate.Text = senderSendDate;
            labelExpressReceiverName.Text = yesExpressReceivedPerson;
            labelExpressReceivedDateTime.Text = yesExpressReceivedDateTime;
            labelKillo.Text = killo;
            labelGram.Text = gram;
            labelForVolum.Text = shipmentVolume;
            labelForLength.Text = shipmentLength;
            labelForWidth.Text = shipmentWidth;
            labelForHeight.Text = shipmentHeight;
            labelGoodsDescription.Text = descriptionOfGoods;
            labelConsigneeContactPerson.Text = consigneePerson;
            labelConsigneePhone.Text = consigneePhone;
            labelConsigneeCompnayNameAddress.Text = consigneeCompanyNameAndAddress;
            labelReceiverName.Text = receiverName;
            labelReciverSignedDateTime.Text = receivedDateTime;
            labelServiceType.Text = receiverServiceType;
            labelAmountReceived.Text = amountReceived;
            labelPaymentMethod.Text = paymentMethod;
            labelSpecialInstructions.Text = specialInstruction;*/
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
    }
}
