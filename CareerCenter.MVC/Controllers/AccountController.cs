using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using CareerCenter.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

//test commit

namespace CareerCenter.MVC.Controllers
{

    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly CareerCenterDbContext _context;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, CareerCenterDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model, string ConfirmPassword)
        {
            if (model.Password == ConfirmPassword)
            {
                User staff = new User { Email = model.Email, UserName = model.UserName };
                var user = await _userManager.FindByEmailAsync(staff.Email);
                if (user != null)
                {
                    ModelState.AddModelError("Email", "Пользователь с таким Email существует");
                    return View(model);
                }
                var result = await _userManager.CreateAsync(staff, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    var errorMessages = result.Errors.ToList();
                    foreach (var item in errorMessages)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            item.Description = "Такое имя пользователья уже существует";
                            ModelState.AddModelError("UserName", item.Description);
                        }
                        if(item.Code== "InvalidUserName")
                        {
                            item.Description = "Логин должень быть только с латинскими буквами и цифрами";
                            ModelState.AddModelError("UserName", item.Description);
                        }
                        if (item.Code == "PasswordRequiresLower")
                        {
                            item.Description = "Пароль должен содержать символ в нижнем регистре";
                            ModelState.AddModelError("Password", item.Description);
                        }
                        if (item.Code == "PasswordRequiresUpper")
                        {
                            item.Description = "Пароль должен содеражть символ в верхнем регистре";
                            ModelState.AddModelError("Password", item.Description);
                        }
                    }
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            LogInViewModel model = new LogInViewModel() { ReturnUrl = HttpContext.Request.Query["ReturnUrl"] };
            return View(model);
        }

        public IActionResult EmailError(string userId)
        {
            //return View(model: userId);
            return null;
        }



        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest("NotFound");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return RedirectToAction("LogIn");
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model, bool RememberMe)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                bool result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim("UserName",user.UserName),
                        new Claim("UserId", Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Email, user.Email),
                    };

                    await _signInManager.SignInWithClaimsAsync(user, isPersistent: RememberMe, userClaims);
                    if (model.ReturnUrl != null)
                    {
                        //await Authenticate(user);
                        await _signInManager.SignInAsync(user, RememberMe);
                        return LocalRedirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Неправильный пароль");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Неправильный логин");
                model.Email = "";
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return null;
        }

    }

}
