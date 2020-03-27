namespace LVALaptop.Data
{
    using System;

    public class EmployeePortable : IEntity
    {
        public int Id { get; set; }

        public DateTime AssingmentDate { get; set; }

        public DateTime TerminationDate { get; set; }

        public Portable Portable { get; set; }

        public Employee Employee { get; set; }
    }
}
