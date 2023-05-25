using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CampusHub.Shared.Entities
{
    public class Faculty
    {

        public int Id { get; set; }

        [Display(Name = "Facultad")]  //{0}
        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null;

        public ICollection<UniversityProgram>? UniversityPrograms { get; set; }

        //Contamos  programas por facultad

        [Display(Name = "Facultades")]
        public int UniversityProgramsNumber => UniversityPrograms == null ? 0 : UniversityPrograms.Count;





    }
}
