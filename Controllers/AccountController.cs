using aspmvc.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace aspmvc.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
                UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signinManager
            )
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [Route("Login")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string? returnUrl=null)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            var result = await _signinManager.PasswordSignInAsync(
                login.Email, login.PasswordHash,
                login.RememberMe, false
            );

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View(login);
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToPage("/Index");

            return Redirect(returnUrl);
        }

        
        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signinManager.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToPage("/Index");

            return Redirect(returnUrl);
        }


        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            Console.Out.WriteLine("enter register");
            
            if (!ModelState.IsValid)
                return View(registration);

            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            var result = await _userManager.CreateAsync(newUser, registration.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}
