using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AngularDemoCore2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        [HttpGet("{accountNumber}")]
        public IEnumerable<Transaction> UserTransactions([FromRoute] string accountNumber)
        {
            return
            transactionsService.GetAllTransactions(accountNumber)
                               .Select(transactionDto => new Transaction
                               {
                                   Amount = transactionDto.Amount,
                                   Operation = transactionDto.Operation
                               });

        }

        public class Transaction
        {
            public int Amount { get; internal set; }
            public string Operation { get; internal set; }
        }
    }
}