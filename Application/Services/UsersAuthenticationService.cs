using Entities.Contrats;
using ExceptionHandler.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsersAuthenticationService : IUsersAuthenticationService
    {
        private readonly IUsersRepository _usersRepo;

        public UsersAuthenticationService(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var user = await _usersRepo.GetUserByEmailAsync(email);

            if (user is null)
                return false;

            Console.WriteLine(user.PasswordHash);
            Console.WriteLine(Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))));

            if (user.PasswordHash.Equals(Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
