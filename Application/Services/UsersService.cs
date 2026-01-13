using Entities.Contrats;
using Entities.Dtos;
using Entities.Models;
using ExceptionHandler.Exceptions;
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
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            }).ToList();

            
            return usersDto;
        }
        
        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _repository.GetUserByEmailAsync(email);

            if (user is null)
                return null;

            return new UserDto
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName= user.LastName,
                ImageUrl = user.ImageUrl,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            };
        }

        public async Task<bool> CreateUserAsync(CreateUserDto newUser)
        {
            if (newUser is null)
                return false;

            var passwordHash = Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newUser.Password)));

            var user = new User
            {
                Username = newUser.Username,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                PasswordHash = passwordHash,
                ImageUrl = newUser.ImageUrl,
                PhoneNumber = newUser.PhoneNumber,
                Address = newUser.Address
            };

            await _repository.CreateUserAsync(user);

            return true;
        }

        public async Task DeleteUserByEmailAsync(string email)
        {
            await _repository.DeleteUserByEmailAsync(email);
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var existingUser = await _repository.GetUserByEmailAsync(user.Email);

            if (existingUser is null)
                return false;

            existingUser.Username = user.Username;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.ImageUrl = user.ImageUrl;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;
            await _repository.UpdateUserAsync(existingUser);

            return true;
        }
    }
}
