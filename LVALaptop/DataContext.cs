using LVALaptop.Data;
using System.Data.Entity;

namespace LVALaptop
{
    public class DataContext: DbContext
    {
        public DbSet <Employee> Employees { get; set;}
        public DbSet<Portable> Portables { get; set; }

        public DbSet <EmployeePortable> EmployeePortables { get; set;}

    }
}
