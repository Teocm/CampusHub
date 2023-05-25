using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CampusHub.Shared.Entities
{
    public class UniversityProgram
    {

        public int Id { get; set; }

        [Display(Name = "Programa universitario")]  //{0}
        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null;

        public ICollection<Subject>? Subjects { get; set; }

        //Con este ID en edición nos permite regresar
        public int FacultyId { get; set; }

        public Faculty? Faculty { get; set; }


        //Contamos  materias por Programa

        [Display(Name = "Asignaturas")]
        public int SubjectsNumber => Subjects == null ? 0 : Subjects.Count;





    }
}