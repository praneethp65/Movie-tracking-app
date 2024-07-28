using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTracker.Services
{
    public interface IAuthService
    {
        Task<bool> SignIn(string email, string password);
        Task<bool> SignUp(string email, string password);
        Task SignOut();
    }

}
