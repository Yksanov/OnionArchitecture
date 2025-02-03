using Microsoft.AspNetCore.Identity;

namespace Onion.Domain.Entities;

public class UserIdentity : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}