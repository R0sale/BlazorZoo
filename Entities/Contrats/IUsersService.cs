using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Contrats
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<bool> CreateUserAsync(CreateUserDto newUser);
        Task DeleteUserByEmailAsync(string email);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(UserDto user);
    }
}
