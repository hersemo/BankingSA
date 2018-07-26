using System;
using System.Collections.Generic;
using System.Text;

namespace BANKINGSA.Models
{
    class Banking_Transfer
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public string Description { get; set; }
        public string TransferDate { get; set; }
        public Banking_BankAccount OriginAccount { get; set; }
        public Banking_BankAccount DestinationAccount { get; set; }
        public Banking_User User { get; set; }
    }
}