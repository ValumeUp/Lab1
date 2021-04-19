using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataStorage;
using Models.Users;

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
                var users =await Task.Run(() => _storage.GetAllAsync());
            var dbUser = users.FirstOrDefault(user =>
                    user.Login == authUser.Login && user.Password == Encrypt(authUser.Password));
                if (dbUser == null) throw new Exception("wrong login or password");
            //Todo Call Method for user login or password validation and retrieve password from storage
            User curUser = new User(dbUser.Guid, dbUser.LastName, dbUser.FirstName, dbUser.Email, dbUser.Login);
            CurrentInformation.User = curUser;
            return curUser;


        }

        public async Task<bool> RegisterUser(RegistrationUser regUser)
        {
            Thread.Sleep(2000);
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null) throw new Exception("User already exists");
            if (string.IsNullOrWhiteSpace(regUser.Login) || string.IsNullOrWhiteSpace(regUser.Password) || string.IsNullOrWhiteSpace(regUser.LastName) || string.IsNullOrWhiteSpace(regUser.Email))
                throw new ArgumentException("Login, Password or Lastname is empty");
            dbUser = new DBUser(Guid.NewGuid(), regUser.FirstName, regUser.LastName, regUser.Email,
                regUser.Login, Encrypt(regUser.Password));
           await _storage.AddOrUpdate(dbUser);
            return true;
        }

        private string Encrypt(string value) //FOR PASSWORD:
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

    }
}
