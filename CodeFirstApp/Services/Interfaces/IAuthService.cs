using CodeFirstApp.Models;
using CodeFirstApp.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApp.Services.Interface
{

    public interface IAuthService
    {
        Task<IEnumerable<User>> AuthenticateAsync(string userName, string password);

        string GetToken(User user);
    }
}