using AngularDemoCore2._2;
using AngularDemoCore2._2.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using TechTalk.SpecFlow;

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

            ExpandoObject postObject = new ExpandoObject();

            table.Rows.ToList().ForEach(x =>
            {
                postObject.TryAdd(x.Values.First(), x.Values.Last());
            });

            response = client.PostAsync("/api/users", new ObjectContent(typeof(ExpandoObject), postObject, new JsonMediaTypeFormatter()))
                             .Result;
        }
        
        [Then(@"User gets created by information")]
        public void ThenUserGetsCreatedByInformation(Table table)
        {
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            string accountNumberToFind = table.Rows.Where(x => x.Values.First().Equals("AccountNumber"))
                                                   .Select(x => x.Values.Last()).First();

            response = client.GetAsync($"/api/users/{accountNumberToFind}").Result;

            dynamic user = response.Content.ReadAsAsync<dynamic>()
                                            .Result;

            PropertyInfo[] propsInfo = user.GetType().GetProperties();

            table.Rows.ToList().ForEach(x =>
            {
                PropertyInfo propInfo = propsInfo.Where(prop => prop.Name.Equals(x.Values.First()))
                                                 .FirstOrDefault();
                if (propInfo != null)
                {
                    string value = propInfo.GetValue(user) as string;
                    Assert.AreEqual(x.Values.Last(), value);
                }
            });
        }
    }
}
