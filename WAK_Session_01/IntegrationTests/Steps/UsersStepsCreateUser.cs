using AngularDemoCore2._2;
using AngularDemoCore2._2.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegrationTests.Steps
{
    [Binding]
    public class UsersStepsCreateUser
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        private HttpResponseMessage response;

        public UsersStepsCreateUser(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Given(@"Api is up and running to create user")]
        public void GivenApiIsUpAndRunning()
        {
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:52180")
            });
        }

        [When(@"User creation requested by information")]
        public void WhenUserCreationRequestedByInformation(Table table)
        {
            CreateUser user = new CreateUser();
            user.FirstName = table.Rows.Where(x => x.Values.First().Equals("FirstName"))
                                        .Select(x => x.Values.Last()).First();
            user.LastName = table.Rows.Where(x => x.Values.First().Equals("LastName"))
                            .Select(x => x.Values.Last()).First();
            user.Address = table.Rows.Where(x => x.Values.First().Equals("Address"))
                            .Select(x => x.Values.Last()).First();
            user.Postcode = table.Rows.Where(x => x.Values.First().Equals("Postcode"))
                            .Select(x => x.Values.Last()).First();
            user.City = table.Rows.Where(x => x.Values.First().Equals("City"))
                            .Select(x => x.Values.Last()).First();
            user.AccountNumber = table.Rows.Where(x => x.Values.First().Equals("AccountNumber"))
                            .Select(x => x.Values.Last()).First();
            user.Email = table.Rows.Where(x => x.Values.First().Equals("Email"))
                            .Select(x => x.Values.Last()).First();
            user.Phone = table.Rows.Where(x => x.Values.First().Equals("Phone"))
                            .Select(x => x.Values.Last()).First();

            response = client.PostAsync("/api/users", new ObjectContent(typeof(CreateUser),user, new JsonMediaTypeFormatter())).Result;
        }
        
        [Then(@"User gets created by information")]
        public void ThenUserGetsCreatedByInformation(Table table)
        {
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            dynamic users = response.Content.ReadAsAsync<dynamic>().Result;

            //List<string> expectedUsers = new List<string>();
            //expectedUsers.AddRange(table.Rows.Select(x => x.Values.First()));

            //foreach (var user in users)
            //{
            //    expectedUsers.Exists(x => x == user.name.Value);
            //}
        }
    }
}
