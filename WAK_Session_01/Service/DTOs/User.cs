using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTOs
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string FullAddress => $"{this.Address}, {this.Postcode}, {this.City}";
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
