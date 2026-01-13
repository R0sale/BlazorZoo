using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Contrats
{
    public interface IUsersAuthenticationService
    {
        Task<bool> AuthenticateUserAsync(string email, string password);
    }
}
