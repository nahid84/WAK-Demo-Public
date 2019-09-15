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
    public class TransactionsFeatureSteps
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        private HttpResponseMessage response;

        public TransactionsFeatureSteps(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Given(@"Api is up and running for transaction test")]
        public void GivenApiIsUpAndRunning()
        {
            client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:52180")
            });
        }

        [When(@"Transaction requested by accountnumber (.*)")]
        public void WhenTransactionRequestedByAccountnumberNLABNA(string accountNumber)
        {
            response = client.GetAsync($"/api/transactions/{accountNumber}").Result;
        }

        [Then(@"Below transactions are listed")]
        public void ThenBelowTransactionsAreListed(Table table)
        {
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            dynamic transactions = response.Content.ReadAsAsync<dynamic>().Result;

            List<dynamic> expectedTransactions = new List<dynamic>();
            expectedTransactions.AddRange(table.Rows.Select(x => {
                return new { operation = x.Values.ElementAt(0), amount = x.Values.ElementAt(1) };
            }));

            foreach (var transaction in transactions)
            {
                expectedTransactions.Exists(x => x.operation == transaction.operation.Value &&
                                                 x.amount == transaction.amount.Value);

            }
        }
    }
}
