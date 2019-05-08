using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tea.DataAccess.Interface;
using tea.Models;

namespace tea.Controllers
{
    public class HomeController : Controller
    {
        private IProductDao iProductDao;

        public HomeController(IProductDao iProductDao)
        {
            this.iProductDao = iProductDao;
        }

        public IActionResult Index()
        {
            ViewBag.list = iProductDao.GetProducts().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
