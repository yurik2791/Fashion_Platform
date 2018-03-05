using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace FashionPlatform.Domain.UserAndRole.Infrastructure
{
    public class AppRoleManager : RoleManager<AppRole>, IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store)
            : base(store)
        { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options,
            IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppRoleManager manager = new AppRoleManager(new RoleStore<AppRole>(db));
            return manager;
        }
    }
}
