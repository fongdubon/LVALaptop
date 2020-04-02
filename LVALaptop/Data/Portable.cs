namespace LVALaptop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Portable : IEntity
    {
        [Key]
        public int Id { get; set ; }

        [Required]
        [StringLength(20)]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        public ICollection<EmployeePortable> EmployeePortables { get; set; }
    }
}
