using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentProjectDay16.Models
{
    public class Product
    {
        //Product
        //  Id
        //  Name
        //  Price
        //  SupplierId
        //  Quantity
        //  Remarks

        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }

    }
}
