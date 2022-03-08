using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoredProcedureDemoCodeFirst
{
    public class SpCfEmployeeDBContext : DbContext
    {
        public DbSet<SpCfEmployee> spCfEmployees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpCfEmployee>().MapToStoredProcedures
                (p => p.Insert(i => i.HasName("InsertSpCfEmployee")
                                    .Parameter(n => n.Name, "EmployeeName")
                                    .Parameter(n => n.Gender, "EmployeeGender")
                                    .Parameter(n => n.Salary, "EmployeeSalary"))
                    .Update(u => u.HasName("UpdateSpCfEmployee")
                                    .Parameter(n => n.ID, "EmployeeID")
                                    .Parameter(n => n.Name, "EmployeeName")
                                    .Parameter(n => n.Gender, "EmployeeGender")
                                    .Parameter(n => n.Salary, "EmployeeSalary"))
                    .Delete(d => d.HasName("DeleteSpCfEmployee")
                                    .Parameter(n => n.ID, "EmployeeID"))
                    );

            base.OnModelCreating(modelBuilder);
        }
    }
}