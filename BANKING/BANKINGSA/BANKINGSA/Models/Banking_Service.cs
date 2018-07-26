using System;
using System.Collections.Generic;
using System.Text;

namespace BANKINGSA.Models
{
    class Banking_Service
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public Banking_PayService PayService { get; set; }
    }
}