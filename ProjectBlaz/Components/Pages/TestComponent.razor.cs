using Entities.Contrats;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Eventing.Reader;

namespace ProjectBlaz.Components.Pages
{
    public partial class TestComponent()
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        private List<UserDto> _users = new List<UserDto>();

        protected override async Task OnInitializedAsync()
        {
            
            _users = (await UsersService.GetAllUsersAsync()).ToList();
        }
    }
}
