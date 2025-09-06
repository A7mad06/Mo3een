using Domain.Entities.Identity;
using Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAuthentication
    {
        public Task<UserResultDTO> RegisterAsync(RegisterDTO register);
        public Task<UserResultDTO> Login(LoginDTO login);
        public Task<string> CreateToken(User user);
    }
}
