using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components
{
    public partial class AccountBodyCard
    {
        [Parameter]
        public UserDto? User { get; set; }
    }
}
