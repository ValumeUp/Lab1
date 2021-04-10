using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using Models.Users;
using Models.Wallets;

namespace Services
{
    public class AuthenticationService
    {
        private FileDataStorage<DBUser> _storage = new FileDataStorage<DBUser>();

        public async Task <User> Authenticate(AuthenticationUser authUser)
        {

                Thread.Sleep(2000);
                if (string.IsNullOrWhiteSpace(authUser.Login) || string.IsNullOrWhiteSpace(authUser.Password))
                    throw new ArgumentException("Login or Password is empty");
                var users =await  _storage.GetAllAsync();
                var dbUser = users.FirstOrDefault(user =>
                    user.Login == authUser.Login && user.Password == authUser.Password);
                if (dbUser == null) throw new Exception("wrong login or password");
                //Todo Call Method for user login or password validation and retrieve password from storage
                return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);

            
        }

        public async Task<bool> RegisterUser(RegistrationUser regUser)
        {
            Thread.Sleep(2000);
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null) throw new Exception("User already exists");
            if (string.IsNullOrWhiteSpace(regUser.Login) || string.IsNullOrWhiteSpace(regUser.Password) || string.IsNullOrWhiteSpace(regUser.LastName))
                throw new ArgumentException("Login, Password or Lastname is empty");
            dbUser = new DBUser(regUser.LastName + "First", regUser.LastName, regUser.Login + "@gmail.com", regUser.Login, regUser.Password);
           await _storage.AddOrUpdate(dbUser);
            return true;
        }


        
    }
}
