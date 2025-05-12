using System.ComponentModel.DataAnnotations;
using ListEntity = Api.Models.List; // Using alias to avoid confusion with List<T> in C#

namespace Api.Models
{
    public class ListUser
    {
        public int ListId { get; set; }
        public required ListEntity List { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }
    }

}