namespace LVALaptop.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";
        //Hola Yael

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public ICollection<EmployeePortable> EmployeePortables { get; set; }
    }
}
