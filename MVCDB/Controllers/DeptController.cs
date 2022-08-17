﻿using Microsoft.AspNetCore.Mvc;
using MVCDB.Models;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            if(ModelState.IsValid)
            {
                repos.AddDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        public IActionResult Edit(int id)
        {
            var data = repos.FindDept(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if(ModelState.IsValid)
            {
                repos.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
    }
}
