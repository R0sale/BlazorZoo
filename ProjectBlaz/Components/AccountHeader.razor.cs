using Entities.Contrats;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;
using System.Text;

namespace ProjectBlaz.Components
{
    public partial class AccountHeader
    {
        [Parameter]
        public UserDto User { get; set; }

        [Parameter]
        public bool IsVisible { get; set; }
        [Parameter]
        public EventCallback<bool> IsVisibleChanged { get; set; }

        [Inject]
        public IUsersService UserService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task DeleteAccount()
        {
            IsVisible = true;

            await IsVisibleChanged.InvokeAsync(true);
        }

        public async Task CreateUserAsync()
        {
            var user = new User { Email = "email@mail.ru", FirstName = "John", LastName = "Black", Username = "JoeBlack", PasswordHash = Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("DotNetIsTheBest123!"))), ImageUrl = "/koala.webp", PhoneNumber = "+375299998493", Address = new Address()
            {
                Country = "Belarus",
                City = "Minsk",
                State = "No state",
                PostalCode = "222435",
                Street = "Kastrychnickaya"
            }
            };

            await UserService.CreateUserAsync(new CreateUserDto
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = "DotNetIsTheBest123!",
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address
            });
        }

        public async Task GoToEditPage()
        {
            NavigationManager.NavigateTo($"/account/edit/{User.Email}");
        }
    }
}
