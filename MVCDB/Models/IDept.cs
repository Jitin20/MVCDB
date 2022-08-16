using System.Collections.Generic;

namespace MVCDB.Models
{
    public interface IDept
    {
        
        List<Dept> GetDepts();
        Dept FindDept(int id);
        void AddDept(Dept dept);
        void EditDept(Dept dept);
        void DeleteDept(int id);        

    }
}
