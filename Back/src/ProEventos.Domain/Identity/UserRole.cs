using Microsoft.AspNetCore.Identity;

namespace ProEventos.Domain.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User user { get; set; }
        public Role role { get; set; }
    }
}