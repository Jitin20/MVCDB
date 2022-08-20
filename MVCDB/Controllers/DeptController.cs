using Microsoft.AspNetCore.Mvc;
using MVCDB.Models;
using System;
namespace MVCDB.Controllers
{
    public class DeptController : Controller
    {
        //Dept Repository Injection 
        //When we said transient in startup, it means it is injected

        IDept repos;
        public DeptController(IDept _repost)
        {
            repos = _repost;
        }

        public IActionResult List()
        {

            var data = repos.GetDepts();
            return View(data);
        }

        public IActionResult Display(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    repos.AddDept(dept);
                    return RedirectToAction("List");
                }
                return View(dept);
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View("Error");
            }
                
            }
         
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                repos.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Deleted(int id)
        {
            var data = repos.FindDept(id);
                return View(data);
        }

        [HttpPost]
        public IActionResult Deleted(Dept dept)
        {
            repos.DeleteDept(dept.Id);
            return RedirectToAction("List");
        }
    }
}