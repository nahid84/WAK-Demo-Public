using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Indication { get; set; }
        public int? Userid { get; set; }

        public virtual Users User { get; set; }
    }
}
