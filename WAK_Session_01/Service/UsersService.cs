using DataAccess;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class UsersService
    {
        private DemoDBContext dbContext;

        public UsersService(DemoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return
            dbContext.Users.Select(dbUser => new User
            {
                FirstName = dbUser.Firstname,
                LastName = dbUser.Lastname,
                Address = dbUser.Address,
                City = dbUser.City,
                Email = dbUser.Email,
                Postcode = dbUser.Postcode,
                AccountNumber = dbUser.AccNo,
                Phone = dbUser.Phone
            });
        }

        public bool CreateUser(User user)
        {
            bool opMarker = false;

            try
            {
                dbContext.Users.Add(new DataAccess.Models.Users
                {
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                    Address = user.Address,
                    City = user.City,
                    Email = user.Email,
                    Phone = user.Phone,
                    AccNo = user.AccountNumber,
                    Postcode = user.Postcode,
                    Transactions = null
                });

                opMarker = dbContext.SaveChanges() == 1 ? true : false;

            }
            catch (DbUpdateException)
            {
                opMarker = false;
            }

            return opMarker;
        }
    }
}
