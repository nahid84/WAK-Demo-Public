using DataAccess;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Service;
using Service.DTOs;
using Service.UnitTests.Extensions;
using Service.UnitTests.TestData;

namespace UsersServiceTest
{
    public class Tests
    {
        private DemoDBContext dbContext;
        private UsersService usersService;

        [SetUp]
        public void InitTest()
        {
            var options = new DbContextOptionsBuilder<DemoDBContext>()
                .UseInMemoryDatabase(databaseName: "WAK_Demo_DB")
                .Options;

            dbContext = new DemoDBContext(options);
            dbContext.ResetValueGenerators();
            dbContext.Database.EnsureDeleted();

            usersService = new UsersService(dbContext);
        }

        [TearDown]
        public void CloseTest()
        {
            dbContext.Dispose();
            dbContext = null;
        }

        [Test]
        [Order(1)]
        public void GetAllUsers_Returns_Users()
        {
            dbContext.AddRange(UsersData.Entries);
            dbContext.SaveChanges();

            var users = usersService.GetAllUsers();

            users.Should().HaveCount(3);
        }

        [Test]
        [Order(2)]
        public void CreateUser_Can_Add_User()
        {
            usersService.CreateUser(new User
            {
                FirstName = "Wahid",
                LastName = "Hasan",
                AccountNumber = "NL09123999",
                Address = "Zonnbloemstraat 10",
                City = "Nieuwegein",
                Email = "nahid.hasan@capgemini.com",
                Phone = "06161170999",
                Postcode = "3434VB"
            });

            dbContext.Users.Should().HaveCount(1);
        }
    }
}