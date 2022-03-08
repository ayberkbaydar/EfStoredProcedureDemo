using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoredProcedureDemoCodeFirst
{
    public class SpCfEmployeeRepository
    {
        SpCfEmployeeDBContext spCfEmployeeDBContext = new SpCfEmployeeDBContext();
        public List<SpCfEmployee> GetSpCfEmployees()
        {
            return spCfEmployeeDBContext.spCfEmployees.ToList();
        }
        public void InsertSpCfEmployee(SpCfEmployee spCfEmployee)
        {
            spCfEmployeeDBContext.spCfEmployees.Add(spCfEmployee);
            spCfEmployeeDBContext.SaveChanges();
        }
        public void UpdateSpCfEmployee(SpCfEmployee spCfEmployee)
        {
            SpCfEmployee spCfEmployeeToUpdate = spCfEmployeeDBContext.spCfEmployees.FirstOrDefault(x => x.ID == spCfEmployee.ID);
            spCfEmployeeToUpdate.Name = spCfEmployee.Name;
            spCfEmployeeToUpdate.Gender = spCfEmployee.Gender;
            spCfEmployeeToUpdate.Salary = spCfEmployee.Salary;
            spCfEmployeeDBContext.SaveChanges();
        }
        public void DeleteSpCfEmployee(SpCfEmployee spCfEmployee)
        {
            SpCfEmployee spCfEmployeeToDelete = spCfEmployeeDBContext.spCfEmployees.FirstOrDefault(x => x.ID == spCfEmployee.ID);
            spCfEmployeeDBContext.spCfEmployees.Remove(spCfEmployeeToDelete);
            spCfEmployeeDBContext.SaveChanges();
        }

    }
}