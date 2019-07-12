using DataAccess;
using DataAccess.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Service;
using Service.UnitTests.TestData;
using System.Linq;

namespace UsersServiceTest
{
    public class Tests
    {
        private Mock<DbSet<Users>> mockUsersSet;
        private Mock<DemoDBContext> mockDbContext;
        private UsersService usersService;

        [OneTimeSetUp]
        public void InitTest()
        {
            mockDbContext = new Mock<DemoDBContext>();
            usersService = new UsersService(mockDbContext.Object);
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            usersService = null;
            mockDbContext = null;
        }

        [SetUp]
        public void Setup()
        {
            mockUsersSet = new Mock<DbSet<Users>>();

            mockUsersSet.As<IQueryable<Users>>().Setup(m => m.Provider)
                                                .Returns(UsersData.Entries.AsQueryable().Provider);
            mockUsersSet.As<IQueryable<Users>>().Setup(m => m.Expression)
                                                .Returns(UsersData.Entries.AsQueryable().Expression);
            mockUsersSet.As<IQueryable<Users>>().Setup(m => m.ElementType)
                                                .Returns(UsersData.Entries.AsQueryable().ElementType);
            mockUsersSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator())
                                                .Returns(UsersData.Entries.AsQueryable().GetEnumerator());

        }

        [Test]
        public void GetAllUsers_Returns_Users()
        {
            mockDbContext.SetupGet(x => x.Users)
                         .Returns(mockUsersSet.Object);

            var users = usersService.GetAllUsers();

            users.Should().HaveCount(3);
        }
    }
}