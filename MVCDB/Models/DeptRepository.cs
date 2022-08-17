﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCDB.Models
{
    public class DeptRepository : IDept
    {
        //make object of context 
        db1045Context db = new db1045Context();
        public void AddDept(Dept dept)
        {
            db.Depts.Add(dept);
            db.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDept(Dept dept)
        {
            throw new NotImplementedException();
        }

        public Dept FindDept(int id)
        {
            var data = from dept in db.Depts where dept.Id == id select dept;
            return data.FirstOrDefault();

            //var data = db.Depts.Find(id);
            //return data;
        }

        public List<Dept> GetDepts()
        {
            var data = from dept in db.Depts select dept;

            //foreach(var dept in data)
            //{
            //    Console.WriteLine($"{dept.Name}---{dept.Id}---{dept.Location}");
            //}
            //var data1 = db.Emps.ToList();
            return data.ToList();
        }
    }
}
