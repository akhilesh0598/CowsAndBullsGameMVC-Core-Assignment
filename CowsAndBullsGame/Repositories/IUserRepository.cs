using CowsAndBullsGame.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(UserSignUp userSignUp);
        Task<SignInResult> PasswordSignInAsync(UserSignIn userSignIn);
        Task SignOutAsync();
    }
}