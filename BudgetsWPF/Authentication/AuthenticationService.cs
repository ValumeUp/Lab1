using System;
using System.Collections.Generic;
using System.Linq;


namespace BudgetsWPF.Authentication
{
    public class AuthenticationService
    {
        private static List<DBUser> users = new List<DBUser>();
        public User Authenticate(AuthenticationUser authUser)
        {
            if (string.IsNullOrWhiteSpace(authUser.Login) || string.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or Password is empty");
            var dbUser = users.FirstOrDefault(user => user.Login == authUser.Login && user.Password == authUser.Password);
            if (dbUser == null) throw new Exception("wrong login or password");
            //Todo Call Method for user login or password validation and retrieve password from storage
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public bool RegisterUser(RegistrationUser regUser)
        {
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null) throw new Exception("User already exists");
            if (string.IsNullOrWhiteSpace(regUser.Login) || string.IsNullOrWhiteSpace(regUser.Password) || string.IsNullOrWhiteSpace(regUser.LastName))
                throw new ArgumentException("Login, Password or Lastname is empty");
            dbUser = new DBUser(regUser.LastName + "First", regUser.LastName, regUser.Login + "@gmail.com", regUser.Login, regUser.Password);
           users.Add(dbUser);
            return true;
        }
    }
}
