namespace LVALaptop.Data
{
    using System;
    public class Portable : IEntity
    {//hola
        //Hola Luis
        public int Id { get; set ; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
