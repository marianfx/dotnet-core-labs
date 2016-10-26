﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro
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
    }
}
