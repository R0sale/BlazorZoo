using Application.Validation;
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
            var validator = new EditUserValidator();

            var validationResult = validator.Validate(_userDto);

            if (!validationResult.IsValid)
            {
                _message = string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage));
                return;
            }

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
