using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorage;

namespace Models.Wallets
{
    public class Wallet : IStorable
    {
        public Wallet(Guid ownerGuid, string name, decimal balance)
        {
            Guid = new Guid();
            Name = name;
            Balance = balance;
            OwnerGuid = ownerGuid;

        }

        public Guid Guid { get; }
        public Guid OwnerGuid { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Balance}) ";
        }
    }
}
