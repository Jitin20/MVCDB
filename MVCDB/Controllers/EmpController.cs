using Microsoft.AspNetCore.Mvc;
using MVCDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MVCDB.ViewModel;

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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empdata = db.Emps.Find(id);
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(empdata);
        }
        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            if(ModelState.IsValid)
            {
                var odata = db.Emps.Find(emp.Id);
                odata.Name = emp.Name;
                odata.Salary = emp.Salary;
                odata.Email = emp.Email;
                odata.Deptid = emp.Deptid;
                odata.Dob = emp.Dob;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);

        }
        //Duplicacy of Email Checked
        public JsonResult EmailCheck(string Email)
        {
            //to check whether present or not.
            bool yesno = db.Emps.Any(e => e.Email == Email);
            return Json(!yesno);
        }

        public IActionResult ShowBonus()
        {
            List<Emp> emps = db.Emps.Include("Dept").ToList();
            List<EmpDept> empDepts = new List<EmpDept>();
           
            foreach(var data in emps)
            {
                EmpDept ed = new EmpDept();
                ed.Id = data.Id;
                ed.Name = data.Name;
                ed.DeptName = data.Dept.Name;
                ed.Location = data.Dept.Location;
                ed.Salary = data.Salary;
                if (data.Salary > 70000) ed.Bonus = 7000;
                else if (data.Salary > 40000) ed.Bonus = 4000;
                else ed.Bonus = 2000;
                empDepts.Add(ed);
            }
            return View(empDepts);

        }

        public IActionResult Display(int id)
        {
            var empdata = db.Emps.Include("Dept").Where(e=>e.Id==id).FirstOrDefault();

            return View(empdata);
        }
        
    }
}
