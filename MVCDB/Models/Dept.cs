using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
#nullable disable

namespace MVCDB.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }
        [Required(ErrorMessage ="Please Enter ID")]
        [Display(Name = "Department Code")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        [Display(Name="Department Name")]
        public string Name { get; set; }

        [StringLength(25,ErrorMessage = "Location Incorrect",MinimumLength =3)]

        [Display(Name = "Location")]
        public string Location { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
