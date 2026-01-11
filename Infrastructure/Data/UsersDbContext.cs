using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasData(
                    new User { Id = Guid.NewGuid().ToString(), Email = "email@mail.ru", FirstName = "John", LastName = "Black", Username = "JoeBlack", PasswordHash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("DotNetIsTheBest123!")).ToString() },
                    new User { Id = Guid.NewGuid().ToString(), Email = "myEmail@mail.ru", FirstName = "Kirill", LastName = "Bush", Username = "Baiden", PasswordHash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("DotNetIsTheBest123!")).ToString() });

                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

        }
    }
}
