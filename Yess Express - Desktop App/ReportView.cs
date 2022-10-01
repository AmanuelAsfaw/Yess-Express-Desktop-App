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
    public partial class ReportView : Form
    {
        string daily_cash_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', '0 day') AND payment_method = 'Cash';";
        string daily_cash_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Cash';";

        string daily_credit_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', '0 day') AND payment_method = 'Credit';";
        string daily_credit_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Credit';";

        string daily_check_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', '0 day') AND payment_method = 'Check';";
        string daily_check_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Check';";

        string weekly_cash_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', 'weekday 0', '-7 days') AND payment_method = 'Cash';";
        string weekly_cash_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE DATE(B.created_at) >= DATE('now', 'weekday 0', '-7 days') AND B.payment_method = 'Cash';";

        string weekly_credit_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', 'weekday 0', '-7 days') AND payment_method = 'Credit';";
        string weekly_credit_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE DATE(B.created_at) >= DATE('now', 'weekday 0', '-7 days') AND B.payment_method = 'Credit';";

        string weekly_check_bills_query = "SELECT count(*) FROM Bills WHERE DATE(created_at) >= DATE('now', 'weekday 0', '-7 days') AND payment_method = 'Check';";
        string weekly_check_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE DATE(B.created_at) >= DATE('now', 'weekday 0', '-7 days') AND B.payment_method = 'Check';";

        string monthly_cash_bills_query = "SELECT count(*) FROM Bills WHERE strftime('%m', created_at) = '10' AND payment_method = 'Cash' AND payment_method = 'Cash';";
        string monthly_cash_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Cash';";

        string monthly_credit_bills_query = "SELECT count(*) FROM Bills WHERE strftime('%m', created_at) = '10' AND payment_method = 'Credit';";
        string monthly_credit_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Credit';";

        string monthly_check_bills_query = "SELECT count(*) FROM Bills WHERE strftime('%m', created_at) = '10' AND payment_method = 'Check';";
        string monthly_check_senders_query = "SELECT count(*) FROM Senders as S INNER JOIN Bills as B ON S.Id = B.sender_id WHERE strftime('%m', B.created_at) = '10' AND B.payment_method = 'Check';";

        public ReportView()
        {
            InitializeComponent();
        }

        private void pictureBoxRefreshBTN_Click(object sender, EventArgs e)
        {
            LoadDailyQuery();
            LoadWeeklyQuery();
            LoadMonthlyQuery();
        }

        public void LoadDailyQuery()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = daily_cash_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_bill = (Int64)cmd.ExecuteScalar();
                        labelDailyCashBills.Text = cash_bill.ToString();

                        cmd.CommandText = daily_cash_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_sender = (Int64)cmd.ExecuteScalar();
                        labelDailyCashSender.Text = cash_sender.ToString();

                        cmd.CommandText = daily_credit_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_bill = (Int64)cmd.ExecuteScalar();
                        labelDailyCreditBills.Text = credit_bill.ToString();

                        cmd.CommandText = daily_credit_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_sender = (Int64)cmd.ExecuteScalar();
                        labelDailyCreditSender.Text = credit_sender.ToString();

                        cmd.CommandText = daily_check_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_bill = (Int64)cmd.ExecuteScalar();
                        labelDailyCheckBill.Text = check_bill.ToString();

                        cmd.CommandText = daily_check_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_sender = (Int64)cmd.ExecuteScalar();
                        labelDailyCheckSender.Text = check_sender.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LoadWeeklyQuery()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = weekly_cash_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_bill = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCashBill.Text = cash_bill.ToString();

                        cmd.CommandText = weekly_cash_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_sender = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCashSender.Text = cash_sender.ToString();

                        cmd.CommandText = weekly_credit_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_bill = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCreditBill.Text = credit_bill.ToString();

                        cmd.CommandText = weekly_credit_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_sender = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCreditSender.Text = credit_sender.ToString();

                        cmd.CommandText = weekly_check_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_bill = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCheckBill.Text = check_bill.ToString();

                        cmd.CommandText = weekly_check_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_sender = (Int64)cmd.ExecuteScalar();
                        labelWeeklyCheckSender.Text = check_sender.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LoadMonthlyQuery()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=NewDatabase.db;"))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = monthly_cash_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_bill = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCashBill.Text = cash_bill.ToString();

                        cmd.CommandText = monthly_cash_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 cash_sender = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCashSender.Text = cash_sender.ToString();

                        cmd.CommandText = monthly_credit_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_bill = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCreditBill.Text = credit_bill.ToString();

                        cmd.CommandText = monthly_credit_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 credit_sender = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCreditSender.Text = credit_sender.ToString();

                        cmd.CommandText = monthly_check_bills_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_bill = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCheckBill.Text = check_bill.ToString();

                        cmd.CommandText = monthly_check_senders_query;
                        cmd.CommandType = CommandType.Text;
                        Int64 check_sender = (Int64)cmd.ExecuteScalar();
                        labelMonthlyCheckSender.Text = check_sender.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            LoadDailyQuery();
            LoadWeeklyQuery();
            LoadMonthlyQuery();
        }
    }
}
