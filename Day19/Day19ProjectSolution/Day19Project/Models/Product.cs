﻿using System.ComponentModel.DataAnnotations;

namespace Day19Project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Pic { get; set; }
    }
}
