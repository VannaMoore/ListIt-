using System.ComponentModel.DataAnnotations;

namespace Api.Data.List
{
    public class UpdateListDto
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string? Type { get; set; }
        public int? ParentListId { get; set; }

        // No Id or CreatedAt properties here, they are set by the database
       
    }
}
