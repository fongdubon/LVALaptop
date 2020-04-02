namespace LVALaptop.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EmployeePortable : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AssingmentDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TerminationDate { get; set; }

        public Portable Portable { get; set; }

        public Employee Employee { get; set; }
    }
}
