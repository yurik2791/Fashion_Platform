using System.Security.Policy;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FashionPlatform.Domain.UserAndRole.Infrastructure
{
   public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name)
            : base(name)
        { }
    }
}
