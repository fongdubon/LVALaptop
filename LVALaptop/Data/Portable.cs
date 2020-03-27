namespace LVALaptop.Data
{
    using System;
    using System.Collections.Generic;

    public class Portable : IEntity
    {
        public int Id { get; set ; }

        public string SerialNumber { get; set; }
        
        public string Model { get; set; }
        
        public DateTime PurchaseDate { get; set; }

        public ICollection<EmployeePortable> EmployeePortables { get; set; }
    }
}
