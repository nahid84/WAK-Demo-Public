using DataAccess.Models;
using System.Collections.Generic;

namespace Service.UnitTests.TestData
{
    internal class UsersData
    {
        internal static List<Users> Entries = new List<Users>
        {
            new Users
            {
                Id = 1,
                Firstname = "Nahid",
                Lastname = "Hasan",
                AccNo = "NL09123455",
                Address = "Zonnbloemstraat 10",
                City = "Nieuwegein",
                Email = "nahid.hasan@capgemini.com",
                Phone = "06161170697",
                Postcode = "3434VB"
            },
            new Users
            {
                Id = 2,
                Firstname = "Rahana",
                Lastname = "Parvin",
                AccNo = "NL09123666",
                Address = "Zonnbloemstraat 10",
                City = "Nieuwegein",
                Email = "nahid.hasan@capgemini.com",
                Phone = "06161170888",
                Postcode = "3434VB"
            },
            new Users
            {
                Id = 3,
                Firstname = "Junaid",
                Lastname = "Hasan",
                AccNo = "NL09123777",
                Address = "Zonnbloemstraat 10",
                City = "Nieuwegein",
                Email = "nahid.hasan@capgemini.com",
                Phone = "06161170777",
                Postcode = "3434VB"
            }
        };
    }
}
