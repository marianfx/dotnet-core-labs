using System;
using System.ComponentModel.DataAnnotations;

namespace Core_Lab5_Db_More
{
    public abstract class IdAble
    {
        [Required]
        public Guid Id { get; set; }
    }
}
