using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yess_Express___Desktop_App
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Settings1.Default.DatabaseCreated) 
            {
                CreateDB();
            }
            Application.Run(new MainWindow());
        }
        public static void CreateDB() {
            try
            {
                using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=NewDatabase.db;Version=3;New=True;Compress=True;"))
                {
                    sqlite_conn.Open();
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        string SenderTable = "CREATE TABLE 'Senders' ('Id' INTEGER NOT NULL, 'Name' TEXT, 'Phone' TEXT UNIQUE, 'CompanyNamdeAddress' TEXT, 'ShipperTIN' TEXT,'created_at' timestamp DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY('Id' AUTOINCREMENT))";
                        string BillTable = "CREATE TABLE 'Bills' ( 'id' INTEGER NOT NULL UNIQUE, 'tracking_no' INTEGER NOT NULL UNIQUE, 'sender_id' INTEGER, 'shipper_signed_date'   " +
                            "TEXT, 'yes_express_receiver'  TEXT, 'yes_express_received_datetime' TEXT, 'item_killo'    REAL, 'item_gram' REAL, 'item_length'   REAL, 'item_width'    REAL, 'item_height'   REAL, 'item_volum'    REAL, 'description_of_goods'  TEXT, 'consignee_contact_person'  TEXT, 'consignee_phone'   TEXT, 'consignee_company_name_address'    TEXT, 'consignee_received_datatime'   TEXT, 'receiver_name' TEXT, 'service_type'  TEXT, 'amount_received'   INTEGER, 'payment_method'    TEXT, 'special_instructions'  TEXT, 'ConsigneeTIN' TEXT, created_at timestamp DEFAULT CURRENT_TIMESTAMP, FOREIGN KEY(sender_id) REFERENCES Senders(sender_id), PRIMARY KEY('id' AUTOINCREMENT))";
                        string EmployeeTable = "CREATE TABLE 'Employees' ('Id' INTEGER NOT NULL, 'Name' TEXT, 'created_at' timestamp DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY('Id' AUTOINCREMENT))";
                        sqlite_cmd.CommandText = SenderTable;
                        sqlite_cmd.ExecuteNonQuery();
                        sqlite_cmd.CommandText = BillTable;
                        sqlite_cmd.ExecuteNonQuery();
                        sqlite_cmd.CommandText = EmployeeTable;
                        sqlite_cmd.ExecuteNonQuery();
                    }
                }
                Settings1.Default.DatabaseCreated = true;
                Settings1.Default.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
