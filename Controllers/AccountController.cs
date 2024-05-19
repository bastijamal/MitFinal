using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SondanaSon.Models;
using SondanaSon.ViewModels.Account;

namespace SondanaSon.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVm registerVm)
        {

            if (!ModelState.IsValid) return View();

            User user = new User()
            {
                UserName = registerVm.UserName,
                Name = registerVm.Name,
                Surname = registerVm.Surname,
                Email = registerVm.Email,
                //pasword olmur hashlanir deye indi yuxari chxacam cruddaki kimi _ li ctor yaradib yazacyg
            };

            var result=await _userManager.CreateAsync(user,registerVm.Password);

            if (!result.Succeeded) {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View();

            }

             await _signInManager.SignInAsync(user, false);//remember me-false

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVm loginVm)
        {

            if (!ModelState.IsValid) return View();

            User user;

            if (loginVm.UserNameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(loginVm.UserNameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginVm.UserNameOrEmail);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "usernameoremail veya pasword sehvdir!");
                return View();
            }

            var result =  await _signInManager.CheckPasswordSignInAsync(user,loginVm.Password,true);
            //burdaki true ise ban olub olmadigini yoxlayir

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Bandasiz,birazdan yeniden cehd edin!");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "usernameoremail veya pasword sehvdir!");
                return View();
            }

            //bu chcklerden kechenne sora uje sign in eletdirrik

            await _signInManager.SignInAsync(user,loginVm.RememberMe);

            return RedirectToAction("Index","Home");
        }

    }
}

