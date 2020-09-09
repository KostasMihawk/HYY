using HYY.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HYY.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HYY.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HYY.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(x => x.Email == "drallis@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "drallis@unipi.gr", UserName = "drallis", Name = "Dimitrios", Surname = "Rallis", Hospital = "Main Hospital", Department = "Pathologix" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }

            if (!context.Users.Any(x => x.Email == "jcampell@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "jcampell@unipi.gr", UserName = "jcampell", Name = "Joseph", Surname = "Campell", Hospital = "Main Hospital", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }

            if (!context.Users.Any(x => x.Email == "kmichopoulos@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "kmichopoulos@unipi.gr", UserName = "kmichopoulos", Name = "Konstantinos", Surname = "Michopoulos", Hospital = "Main Hospital", Department = "IT" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
