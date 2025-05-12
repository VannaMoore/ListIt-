using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ListItemTag
    {
        public int ListItemId { get; set; } // Foreign key to ListItem
        public required ListItem ListItem { get; set; } // Navigational property to ListItem

        public int TagId { get; set; } // Foreign key to Tag
        public required Tag Tag { get; set; } // Navigational property to Tag
    }
}

/** 
            * This is the join table for the many-to-many relationship between
                ListItem and Tag.
            * It is a composite key, meaning it has two foreign keys that together 
                form a unique identifier for each record. 
            * No two rows will have the same combo of ListItem and Tag 
        **/