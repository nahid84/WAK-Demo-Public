using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularDemoCore2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<ShowUser> AllUsers()
        {
            return
            usersService.GetAllUsers().Select(userDto => new ShowUser
            {
                Name = userDto.FullName,
                Address = userDto.FullAddress,
                AccountNumber = userDto.AccountNumber,
                Email = userDto.Email,
                Phone = userDto.Phone
            });
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUser user)
        {
            bool result = usersService.CreateUser(new Service.DTOs.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Postcode = user.Postcode,
                City = user.City,
                Phone = user.Phone,
                Email = user.Email,
                AccountNumber = user.AccountNumber
            });

            if (result)
                return Created("api/user", user);

            return BadRequest();
        }
    }

    public class ShowUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class CreateUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}