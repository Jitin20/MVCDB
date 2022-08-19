using System;


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVCDB.Models
{
    public partial class Emp
    {
        [Display(Name = "Emp Code")]
        public int Id { get; set; }
        [Display(Name = "Emp Name")]
        [Required(ErrorMessage = "Name can not be Blank")]
        public string Name { get; set; }
        [Display(Name = "Emp Salary")]
        [Range(10000, 90000, ErrorMessage = "Salary should be in the range")]
        public int? Salary { get; set; }
        [Display(Name = "Department ID")]
        public int? Deptid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DOBcheck(ErrorMessage ="You must be atleast 21 years to work in LnT")]
        public DateTime? Dob { get; set; }
        [DataType(DataType.EmailAddress)]
        [Remote("EmailCheck", "Emp",ErrorMessage="This Email aready exists!")]
        public string Email { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
