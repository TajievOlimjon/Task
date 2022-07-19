using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User: IdentityUser
    {
        public bool Identified { get; set; } = false;

    }
}
