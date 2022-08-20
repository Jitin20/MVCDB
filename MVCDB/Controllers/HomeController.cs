using System;
using Microsoft.AspNetCore.Mvc;

namespace MVCDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                int a = 10, b = 0;
                int c = a / b;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }

            return View();
        }
    }
}
