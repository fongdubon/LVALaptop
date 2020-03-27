namespace LVALaptop.Data
{
    using System.Collections.Generic;
    //Holis probando para hacer la sincronizada
    //otra prueba...
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public ICollection<EmployeePortable> EmployeePortables { get; set; }
    }
}
