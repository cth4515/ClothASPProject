using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team103.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Team103.Controllers
{
    public class AccountController : Controller
    {
        private readonly Team103DBContext _context;
        public AccountController(Team103DBContext context)
        {
            _context = context;
        }
  
        public IActionResult Login(string returnURL)
        {
            returnURL = String.IsNullOrEmpty(returnURL) ? "~/" : returnURL;
            return View(new LoginInput { ReturnURL = returnURL });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,UserPassword,ReturnURL")] LoginInput loginInput)
        {
            if (ModelState.IsValid)
            {
                var aUser = await _context.TblUser.FirstOrDefaultAsync(u => u.UserName == loginInput.UserName && u.UserPassword == loginInput.UserPassword);
                if (aUser != null)
                {
                    var fullName = aUser.FirstName + " " + aUser.LastName;
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, fullName));
                   // claims.Add(new Claim(ClaimTypes.GivenName, aUser.FirstName));
                    claims.Add(new Claim(ClaimTypes.Sid, aUser.UserPk.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, aUser.Email));
                    claims.Add(new Claim(ClaimTypes.MobilePhone, aUser.Phone));
                    claims.Add(new Claim(ClaimTypes.Role, aUser.Role));
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return Redirect(loginInput?.ReturnURL ?? "~/");
                }
                else
                    ViewData["message"] = "Invalid credentials";
            }
            ViewData["UserName"] = loginInput.UserName;
            ViewData["UserPassword"] = loginInput.UserPassword;
            return View(loginInput);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp ([Bind("UserName,UserPassword,FirstName,LastName,Email,Phone")] TblUser loginInfo)
        {
            var aUser = await _context.TblUser.FirstOrDefaultAsync(u => u.UserName == loginInfo.UserName);
            if(aUser is null)
            {
                loginInfo.Role = "regular";
                _context.Add(loginInfo);
                await _context.SaveChangesAsync();
                TempData["success"] = "Account created";
                return RedirectToAction(nameof(Login));
            }
            else
            {
                ViewData["message"] = "Choose a different username";
            }
            return View(loginInfo);
        }
        public async Task<RedirectToActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}