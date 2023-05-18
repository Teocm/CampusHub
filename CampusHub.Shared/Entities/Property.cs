using CampusHub.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Property
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

    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [Display(Name = "Precio")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public decimal Price { get; set; }

    [DisplayFormat(DataFormatString = "{0:N2}")]
    [Display(Name = "Disponibilidad")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public float Availability { get; set; }

    public ICollection<PropertyCategory>? PropertyCategories { get; set; }

    [Display(Name = "Categorías")]
    public int PropertyCategoriesNumber => PropertyCategories == null ? 0 : PropertyCategories.Count;

    public ICollection<PropertyImage>? PropertyImages { get; set; }

    [Display(Name = "Imágenes")]
    public int PropertyImagesNumber => PropertyImages == null ? 0 : PropertyImages.Count;

    [Display(Name = "Imágen")]
    public string MainImage => PropertyImages == null ? string.Empty : PropertyImages.FirstOrDefault()!.Image;



}

