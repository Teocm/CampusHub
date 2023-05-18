using CampusHub.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace CampusHub.Shared.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        public Property Property { get; set; } = null!;

        public int PropertyId { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;
    }
}
