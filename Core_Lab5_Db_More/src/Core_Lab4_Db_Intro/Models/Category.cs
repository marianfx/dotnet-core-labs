using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_Lab5_Db_More.Models
{
    public class Category: IdAble
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }

        [Required]
        //[DefaultValue("Extra Info")]
        public string ExtraInfo { get; set; }
        /* Dacă încercăm acum să rulăm Add-Migration + Update-Database,
         * se va genera o eroare pt. că toate intrările precedente din DB
         * nu au valori pentru acest câmp, deci când se va altera tabelul, nu va functiona.
         * O solutie ar fi să îi adăugăm o valoare default pt. acest câmp.
        */
    }
}
