using Microsoft.AspNetCore.Mvc;
using MVCDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDB.Controllers
{

  
    public class EmpController : Controller
    {
       db1045Context db= new db1045Context();
        //for fetching specific columns from emp and also dept name here is what we do
        public IActionResult List()
        {
            var empdata = db.Emps.Include("Dept").ToList();
            return View(empdata);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            //We have to create privison for drop down
         
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
        
    }
}
