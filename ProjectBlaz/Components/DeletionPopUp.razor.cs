using Entities.Contrats;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components
{
    public partial class DeletionPopUp
    {
        [Parameter]
        public bool IsVisible { get; set; }

        [Parameter]
        public EventCallback<bool> IsVisibleChanged { get; set; }

        [Parameter]
        public string? Email { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUsersService UserService { get; set; }

        private async Task DeleteUserAsync()
        {
            await UserService.DeleteUserByEmailAsync(Email);

            NavigationManager.NavigateTo("/");
        }

        private async Task ClosePopUp()
        {
            IsVisible = false;

            await IsVisibleChanged.InvokeAsync(false);
        }
    }
}
