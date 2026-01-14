using Entities.Contrats;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;

namespace ProjectBlaz.Components.Pages
{
    public partial class Account
    {
        public UserDto User { get; set; } = new UserDto();
        [Parameter]
        public string? Email { get; set; }

        public bool ShowDeletionPopUp { get; set; } = false;

        [Inject]
        public IUsersService UserService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = (await UserService.GetAllUsersAsync()).Where(u => u.Email.Equals(Email)).SingleOrDefault();
        }
    }
}
