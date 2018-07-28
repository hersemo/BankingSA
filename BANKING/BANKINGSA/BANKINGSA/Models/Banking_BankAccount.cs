using System;
using System.Collections.Generic;
using System.Text;

namespace BANKINGSA.Models
{
    class Banking_BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public string CreatedDate { get; set; }
        public Banking_User user { get; set; }
        public List<Banking_PayService> bankPays;
        public List<Banking_Transfer> bankTransfersOrigins;
        public List<Banking_Transfer> bankTransferDestinations;
    }
}
