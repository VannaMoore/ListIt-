using Microsoft.AspNetCore.Identity;

namespace Api.Models;

public class User : IdentityUser<int>
{
    public ICollection<List> OwnedLists { get; set; } = new List<List>();
    public ICollection<ListUser> SharedLists { get; set; } = new List<ListUser>();
}

