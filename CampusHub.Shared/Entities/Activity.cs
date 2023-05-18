using CampusHub.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Activity
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    [Display(Name = "Descripción")]
    [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    public string Description { get; set; } = null!;


}