using Entities.Contrats;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components.Pages
{
    public partial class EditPage
    {
        [Parameter]
        public string? Email { get; set; }
        private UserDto _userDto;

        [Inject]
        public IUsersService UserService { get; set; }

        private string? _message = string.Empty;

        protected override async Task OnInitializedAsync()
        { 
            await base.OnInitializedAsync();

            _userDto = await UserService.GetUserByEmailAsync(Email);
        }

        public async Task EditUserAsync()
        {
            if (!await UserService.UpdateUserAsync(_userDto))
            {
                _message = "Error updating user.";
            }
            else
            {
                _message = "User updated successfully.";
            }
        }
    }
}
