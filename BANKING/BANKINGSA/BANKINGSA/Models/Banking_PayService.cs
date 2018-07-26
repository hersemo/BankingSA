using System;
using System.Collections.Generic;
using System.Text;

namespace BANKINGSA.Models
{
    class Banking_PayService
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool Paid { get; set; }
        public string PaidDate { get; set; }
        public Banking_BankAccount BankAccount { get; set; }
        public Banking_Service Service { get; set; }
        public Banking_User User { get; set; }
    }
}