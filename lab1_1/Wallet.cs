using System;
using System.Collections.Generic;
using System.Text;

namespace lab1_1
{
    public class Wallet
    {
        private static int InstanceCount;
        private int _id;
        private string _name;
        private double _initialBalance;
        private string _description;
        private string _currency;
        private int _userId;
        private List<Category> _categories;
        private bool _isShared;



        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public double InitialBalance
        {
            get
            {
                return _initialBalance;
            }
            set
            {
                _initialBalance = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
            }
        }
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public bool IsShared
        {
            get => _isShared;
            set => _isShared = value;
        }
        public List<Category> Categories
        {
            get => _categories;
            set => _categories = value;
        }

        public Wallet()
        {
            Categories = new List<Category>();
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Wallet(int id, string name, double initialBalance, string description, string currency, int userId)
        {
            _id = id;
            _name = name;
            _initialBalance = initialBalance;
            _description = description;
            _currency = currency;
            _userId = userId;
        }

        public bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Description))
                result = false;
            if (String.IsNullOrWhiteSpace(Currency))
                result = false;
            if (UserId == null)
                result = false;

            return result;
        }
        public double countBalance()
        {
            foreach (Transaction transaction in )
         }

    }
}
