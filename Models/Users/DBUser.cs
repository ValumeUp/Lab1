using System;
using DataStorage;

namespace Models.Users
{
    public class DBUser:IStorable
    {
        public DBUser(Guid guid, string lastName,string firstName, string email, string login, string password)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;
        }
        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; set; }
        public string Password { get; set; }
        
    }
}
