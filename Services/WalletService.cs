using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using Models.Wallets;

namespace Services
{
    public class WalletService
    {
    //    public static List<Wallet> Wallets = new List<Wallet>()

    //        {
    //            new Wallet(new Guid(), "wal1", 57.05m) ,
    //            new Wallet(new Guid(), "wal2", 57.05m),
    //            new Wallet(new Guid(), "wal3", 57.05m),
    //            new Wallet(new Guid(), "wal4", 57.05m) ,
    //            new Wallet(new Guid(), "wal5", 57.05m) 
    //};

    public FileDataStorage<Wallet> _storage = new();
        
        

        public async Task<bool> AddOrUpdateWalletAsync(Wallet newW)
        {
            Thread.Sleep(1000);

            await Task.Run(() => _storage.AddOrUpdate(newW));
            return true;
        }
        public void DeleteWallet(Wallet newW)
        {
            Thread.Sleep(1000);
            _storage.Delete(newW);
        }
        public Wallet GetWallet(Wallet newW)
        {
            Task<Wallet> result = Task.Run < Wallet > (async () => await _storage.GetAsync(newW.Guid));
            return result.Result;
        }
        public List<Wallet> GetWallets()
        {
            Task<List<Wallet>> result = Task.Run<List<Wallet>>(async () => await _storage.GetAllAsync());
            return result.Result;
        }
    }

}
