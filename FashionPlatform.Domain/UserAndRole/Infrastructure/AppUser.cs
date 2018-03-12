using Microsoft.AspNet.Identity.EntityFramework;


namespace FashionPlatform.Domain.UserAndRole.Infrastructure
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
        public int City { get; set; }

        // Здесь будут указываться дополнительные свойства
    }

}
