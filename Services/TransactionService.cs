using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using lab1_1;

namespace Services
{
    public class TransactionService
    {
        private FileDataStorage<Transaction> _storage = new FileDataStorage<Transaction>();



        public async Task<bool> AddOrUpdateTransactionAsync(Transaction transaction)
        {
            Thread.Sleep(1000);
            await Task.Run(() => _storage.AddOrUpdateAsync(transaction));
            return true;
        }


        public void DeleteTransaction(Transaction transaction)
        {
            Thread.Sleep(1000);
            _storage.Delete(transaction);
        }


        public List<Transaction> GetTransactions()
        {
            Task<List<Transaction>> transactions = Task.Run<List<Transaction>>(async () => await _storage.GetAllAsync());
            return transactions.Result;
        }

    }
}
