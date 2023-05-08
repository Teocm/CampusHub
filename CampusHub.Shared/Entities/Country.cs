using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusHub.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name= "Pais")]
        [MaxLength(30, ErrorMessage ="El pais {0} debe ser maximo {1} caracteres ")]
        [Required(ErrorMessage ="El pais {0} es obligatorio")]


        public string Name { get; set; } = null;
    }
}
