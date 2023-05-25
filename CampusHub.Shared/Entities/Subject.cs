using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CampusHub.Shared.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        [Display(Name = "Materia")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        //Con este ID en edición nos permite regresar al 
        public int UniversityProgramId { get; set; }

        public UniversityProgram? UniversityProgram { get; set; }

        

    }
}
