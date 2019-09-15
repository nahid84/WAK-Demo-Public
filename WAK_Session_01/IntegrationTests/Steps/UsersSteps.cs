using AngularDemoCore2._2;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace IntegrationTests.Steps
{
    [Binding]
    public class UsersSteps : WebApplicationFactory<Startup>
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        private HttpResponseMessage response; 

        public UsersSteps(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Given(@"Api is up and running for user test")]
        public void GivenApiIsUpAndRunning()
        {
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:52180")
            });
        }
        
        [When(@"All users requested")]
        public void WhenAllUsersRequested()
        {
            response = client.GetAsync("/api/users").Result;
        }
        
        [Then(@"Below Users are listed")]
        public void ThenBelowUsersAreListed(Table table)
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            dynamic users = response.Content.ReadAsAsync<dynamic>().Result;

            List<string> expectedUsers = new List<string>();
            expectedUsers.AddRange(table.Rows.Select(x=> x.Values.First()));

            foreach(var user in users)
            {
                expectedUsers.Exists(x=> x == user.name.Value);
            }
        }
    }
}
