using CowsAndBullsGame.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserSignUp userSignUp)
        {
            var user = new ApplicationUser()
            {
                Email = userSignUp.Email,
                UserName = userSignUp.Email
            };
            var result = await _userManager.CreateAsync(user, userSignUp.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync(UserSignIn userSignIn)
        {
            var result = await _signInManager.PasswordSignInAsync(userSignIn.Email, userSignIn.Password,
                userSignIn.RememberMe,false);
            return result;
        }
        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }
    }
}
