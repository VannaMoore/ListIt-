using System.ComponentModel.DataAnnotations; // Let's you use the [Required] attribute and other validation attributes
using ListEntity = Api.Models.List; // Using alias to avoid confusion with List<T> in C#

namespace Api.Models // Defines what "folder" or "container" this class logically belongs to.
{
	public class ListItem
	{
		public int Id { get; set; }

		[Required]
		public required string Content { get; set; }

		public bool IsCompleted { get; set; } = false; // A task starts off as not completed

		public DateTime? DueDate { get; set; } // ? means it's nullable/optional

		public int ListId { get; set; } // foreign key that points to a specqific list
										// EFcore will use this to link  ListItem to List

		public required List List { get; set; } // Navigational Property - easily navigate from a list item to its parent list
		                               // EFcore uses this to join tables behind the scenes

		public int? ParentItemId { get; set; } // optional Foreign key to another list item 
		public ListItem? ParentItem { get; set; } // Foreign key to another list item (Navigational property)

		// Many-to-many relationship
		// A ListItem can have many child/sub ListItems
		// ICollection<T> = "a group of things" in C#.
		// Initialized to an empty list by default so it’s never null.
		public ICollection<ListItem> SubItems { get; set; } = new List<ListItem>();

		// Sets up a recursive relationship. Many-to-many relationship
		// One ListItem can have multiple Tags.
		// One Tag can belong to multiple ListItems.
		public ICollection<ListItemTag> ListItemTags { get; set; } = new List<ListItemTag>();
	}
}