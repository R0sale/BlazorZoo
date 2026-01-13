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
                entity.OwnsOne(u => u.Address).HasData(
                    new  
                    { 
                        UserId = "b8dd6cb1-d02c-440d-828b-3056017e4390",
                        Country = "Belarus", 
                        City = "Minsk", 
                        State = "No state", 
                        PostalCode = "222435", 
                        Street = "Kastrychnickaya" 
                    });

                entity.OwnsOne(u => u.Address).HasData(
                    new
                    {
                        UserId = "cd244cd6-239f-49c7-9532-7dbd95e4a156",
                        Country = "USA",
                        City = "Tampa",
                        State = "South Florida",
                        PostalCode = "222435",
                        Street = "Lenina"
                    });

                var hash = Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("DotNetIsTheBest123!")));

                entity.HasData(
                    new User { Id = "b8dd6cb1-d02c-440d-828b-3056017e4390", Email = "email@mail.ru", FirstName = "John", LastName = "Black", Username = "JoeBlack", PasswordHash = hash, ImageUrl="/koala.webp", PhoneNumber="+375299998493"},
                    new User { Id = "cd244cd6-239f-49c7-9532-7dbd95e4a156", Email = "myEmail@mail.ru", FirstName = "Kirill", LastName = "Bush", Username = "Baiden", PasswordHash = hash, ImageUrl = "/koala.webp", PhoneNumber = "+375299998493"});

                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

        }
    }
}
