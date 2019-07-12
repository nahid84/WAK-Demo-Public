using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTOs
{
    public class Transaction
    {
        public int Amount { get; internal set; }
        public string Operation { get; internal set; }
    }
}
