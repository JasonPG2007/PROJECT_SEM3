using Microsoft.AspNetCore.Http;
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
            var user = await _user.FindByNameAsync(request.Email); if (user == null)
            {
  
                return false;
            } 
              
            var result = await _sign.PasswordSignInAsync(user, request., request.VerifyPassword if (result.Succeeded)
            {
                return false;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email);
            new Claim(ClaimTypes.Given Name, user.FirstName);
        }
        public Task<bool> Register(ExamRegister request)
        {
         
       }

        }
     }

