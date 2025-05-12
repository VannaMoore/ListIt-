using System;

namespace Api.Data.List
{
    public class ListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int OwnerId { get; set; }
        public int? ParentListId { get; set; }
    }
}