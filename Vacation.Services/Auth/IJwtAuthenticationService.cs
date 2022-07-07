using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Data.Models;

namespace Vacation.Services.Auth
{
    public interface IJwtAuthenticationService
    {
        BaseCommandResponse Authenticate(string username, string password);
        Task<bool> Register(string username, string password);
        User GetUserById(int id);
        Task<IReadOnlyList<User>> GetAllUsersAsync();
    }
}
