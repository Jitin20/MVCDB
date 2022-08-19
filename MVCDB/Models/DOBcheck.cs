using System.ComponentModel.DataAnnotations;
using System;
namespace MVCDB.Models
{
    public class DOBcheck:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime birthdate = Convert.ToDateTime(value);
            int birtyear = birthdate.Year;
            int todayyear = DateTime.Now.Year;
            if (todayyear - birtyear >= 21)
                return true;
            else
                return false;
        }
    }
}
