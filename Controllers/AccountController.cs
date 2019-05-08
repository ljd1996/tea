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
using tea.Util;
using System.IO;

namespace tea.Controllers
{
    public class AccountController : Controller
    {

        private IUserDao iUserDao;
        private IProductDao iProductDao;

        public AccountController(IUserDao iUserDao, IProductDao iProductDao)
        {
            this.iUserDao = iUserDao;
            this.iProductDao = iProductDao;
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
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Anonymous, password));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.role));
                identity.AddClaim(new Claim(ClaimTypes.HomePhone, user.phone));
                identity.AddClaim(new Claim(ClaimTypes.StreetAddress, user.address));

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

        [HttpGet("register_page")]
        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            user.role = Constant.ROLE_USER;
            iUserDao.CreateUser(user);
            // ViewData["msg"] = "注册成功，请登录！";
            return RedirectToAction("Login", "Account");
        }

        [HttpGet("myself")]
        public IActionResult Myself()
        {
            return View();
        }

        [HttpPost("updateUser")]
        public IActionResult UpdateUser(User user)
        {
            iUserDao.UpdateUser(user);
            return RedirectToAction("Logout", "Account");
        }

        [HttpGet("release_page")]
        public IActionResult ReleasePage()
        {
            return View();
        }

        [HttpPost("release")]
        public async Task<IActionResult> Release(Product product, Microsoft.AspNetCore.Http.IFormFile file)
        {
            TimeSpan cha = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            long t = (long)cha.TotalSeconds;

            string fileName = Directory.GetCurrentDirectory() + "/file/img/" + t + file.FileName;
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            product.image = fileName;
            product.status = Constant.PRO_STATUS_ON;
            iProductDao.CreateProduct(product);
            return RedirectToAction("Index", "Home");
        }
    }
}
