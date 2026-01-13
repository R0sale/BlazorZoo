using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components
{
    public partial class AccountBodyDetails
    {
        [Parameter]
        public UserDto? User { get; set; }
    }
}
