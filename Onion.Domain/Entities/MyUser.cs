using Microsoft.AspNetCore.Identity;

namespace Onion.Domain.Entities;

public class MyUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}