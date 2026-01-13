using Entities.Contrats;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Authentication;

namespace ProjectBlaz.Components.Pages
{
    public partial class Auth
    {
        private AuthUser _authUser = new AuthUser();
        private string _errorMessage = string.Empty;
        private string InputTextCssClass => string.IsNullOrEmpty(_errorMessage) ? 
            "w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-lg text-sm " +
            "focus:outline-none focus:border-orange-400 focus:ring-2 focus:ring-orange-100 " +
            "transition-all" : 
            "w-full px-3 py-2 bg-gray-50 border-2 border-red-600 rounded-lg text-sm " +
            "focus:outline-none focus:border-orange-400 focus:ring-2 focus:ring-orange-100 " +
            "transition-all";

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IUsersAuthenticationService? UserService { get; set; }

        public async Task LoginAsync()
        {
            var valid = await UserService.AuthenticateUserAsync(_authUser.Email, _authUser.Password);

            if (!valid)
                _errorMessage = "Invalid email or password.";
            else
                NavigationManager?.NavigateTo($"/account/{_authUser.Email}");
        }

        public void GoToSignUpPage()
        {
            NavigationManager.NavigateTo("/account/signup");
        }
    }
}
