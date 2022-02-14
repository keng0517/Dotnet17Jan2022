using System.ComponentModel.DataAnnotations;

namespace Day19Project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Range(0, 100, ErrorMessage = "Only has 100 stocks left.")]
        public int Quantity { get; set; }

        [Range(0, 99999, ErrorMessage = "Invalid Input Price")]
        public double Price { get; set; }

        [Display(Name = "Picture")]
        public string Pic { get; set; }
    }
}
