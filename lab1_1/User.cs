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
        private List<Card> _cards;
        private List<Category> _categories;
public static int InstanceCount1 { get => InstanceCount; set => InstanceCount = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public int Id { get => _id; set => _id = value; }

        public User()
        {
            InstanceCount += 1;
            _id = InstanceCount;
            _cards = new List<Card>();
            _categories = new List<Category>();
        }

        public User(int id, string name, string surname, string email, List<Card> cards, List<Category> categories)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _email = email;
            _cards = cards;
            _categories = categories;
        }
    }
}
