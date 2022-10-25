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
            string query = "SELECT * FROM Bills INNER JOIN Senders ON Senders.Id = Bills.sender_id";
            LoadWithQuery(query);
            LoadSenderListToAutoComplete();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchKey = textBoxSearch.Text;
            if (textBoxSearch.Text != null && textBoxSearch.Text.Length > 2) {
                string query = "SELECT * FROM Bills INNER JOIN Senders ON Senders.Id = Bills.sender_id WHERE Senders.Name like '%" + searchKey + "%' OR Senders.ShipperTIN like'%" + searchKey+ "1%' OR Senders.Phone like '%" + searchKey+
                    "2%' OR Senders.CompanyNamdeAddress like '%" + searchKey+ "3%' OR Bills.consignee_phone like '%" + searchKey + "4%' OR Bills.ConsigneeTIN like'%" + searchKey +
                    "5%' OR Bills.consignee_contact_person like '%" + searchKey+ "6%' OR Bills.consignee_company_name_address like '%" + searchKey+"7%';";
                MessageBox.Show(query);
                LoadWithQuery(query);
            }
        }
        public void LoadWithQuery(string query)
        {
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
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
                                billList.Add(new BillModel(
                                    int.Parse(read.GetValue(0).ToString()), read.GetValue(1).ToString(), int.Parse(read.GetValue(2).ToString()), read.GetValue(25).ToString(), read.GetValue(26).ToString(), read.GetValue(27).ToString(), 
                                    read.GetValue(3).ToString(), read.GetValue(4).ToString(), read.GetValue(5).ToString(), Double.Parse(read.GetValue(6).ToString()), Double.Parse(read.GetValue(7).ToString()),
                                    Double.Parse(read.GetValue(8).ToString()), Double.Parse(read.GetValue(9).ToString()), Double.Parse(read.GetValue(10).ToString()), Double.Parse(read.GetValue(11).ToString()),read.GetValue(12).ToString(), read.GetValue(13).ToString(),
                                    read.GetValue(14).ToString(), read.GetValue(15).ToString(), read.GetValue(16).ToString(), read.GetValue(17).ToString(),
                                    read.GetValue(18).ToString(), int.Parse(read.GetValue(19).ToString()), read.GetValue(20).ToString(), read.GetValue(21).ToString(), read.GetValue(28).ToString(), read.GetValue(22).ToString()));

                                int rowIndex = dataGridViewSearchResult.Rows.Add(new object[]
                                {
                                    print_button,
                                    use_button,
                                    read.GetValue(1), // Tracking No
                                    read.GetValue(25), // Sender-Name
                                    read.GetValue(26), // Sender-Phone
                                    read.GetValue(28), // Shipper-TIN
                                    read.GetValue(27), // Sender-Company
                                    read.GetValue(4), // YesExpress -Receiver
                                    read.GetValue(6), // Killo
                                    read.GetValue(7), // Gram
                                    read.GetValue(8), // Length
                                    read.GetValue(9), // Width
                                    read.GetValue(10), // Height
                                    read.GetValue(11), // Volum
                                    read.GetValue(12), // Goods Desc
                                    read.GetValue(13), // Contact Person
                                    read.GetValue(14), // Consignee Phone
                                    read.GetValue(22), // Consignee TIN
                                    read.GetValue(15), // Consignee Compny
                                    read.GetValue(17), // Receiver
                                    read.GetValue(18), // Service Type
                                    read.GetValue(19), // Amount Received
                                    read.GetValue(20), // Payment Method
                                    read.GetValue(21), // Special Instructions
                                });
                                dataGridViewSearchResult.Rows[rowIndex].Cells[0].Value = "Use";
                                dataGridViewSearchResult.Rows[rowIndex].Cells[1].Value = "Print";
                            }
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void LoadSenderListToAutoComplete()
        {
            string query = "SELECT * FROM Senders";
            var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader read = cmd.ExecuteReader())
                        {
                            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                            while (read.Read())
                            {
                                autoCompleteStringCollection.Add(read.GetValue(1).ToString());
                            }

                            textBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBoxSearch.AutoCompleteCustomSource = autoCompleteStringCollection; 
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    BillModel billModel = new BillModel(billList[row_index].Id, billList[row_index].TrackingNo, billList[row_index].SenderId,billList[row_index].SenderName,
                        billList[row_index].SenderPhone, billList[row_index].SenderCompanyNameAndAddress, billList[row_index].ShipperSignedDate,
                        billList[row_index].YesExpressReceiver, billList[row_index].YesExpressReceivedDateTime, billList[row_index].ItemKillo,
                        billList[row_index].ItemGram, billList[row_index].ItemLength, billList[row_index].ItemWidth, billList[row_index].ItemHeight,
                        billList[row_index].ItemVolum, billList[row_index].DescriptionOfGoods, billList[row_index].ConsigneeContactPerson,
                        billList[row_index].ConsigneePhone, billList[row_index].ConsigneeCompanyNameAndAddress, billList[row_index].ConsigneeReceivedDateTime,
                        billList[row_index].ReceiverName, billList[row_index].ServiceType, billList[row_index].AmountReceived,
                        billList[row_index].PaymentMethod, billList[row_index].SpecialInstructions, billList[row_index].ShipperTIN, billList[row_index].ConsigneeTIN);
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
                    printView.shipper_tin = billList[row_index].ShipperTIN.ToString();
                    printView.consignee_tin = billList[row_index].ConsigneeTIN.ToString();
                    this.rootWindow.change_to_print_view(printView);
                }
                catch { }
            }
        }

    }
}
