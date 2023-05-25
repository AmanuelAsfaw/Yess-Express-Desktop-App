﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class PrintEmptyView : Form
    {
        public int current_tracking_no = 0;
        public string senderName, senderPhone, senderCompanyNameAndAddress, senderSendDate, yesExpressReceivedPerson, yesExpressReceivedDateTime, descriptionOfGoods, killo, gram, shipmentLength, shipmentWidth, shipmentHeight, shipmentVolume,
                consigneePerson, consigneePhone, consigneeCompanyNameAndAddress, receivedDateTime, receiverName, receiverServiceType, amountReceived, specialInstruction, paymentMethod, tracking_no, shipper_tin, consignee_tin, sender_country, country;

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            current_tracking_no = current_tracking_no - 1;
            labelTrackingNo.Text = current_tracking_no.ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(current_tracking_no == int.Parse((Settings1.Default.prvs_trackingno + 1).ToString()))
            {
                Settings1.Default.prvs_trackingno = current_tracking_no;
                Settings1.Default.Save();
            }
            current_tracking_no = current_tracking_no + 1;
            labelTrackingNo.Text = current_tracking_no.ToString();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*
            Graphics graphics = this.CreateGraphics();
            memoryimg = new Bitmap(this.Size.Width, this.Size.Height, graphics);
            Graphics graphics_img = Graphics.FromImage(memoryimg);
            graphics_img.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();*/
            Print(this.panelPrint);

            if (current_tracking_no == int.Parse((Settings1.Default.prvs_trackingno + 1).ToString()))
            {
                Settings1.Default.prvs_trackingno = current_tracking_no;
                Settings1.Default.Save();
            }
            current_tracking_no = current_tracking_no + 1;
            labelTrackingNo.Text = current_tracking_no.ToString();

        }
        private Bitmap memoryimg;
        private void Print(Panel pnl)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            panelPrint = pnl;
            getPrintArea(pnl);
            printDocument1.DefaultPageSettings.Landscape = true;
            var paperSize = printDocument1.PrinterSettings.PaperSizes.Cast<PaperSize>().FirstOrDefault(e => e.PaperName == "A5");
            IEnumerable<PaperSize> paperSizes = printDocument1.PrinterSettings.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA5 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A5);
            //printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;

            for (int i = 0; i < printDocument1.PrinterSettings.PaperSizes.Count; i++)
            {
                //NASSIM LOUCHANI

                if (printDocument1.PrinterSettings.PaperSizes[i].RawKind == 11)
                {
                    printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[i];
                }
            }

            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();

        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.MarginBounds;
            // e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
            //e.Graphics.DrawImage(memoryimg, this.panelPrint.Location.X, this.panelPrint.Location.Y);
            //e.Graphics.DrawImage(memoryimg, -10, -50);
            /*Bitmap b = new Bitmap(panelPrint.Width-20, panelPrint.Height-20);
            panelPrint.DrawToBitmap(b, new System.Drawing.Rectangle(0, 0, panelPrint.Width, panelPrint.Height));
            e.Graphics.DrawImage(b, -20, -40);*/
            if ((double)memoryimg.Width / (double)memoryimg.Height > (double)pagearea.Width / (double)pagearea.Height) // image is wider
            {
                pagearea.Height = (int)((double)memoryimg.Height / (double)memoryimg.Width * (double)pagearea.Width);
            }
            else
            {
                pagearea.Width = (int)((double)memoryimg.Width / (double)memoryimg.Height * (double)pagearea.Height);
            }
            pagearea.Height = Convert.ToInt32(pagearea.Height * 1.35);
            pagearea.Width = Convert.ToInt32(pagearea.Width * 1.55);
            pagearea.X = 20;
            pagearea.Y = -10;

            e.Graphics.DrawImage(memoryimg, pagearea);
        }
        private void getPrintArea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, Convert.ToInt32(pnl.Width*1.5) , Convert.ToInt32(pnl.Height*1.5)));
        }

        public PrintEmptyView()
        {
            InitializeComponent();
            this.labelSenderCompanyName.MaximumSize = new Size(498, 95);
            this.labelConsigneeCompanyName.MaximumSize = new Size(487, 95);
            this.labelDescriptionOfGoods.MaximumSize = new Size(250, 143);
            this.labelSpecialInstructions.MaximumSize = new Size(237, 143);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PrintView_Load(object sender, EventArgs e)
        {
            labelTrackingNo.Text = (Settings1.Default.prvs_trackingno + 1).ToString();
            current_tracking_no = int.Parse((Settings1.Default.prvs_trackingno + 1).ToString());
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