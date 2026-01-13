using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace ProjectBlaz.Components
{
    public partial class AccountBody
    {
        [Parameter]
        public UserDto User { get; set; }
    }
}
