using EMS.DAL.Models;
using EMS.Web.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.Web.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user is null)
                    {
                        user = await _userManager.FindByEmailAsync(model.Email);
                        if (user is null)
                        {
                            user = new ApplicationUser
                            {
                                UserName = model.UserName,
                                FistName = model.FirstName,
                                LastName = model.LastName,
                                Email = model.Email,
                                IsAgree = model.IsAgree
                            };
                            var result = await _userManager.CreateAsync(user, model.Password);
                            if (result.Succeeded)
                            {
                                return RedirectToAction(nameof(SignIn));
                            }
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
                        ModelState.AddModelError("", "User already exists with this Email ");

                    }
                    ModelState.AddModelError("", "User already exists with this username ");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }



            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var Flag = _userManager.CheckPasswordAsync(user,model.Password);
                        if(Flag != null)
                        {
                            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                            if (result.Succeeded)
                            {
                                return RedirectToAction("Index", "Home");
                            }

                        }
                    }
                    ModelState.AddModelError("", "User is invalid");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(model);
        }

        [HttpGet]
        public  new async Task<IActionResult> SignOut()
        {
           await   _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }
}
