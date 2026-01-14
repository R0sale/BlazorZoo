using Application.Validation;
using Entities.Contrats;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components.Pages
{
    public partial class SignUpPage
    {
        private CreateUserDto _createUserDto = new CreateUserDto();
        private string? _message = string.Empty;

        [Inject]
        public IUsersAuthenticationService AuthService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task CreateUserAsync()
        {
            var validator = new CreateUserValidator();

            var validationResult = validator.Validate(_createUserDto);

            if (!validationResult.IsValid)
            {
                _message = string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage));
                return;
            }

            var result = await AuthService.SignUpAsync(_createUserDto);

            if (result)
            {
                NavigationManager.NavigateTo($"/account/{_createUserDto.Email}");
            }
            else
            {
                _message = "Couldn't sign up. Please try again.";
            }
        }
    }
}
