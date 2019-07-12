using DataAccess;
using Service.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class TransactionsService
    {
        private DemoDBContext dbContext;

        internal static readonly Dictionary<char, string> OperationsMap = new Dictionary<char, string>
        {
            { 'c', "Credit" },
            { 'd', "Debit" }
        };

        public TransactionsService(DemoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Transaction> GetAllTransactions(string accountNumber)
        {
            return
            dbContext.Transactions.Where(dbTransaction => dbTransaction.User.AccNo.Equals(accountNumber))
                                  .Select(dbTransaction => new Transaction
                                  {
                                      Amount = dbTransaction.Amount,
                                      Operation = OperationsMap.GetValueOrDefault(dbTransaction.Indication.ToCharArray()[0])
                                  });
        }
    }
}
