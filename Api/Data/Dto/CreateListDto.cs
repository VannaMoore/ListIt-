using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.List
{
    public class CreateListDto
    {
        // No Id or CreatedAt properties here, they are set by the database
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public int OwnerId { get; set; }

        public int? ParentListId { get; set; }
    }
}
