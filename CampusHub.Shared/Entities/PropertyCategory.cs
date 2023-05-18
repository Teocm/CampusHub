
using CampusHub.Shared.Entities;

namespace CampusHub.Shared.Entities
{
    public class PropertyCategory
    {
        public int Id { get; set; }

        public Property Property { get; set; } = null!;

        public int PropertyId { get; set; }

        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}