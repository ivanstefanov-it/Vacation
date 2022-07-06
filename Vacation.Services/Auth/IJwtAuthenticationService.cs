using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Services.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
        Task<bool> Register(string username, string password);

    }
}
