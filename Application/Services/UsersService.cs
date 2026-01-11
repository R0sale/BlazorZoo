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
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;
        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsersAsync();
            IEnumerable<UserDto> usersDto = users.Select(user => new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();

            
            return usersDto;
        }   

        public async Task CreateUserAsync(CreateUserDto newUser)
        {
            var passwordHash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newUser.Password)).ToString();

            var user = new User
            {
                Username = newUser.Username,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                PasswordHash = passwordHash
            };

            await _repository.CreateUserAsync(user);
        }
    }
}
