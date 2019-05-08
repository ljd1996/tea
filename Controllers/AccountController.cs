using System;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tea.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using tea.DataAccess.Interface;

namespace tea.Controllers
{
    public class AccountController : Controller
    {

        private IUserDao iUserDao;

        public AccountController(IUserDao iUserDao)
        {
            this.iUserDao = iUserDao;
        }

        [Authorize(Roles = "admi")]
        [HttpGet("test")]
        public string Test()
        {
            return "test test";
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string name, string password, string returnUrl)
        {
            User user = iUserDao.GetUserByName(name);
            if (user != null && user.password.Equals(password))
            {
                //用户标识
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, name));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                if (returnUrl == null)
                {
                    returnUrl = TempData["returnUrl"]?.ToString();
                }
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            else
            {
                const string badUserNameOrPasswordMessage = "用户名或密码错误！";
                return BadRequest(badUserNameOrPasswordMessage);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
