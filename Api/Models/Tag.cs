using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        // Navigation property to the join table
        public ICollection<ListItemTag> ListItemTags { get; set; } = new List<ListItemTag>();
    }
}


// Can easily add fields like color or description later. This is scalable.
