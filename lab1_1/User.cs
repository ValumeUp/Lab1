using System;
using System.Collections.Generic;

namespace lab1_1
{
    public class User
    {
        private static int InstanceCount;
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        private List<Wallet> _wallets;
        private List<Category> _categories;
public static int InstanceCount1 { get => InstanceCount; set => InstanceCount = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public int Id { get => _id; set => _id = value; }
        public List<Wallet> Cards { get => _wallets; set => _wallets = value; }
        public List<Category> Categories { get => _categories; set => _categories = value; }

        public User()
        {
            InstanceCount += 1;
            _id = InstanceCount;
            Cards = new List<Wallet>();
            Categories = new List<Category>();
        }

        public User(int id, string name, string surname, string email, List<Wallet> cards, List<Category> categories)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _email = email;
            Cards = cards;
            Categories = categories;
        }

        public bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (String.IsNullOrWhiteSpace(Surname))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;
            return result;
        }

        public string Show()
        {
            return $"User {_id}: {_name}, {_surname}, Email: {_email}";
        }
    }
//    , Wallets: {_wallets
//}, on categories: { _categories}
}
