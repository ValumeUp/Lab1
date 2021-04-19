using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using lab1_1;


namespace Services
{
    public class WalletService
    {
        private FileDataStorage<Wallet> _storage = new FileDataStorage<Wallet>();



        public async Task<bool> AddOrUpdateWalletAsync(Wallet wallet)
        {
            Thread.Sleep(1000);
            await Task.Run(() => _storage.AddOrUpdateAsync(wallet));
            return true;
        }


        public void DeleteWallet(Wallet wallet)
        {
            Thread.Sleep(1000);
            _storage.Delete(wallet);
        }

        public Wallet GetWallet(Wallet wallet)
        {
            Task<Wallet> walresult = Task.Run<Wallet>(async () => await _storage.GetAsync(wallet.Guid));
            return walresult.Result;
        }


        public List<Wallet> GetWallets()
        {
            Task<List<Wallet>> wallets = Task.Run<List<Wallet>>(async () => await _storage.GetAllAsync());
            return wallets.Result;
        }

    }

}
