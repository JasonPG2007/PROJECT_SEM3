using Microsoft.AspNetCore.Identity;
using Microsoft.PowerBI.Api.Models;
using ObjectBussiness;
using System.Security.Claims;

namespace WebAPI.System.User
{
    public class UserService : IUserSevice
    {
        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _sign;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _user = userManager;
            _sign = signInManager;
        }

        public async Task<bool> Authencate(ExamRegister request)
        {
            var user = await _user.FindByNameAsync(request.Email);
            if (user == null)
            {
                return false;
            }

            var claims = new List<Claim>
{
            new Claim("Username", user.Email),

              new Claim("UserPassword", request.Password),
};


            var examRegister =;
            if (examRegister != null)
            {
                claims.Add(new Claim("ExamRegisterEmail", examRegister.Email));
                // Add more ExamRegister-related claims as needed
            }


            claims.Add(new Claim("UserPassword", request.Password));

            return true;
        }

        public Task<bool> Register(ExamRegister request)
        {
            throw new NotImplementedException();
        }
    }
}
