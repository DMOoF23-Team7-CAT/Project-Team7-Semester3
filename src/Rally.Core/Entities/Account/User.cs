using Microsoft.AspNetCore.Identity;

namespace Rally.Core.Entities.Account
{
    public class User : IdentityUser
    {
        public ICollection<Track> Tracks { get; set; } = [];
    }
}
