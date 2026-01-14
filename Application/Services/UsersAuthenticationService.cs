using Entities.Contrats;
using Entities.Dtos;
using Entities.Models;
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

        public async Task<(bool, string)> AuthenticateUserAsync(string email, string password)
        {
            var user = await _usersRepo.GetUserByEmailAsync(email);

            if (user is null)
            {
                return (false, "User not found.");
            }
                

            if (user.PasswordHash.Equals(Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))))
            {
                return (true, "Success");
            }
            else
            {
                return (false, "Invalid email or password.");
            }
        }

        public async Task<bool> SignUpAsync(CreateUserDto newUser)
        {
            if (newUser is null)
                return false;

            if (newUser.Password is null)
                return false;

            var hash = Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newUser.Password)));

            var user = new User
            {
                Username = newUser.Username,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,  
                PhoneNumber = newUser.PhoneNumber,
                Address = newUser.Address,
                ImageUrl = "/guest.png",
                PasswordHash = hash
            };

            await _usersRepo.CreateUserAsync(user);

            return true;
        }
    }
}
