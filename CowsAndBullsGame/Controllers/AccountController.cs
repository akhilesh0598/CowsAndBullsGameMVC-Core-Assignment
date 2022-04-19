using CowsAndBullsGame.Models;
using CowsAndBullsGame.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(UserSignUp userSignUp)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(userSignUp);
                ModelState.Clear();
                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                return View(userSignUp);
            }
            return View();
        }
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }
        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignIn userSignIn)
        {
            if(ModelState.IsValid)
            {
                var result =await _userRepository.PasswordSignInAsync(userSignIn);
                if(result.Succeeded)
                {
                    return RedirectToAction("Play", "GamePlay");
                }
                ModelState.AddModelError("", "Invalid Crential");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _userRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
