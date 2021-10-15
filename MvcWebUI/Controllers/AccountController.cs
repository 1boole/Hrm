using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Entities;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        UserManager<CustomIdentityUser> _userManager;
        RoleManager<CustomIdentityRole> _roleManager;
        SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.NickName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    DegreeId = 1,

                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Staff").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Staff"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "we can't add the role");
                            return View(registerViewModel);
                        }
                    }
                    _userManager.AddToRoleAsync(user, "Staff").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (_roleManager.Roles.FirstOrDefault().Equals("Admin"))
                {
                    RedirectToAction("Index", "Admin");
                }
                else
                {
                    RedirectToAction("Index", "Staff");
                }
            }
            return View();
        }

        private string CheckAndGetValue(string d)
        {
            try
            {
                return d;
            }
            catch (NullReferenceException)
            {
                return "";
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var result = _signInManager.PasswordSignInAsync(loginViewModel.Email,
               loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    var user = _userManager.FindByNameAsync(loginViewModel.Email);
                    var role = _userManager.GetRolesAsync(user.Result);
                    if(role.Result.FirstOrDefault()=="Admin")
                    {
                        TempData.Add("message", String.Format("Yönetici girişi başarılı."));
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        TempData.Add("message", String.Format("Personel girişi başarılı."));
                        return RedirectToAction("Index", "Staff");
                    }

                }
                TempData.Add("message", String.Format("Geçersiz Giriş"));
                ModelState.AddModelError("", "Geçersiz giriş");


            }
            return View(loginViewModel);
        }


        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }



   
}
