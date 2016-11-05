using Core_Lab5_Db_More.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core_Lab5_Db_More
{
    public class Product: IdAble
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Vat { get; set; }

        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
