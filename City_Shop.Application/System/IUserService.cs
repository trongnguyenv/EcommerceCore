using City_Shop.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace City_Shop.Application.System
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
