
namespace Yess_Express___Desktop_App
{
    partial class SearchView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewSearchResult = new System.Windows.Forms.DataGridView();
            this.use = new System.Windows.Forms.DataGridViewButtonColumn();
            this.print_btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tracking_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_company_name_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yes_exppress_receiver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_killo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_gram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_volum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptions_of_goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consignee_contact_person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consignee_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consignee_company_name_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiver_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.special_instructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(207, 136);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(519, 27);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(791, 136);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 27);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewSearchResult
            // 
            this.dataGridViewSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.use,
            this.print_btn,
            this.tracking_no,
            this.sender_name,
            this.sender_phone,
            this.sender_company_name_address,
            this.yes_exppress_receiver,
            this.item_killo,
            this.item_gram,
            this.item_length,
            this.item_width,
            this.item_height,
            this.item_volum,
            this.descriptions_of_goods,
            this.consignee_contact_person,
            this.consignee_phone,
            this.consignee_company_name_address,
            this.receiver_name,
            this.service_type,
            this.amount_received,
            this.payment_method,
            this.special_instructions});
            this.dataGridViewSearchResult.Location = new System.Drawing.Point(12, 180);
            this.dataGridViewSearchResult.Name = "dataGridViewSearchResult";
            this.dataGridViewSearchResult.RowTemplate.Height = 25;
            this.dataGridViewSearchResult.Size = new System.Drawing.Size(1465, 527);
            this.dataGridViewSearchResult.TabIndex = 2;
            this.dataGridViewSearchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchResult_CellClick);
            // 
            // use
            // 
            this.use.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.use.HeaderText = "Use";
            this.use.Name = "use";
            this.use.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.use.Width = 32;
            // 
            // print_btn
            // 
            this.print_btn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.print_btn.HeaderText = "Print";
            this.print_btn.Name = "print_btn";
            this.print_btn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.print_btn.Text = "Print";
            this.print_btn.Width = 38;
            // 
            // tracking_no
            // 
            this.tracking_no.HeaderText = "TrackingNo";
            this.tracking_no.Name = "tracking_no";
            // 
            // sender_name
            // 
            this.sender_name.HeaderText = "SenderName";
            this.sender_name.Name = "sender_name";
            // 
            // sender_phone
            // 
            this.sender_phone.HeaderText = "SenderPhone";
            this.sender_phone.Name = "sender_phone";
            // 
            // sender_company_name_address
            // 
            this.sender_company_name_address.HeaderText = "SenderCompany";
            this.sender_company_name_address.Name = "sender_company_name_address";
            // 
            // yes_exppress_receiver
            // 
            this.yes_exppress_receiver.HeaderText = "YesExppressReceiver";
            this.yes_exppress_receiver.Name = "yes_exppress_receiver";
            // 
            // item_killo
            // 
            this.item_killo.HeaderText = "Killo";
            this.item_killo.Name = "item_killo";
            // 
            // item_gram
            // 
            this.item_gram.HeaderText = "Gram";
            this.item_gram.Name = "item_gram";
            // 
            // item_length
            // 
            this.item_length.HeaderText = "Length";
            this.item_length.Name = "item_length";
            // 
            // item_width
            // 
            this.item_width.HeaderText = "Width";
            this.item_width.Name = "item_width";
            // 
            // item_height
            // 
            this.item_height.HeaderText = "Height";
            this.item_height.Name = "item_height";
            // 
            // item_volum
            // 
            this.item_volum.HeaderText = "Volum";
            this.item_volum.Name = "item_volum";
            // 
            // descriptions_of_goods
            // 
            this.descriptions_of_goods.HeaderText = "Goods Desc";
            this.descriptions_of_goods.Name = "descriptions_of_goods";
            // 
            // consignee_contact_person
            // 
            this.consignee_contact_person.HeaderText = "Contact Person";
            this.consignee_contact_person.Name = "consignee_contact_person";
            // 
            // consignee_phone
            // 
            this.consignee_phone.HeaderText = "Phone";
            this.consignee_phone.Name = "consignee_phone";
            // 
            // consignee_company_name_address
            // 
            this.consignee_company_name_address.HeaderText = "Company";
            this.consignee_company_name_address.Name = "consignee_company_name_address";
            // 
            // receiver_name
            // 
            this.receiver_name.HeaderText = "Receiver";
            this.receiver_name.Name = "receiver_name";
            // 
            // service_type
            // 
            this.service_type.HeaderText = "Service Type";
            this.service_type.Name = "service_type";
            // 
            // amount_received
            // 
            this.amount_received.HeaderText = "Amount Received";
            this.amount_received.Name = "amount_received";
            // 
            // payment_method
            // 
            this.payment_method.HeaderText = "Payment Method";
            this.payment_method.Name = "payment_method";
            // 
            // special_instructions
            // 
            this.special_instructions.HeaderText = "Special Instructions";
            this.special_instructions.Name = "special_instructions";
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 756);
            this.Controls.Add(this.dataGridViewSearchResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "SearchView";
            this.Text = "SearchView";
            this.Load += new System.EventHandler(this.SearchView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewSearchResult;
        private System.Windows.Forms.DataGridViewButtonColumn use;
        private System.Windows.Forms.DataGridViewButtonColumn print_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tracking_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_company_name_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn yes_exppress_receiver;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_killo;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_gram;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_width;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_height;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_volum;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptions_of_goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn consignee_contact_person;
        private System.Windows.Forms.DataGridViewTextBoxColumn consignee_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn consignee_company_name_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiver_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn service_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_received;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn special_instructions;
    }
}