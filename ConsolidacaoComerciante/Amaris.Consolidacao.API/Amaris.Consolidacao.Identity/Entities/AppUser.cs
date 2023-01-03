using Microsoft.AspNetCore.Identity;

namespace Amaris.Consolidacao.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

    }
}
