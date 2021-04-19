using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataStorage;

namespace lab1_1
{
    public class Wallet : EntityBase, IStorable
    {
        private static int InstanceCount;
        private Guid _guid;
        private string _name;
        private decimal _initialBalance;
        private string _description;
        private Currency? _currency;
        private decimal _balance;
        private ObservableCollection<Transaction> _categories;
        private ObservableCollection<Transaction> _transactions;
        private List<Guid> _coOwnersGuid;
        private Guid _ownerGuid;

        public Guid OwnerGuid
        {
            get => _ownerGuid;
            set => _ownerGuid = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }

        public decimal InitialBalance
        {
            get => _initialBalance;
            set => _initialBalance = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public Currency? Currency
        {
            get => _currency;
            set => _currency = value;
        }



        public ObservableCollection<Transaction> Categories
        {
            get => _categories;
            set => _categories = value;
        }

        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set => _transactions = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public List<Guid> CoOwnersGuid
        {
            get => _coOwnersGuid;
        }

        public Wallet(Guid ownerGuid, string name, decimal startingBalance, string description, Currency? mainCurrency,
            ObservableCollection<Transaction> transactions,
            ObservableCollection<Category> categories, List<Guid> coOwnersGuid)
        {
            _guid = Guid.NewGuid();
            _ownerGuid = ownerGuid;
            _name = name;
            _initialBalance = startingBalance;
            _description = description;
            _currency = mainCurrency;
            _balance = startingBalance;
            _transactions = transactions;
            _categories = categories;
            _coOwnersGuid = coOwnersGuid;
        }

        public void addTransaction(User user, Transaction transaction)
        {
            if (OwnerGuid == user.Guid || CoOwnersGuid.Exists(x => x == user.Guid))
            {
                if (transaction.Category.UserGuid == OwnerGuid)
                {
                    Balance += transaction.MoneyAmount *
                               Converter.СomputeTheCoefficient(transaction.Currency, Currency);
                    var newTransaction = new Transaction(Guid, transaction.MoneyAmount, transaction.Currency,
                        transaction.Category,
                        transaction.Description, transaction.Date, transaction.Guid);
                    var temp = Transactions;
                    temp.Add(newTransaction);
                    Transactions = temp;
                }
            }
        }

        public void deleteTransaction(User user, Transaction transaction)
            {
                if (OwnerGuid == user.Guid)
                {
                    foreach (Transaction listTransaction in Transactions)
                    {
                        if (listTransaction.Guid == uneditedTransaction.Guid)
                        {
                            Balance -= uneditedTransaction.MoneyAmount *
                                       Converter.СomputeTheCoefficient(uneditedTransaction.Currency, MainCurrency);
                            var temp = Transactions;
                            temp.Remove(listTransaction);
                            Transactions = temp;
                            return;
                        }
                    }
                }
            }

            

        
            public decimal LastMonthIncome()
            {
                return LastMonth(true);
            }

            public decimal LastMonthExpense()
            {
                return LastMonth(false);
            }

            private decimal LastMonth(bool positive)
            {
                decimal result = 0.0m;
                DateTime currentDate = DateTime.Now;

                foreach (Transaction listTransaction in Transactions)
                {
                    if (DateTime.Compare(listTransaction.Date.Value.AddMonths(1), currentDate) > 0)
                    {
                        if ((listTransaction.MoneyAmount > 0 && positive) ||
                            (listTransaction.MoneyAmount < 0 && !positive))
                        {
                            result += listTransaction.MoneyAmount *
                                      Converter.СomputeTheCoefficient(listTransaction.Currency, Currency);
                        }
                    }
                }

                return result;
            }


            public ObservableCollection<Transaction> ShowTenTransactions(int number)
            {
                _transactions = new ObservableCollection<Transaction>(_transactions.OrderBy((x => x.Date)).ToList());


                ObservableCollection<Transaction> result = new ObservableCollection<Transaction>();
                int transactionsShown = 10;

                if (number + transactionsShown > Transactions.Count)
                {
                    number = Transactions.Count - transactionsShown;
                }

                if (transactionsShown > Transactions.Count)
                {
                    number = 0;
                    transactionsShown = Transactions.Count;
                }

                for (int i = number; i < number + transactionsShown; i++)
                {
                    result.Add(Transactions[i]);
                }

                return result;
            }

        public override bool Validate()
        {
            var result = true;

            if (OwnerGuid == Guid.Empty)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (InitialBalance < 0)
                result = false;
            if (Currency == null)
            {
                result = false;
            }

            return result;
        }
    }
}



    