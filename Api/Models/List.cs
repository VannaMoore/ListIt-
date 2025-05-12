using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class List
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Type { get; set; } // Type is logically optional

        public int OwnerId { get; set; }
        public required User Owner { get; set; }

        public int? ParentListId { get; set; }
        public List? ParentList { get; set; } // ParentList is logically optional
        public ICollection<ListUser> SharedUsers { get; set; } = new List<ListUser>();
    }
}
