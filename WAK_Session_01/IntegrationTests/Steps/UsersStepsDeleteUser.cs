using AngularDemoCore2._2;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace IntegrationTests.Steps
{
    [Binding]
    public class UsersStepsDeleteUser
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        private HttpResponseMessage response;

        public UsersStepsDeleteUser(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Given(@"Api is up and running to delete user")]
        public void GivenApiIsUpAndRunning()
        {
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:52180")
            });
        }
        
        [When(@"User deletion requested by accountNumber (.*)")]
        public void WhenUserDeletionRequestedByAccountNumberNLABNA(string accountNumber)
        {
            response = client.DeleteAsync($"/api/users/{accountNumber}").Result;
        }
        
        [Then(@"User gets deleted")]
        public void ThenUserGetsDeleted()
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
