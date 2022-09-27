using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    public partial class SearchView : Form
    {
        private MainWindow rootWindow;
        List<BillModel> billList = new List<BillModel>();
        DataTable dt;
        public SearchView(MainWindow mainWindow)
        {
            rootWindow = mainWindow;
            InitializeComponent();
            dt = new DataTable();
        }

        private void SearchView_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Bills";
            LoadWithQuery(query);

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchKey = textBoxSearch.Text;
            if (textBoxSearch.Text != null && textBoxSearch.Text.Length > 2) {
                string query = "SELECT * FROM Bills WHERE sender_name like '"+ searchKey+ "' OR sender_phone like '"+searchKey+
                    "' OR sender_company_name_address like '"+searchKey+ "' OR consignee_phone like '" + searchKey+ 
                    "' OR consignee_contact_person like '"+searchKey+ "' OR consignee_company_name_address like '"+searchKey+"';";
                LoadWithQuery(query);
            }
        }
        public void LoadWithQuery(string query)
        {
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + parentdir + "\\local_database.db;"))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader read = cmd.ExecuteReader())
                    {
                        dataGridViewSearchResult.Rows.Clear();
                        billList.Clear();

                        while (read.Read())
                        {
                            Button use_button = new Button();
                            use_button.Text = "Use";

                            Button print_button = new Button();
                            print_button.Text = "Print";
                            billList.Add(new BillModel(int.Parse(read.GetValue(0).ToString()),read.GetValue(1).ToString(), read.GetValue(2).ToString(), read.GetValue(3).ToString(), read.GetValue(4).ToString(),
                                read.GetValue(5).ToString(), read.GetValue(6).ToString(), read.GetValue(7).ToString(),Double.Parse(read.GetValue(8).ToString()), Double.Parse(read.GetValue(9).ToString()), Double.Parse(read.GetValue(10).ToString()), Double.Parse(read.GetValue(11).ToString()),
                                Double.Parse(read.GetValue(12).ToString()), Double.Parse(read.GetValue(13).ToString()), read.GetValue(14).ToString(), read.GetValue(15).ToString(), read.GetValue(16).ToString(), read.GetValue(17).ToString(), read.GetValue(18).ToString(),
                                read.GetValue(19).ToString(), read.GetValue(20).ToString(), int.Parse(read.GetValue(21).ToString()), read.GetValue(22).ToString(), read.GetValue(23).ToString()));
                            
                            int rowIndex = dataGridViewSearchResult.Rows.Add(new object[]
                            {
                                print_button,
                                use_button,
                                read.GetValue(1),
                                read.GetValue(2),
                                read.GetValue(3),
                                read.GetValue(4),
                                read.GetValue(6),
                                read.GetValue(8),
                                read.GetValue(9),
                                read.GetValue(10),
                                read.GetValue(11),
                                read.GetValue(12),
                                read.GetValue(13),
                                read.GetValue(14),
                                read.GetValue(15),
                                read.GetValue(16),
                                read.GetValue(17),
                                read.GetValue(19),
                                read.GetValue(20),
                                read.GetValue(21),
                                read.GetValue(22),
                                read.GetValue(23),
                            });
                            dataGridViewSearchResult.Rows[rowIndex].Cells[0].Value = "Use";
                            dataGridViewSearchResult.Rows[rowIndex].Cells[1].Value = "Print";
                        }
                    }

                }
            }
        }
        private void clickhandler(object sender, EventArgs e, string str)
        {
            MessageBox.Show(str);
        }
        private void clickhandler2()
        {
            MessageBox.Show("str");
        }

        private void dataGridViewSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewSearchResult.CurrentCell.ColumnIndex.ToString() == "0") {
                try {
                    int row_index = dataGridViewSearchResult.CurrentCell.RowIndex;
                    BillModel billModel = new BillModel(billList[row_index].Id, billList[row_index].TrackingNo, billList[row_index].SenderName,
                        billList[row_index].SenderPhone, billList[row_index].SenderCompanyNameAndAddress, billList[row_index].ShipperSignedDate,
                        billList[row_index].YesExpressReceiver, billList[row_index].YesExpressReceivedDateTime, billList[row_index].ItemKillo,
                        billList[row_index].ItemGram, billList[row_index].ItemLength, billList[row_index].ItemWidth, billList[row_index].ItemHeight,
                        billList[row_index].ItemVolum, billList[row_index].DescriptionOfGoods, billList[row_index].ConsigneeContactPerson,
                        billList[row_index].ConsigneePhone, billList[row_index].ConsigneeCompanyNameAndAddress, billList[row_index].ReceiverName, 
                        billList[row_index].ConsigneeReceivedDateTime, billList[row_index].ServiceType, billList[row_index].AmountReceived,
                        billList[row_index].PaymentMethod, billList[row_index].SpecialInstructions);
                    BillForm billForm = new BillForm(this.rootWindow, billModel);
                    this.rootWindow.change_to_new_bill_form(billForm);
                } catch { }
            }
            else if(dataGridViewSearchResult.CurrentCell.ColumnIndex.ToString() == "1") {
                try
                {
                    int row_index = dataGridViewSearchResult.CurrentCell.RowIndex;
                    PrintView printView = new PrintView();
                    printView.tracking_no = billList[row_index].TrackingNo.ToString();
                    printView.senderName = billList[row_index].SenderName.ToString();
                    printView.senderPhone = billList[row_index].SenderPhone.ToString();
                    printView.senderCompanyNameAndAddress = billList[row_index].SenderCompanyNameAndAddress.ToString();
                    printView.senderSendDate = billList[row_index].ShipperSignedDate.ToString();
                    printView.yesExpressReceivedPerson = billList[row_index].YesExpressReceiver.ToString();
                    printView.yesExpressReceivedDateTime = billList[row_index].YesExpressReceivedDateTime.ToString();
                    printView.killo = billList[row_index].ItemKillo.ToString();
                    printView.gram = billList[row_index].ItemGram.ToString();
                    printView.shipmentLength = billList[row_index].ItemLength.ToString();
                    printView.shipmentWidth = billList[row_index].ItemWidth.ToString();
                    printView.shipmentHeight = billList[row_index].ItemHeight.ToString();
                    printView.shipmentVolume = billList[row_index].ItemVolum.ToString();
                    printView.descriptionOfGoods = billList[row_index].DescriptionOfGoods.ToString();
                    printView.consigneePerson = billList[row_index].ConsigneeContactPerson.ToString();
                    printView.consigneePhone = billList[row_index].ConsigneePhone.ToString();
                    printView.consigneeCompanyNameAndAddress = billList[row_index].ConsigneeCompanyNameAndAddress.ToString();
                    printView.receiverName = billList[row_index].ReceiverName.ToString();
                    printView.receivedDateTime = billList[row_index].ConsigneeReceivedDateTime.ToString();
                    printView.receiverServiceType = billList[row_index].ServiceType.ToString();
                    printView.amountReceived = billList[row_index].AmountReceived.ToString();
                    printView.paymentMethod = billList[row_index].PaymentMethod.ToString();
                    printView.specialInstruction = billList[row_index].SpecialInstructions.ToString();
                    this.rootWindow.change_to_print_view(printView);
                }
                catch { }
            }
        }
    }
}
