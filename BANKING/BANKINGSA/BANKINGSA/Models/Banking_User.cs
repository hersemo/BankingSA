using System;
using System.Collections.Generic;
using System.Text;

namespace BANKINGSA.Models
{
    class Banking_User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Banking_BankAccount> Banking_BankAccount;
        public List<Banking_PayService> Banking_PayService;
        public List<Banking_Transfer> Banking_Transfer;
    }
}
