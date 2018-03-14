using Microsoft.AspNet.Identity.EntityFramework;


namespace FashionPlatform.Domain.UserAndRole.Infrastructure
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // Здесь будут указываться дополнительные свойства
    }

}
