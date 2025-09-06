using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Services.Abstractions;
using Shared.User;

namespace Services
{
    public class Authentication(UserManager<User> UserManager, IMapper mapper, IConfiguration Configuration) : IAuthentication
    {
        public Task<string> CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResultDTO> Login(LoginDTO login)
        {
            var User = UserManager.Users.FirstOrDefault(u=>    u.Email==login.EmailOrPhone || u.PhoneNumber==login.EmailOrPhone);
            // search on email or phone 
            if (User == null) {
                throw new Exception(string.Format("Email or Phone is Invalid"));
            }

            var password = await UserManager.CheckPasswordAsync(User, login.Password);
            if (!password) throw new Exception("Password is incorrect");

            return new UserResultDTO(User.UserName!, User.Email!, await CreateToken(User));
        }

        public async Task<UserResultDTO> RegisterAsync(RegisterDTO register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                throw new Exception("Passwords don't match");
            }
            var User = new User()
            {
                Email = register.Email,
                About = register.About,
                Case_Category = Enum.Parse<CaseCategory>(register.CaseCategory),
                EmailConfirmed = false,
                PhoneNumber = register.PhoneNumber,
                TermsAndConditions = register.TermsAndConditions,
                UserName = register.UserName
            };

            if (await UserManager.FindByEmailAsync(User.Email)!= null) throw new Exception("Email already registered");
            var result=await UserManager.CreateAsync(User,register.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(p => p.Description).ToList();
                throw new RegisterValidationExceptions(errors);
            }
            //Send Email Confirmation
            return new UserResultDTO(User.UserName, User.Email,await CreateToken(User));
        }
    }
}
