using System;
using System.Collections.Generic;
using System.Text;

namespace Yess_Express___Desktop_App
{
    public class BillModel
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCompanyNameAndAddress { get; set; }
        public string ShipperSignedDate { get; set; }
        public string YesExpressReceiver { get; set; }
        public string YesExpressReceivedDateTime { get; set; }
        public Double ItemKillo { get; set; }
        public Double ItemGram { get; set; }
        public Double ItemLength { get; set; }
        public Double ItemWidth { get; set; }
        public Double ItemHeight { get; set; }
        public Double ItemVolum { get; set; }
        public string DescriptionOfGoods { get; set; }
        public string ConsigneeContactPerson { get; set; }
        public string ConsigneePhone { get; set; }
        public string ConsigneeCompanyNameAndAddress { get; set; }
        public string ConsigneeReceivedDateTime { get; set; }
        public string ReceiverName { get; set; }
        public string ServiceType { get; set; }
        public int AmountReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string SpecialInstructions { get; set; }
        public BillModel(int id, string tracking_no, int sender_id, string sender_name, string sender_phone, string sender_company_name_address, 
            string shipper_signed_date, string yes_express_receiver, string yes_express_received_date, Double killo, Double gram,
            Double length, Double width, Double height, Double volum, string descrpt_goods, string consign_contact_person,
            string consign_phone, string consign_compny_name_address, string consign_received_date, string receiver_name,
            string service_type, int amount_received, string payment_method, string special_instructions)
        {
            this.Id = id;
            this.TrackingNo = tracking_no;
            this.SenderId = sender_id;
            this.SenderName = sender_name;
            this.SenderPhone = sender_phone;
            this.SenderCompanyNameAndAddress = sender_company_name_address;
            this.ShipperSignedDate = shipper_signed_date;
            this.YesExpressReceiver = yes_express_receiver;
            this.YesExpressReceivedDateTime = yes_express_received_date;
            this.ItemKillo = killo;
            this.ItemGram = gram;
            this.ItemLength = length;
            this.ItemWidth = width;
            this.ItemHeight = height;
            this.ItemVolum = volum;
            this.DescriptionOfGoods = descrpt_goods;
            this.ConsigneeContactPerson = consign_contact_person;
            this.ConsigneePhone = consign_phone;
            this.ConsigneeCompanyNameAndAddress = consign_compny_name_address;
            this.ConsigneeReceivedDateTime = consign_received_date;
            this.ReceiverName = receiver_name;
            this.ServiceType = service_type;
            this.AmountReceived = amount_received;
            this.PaymentMethod = payment_method;
            this.SpecialInstructions = special_instructions;
        }
    }
}
