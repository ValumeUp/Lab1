using System.Collections.Generic;
using System.Linq;
using Models.Wallets;

namespace Services
{
    public class WalletService
    {
        public static List<Wallet> Users = new List<Wallet>()
        {
            new Wallet(){Name="wal1", Balance = 57.05m},
            new Wallet(){Name="wal2", Balance = 19.17m},
            new Wallet(){Name="wal3", Balance = 156.33m},
            new Wallet(){Name="wal4", Balance = 21.17m},
            new Wallet(){Name="wal5", Balance = 90.67m}
        };
        

        public List<Wallet> GetWallets()
        {

            return Users.ToList();
        }
    }

}
