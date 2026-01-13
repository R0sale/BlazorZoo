using Entities.Contrats;
using Entities.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersDbContext _context;
        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.AsNoTracking().Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(User newUser)
        {
            newUser.Id = Guid.NewGuid().ToString();

            _context.Add(newUser);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
