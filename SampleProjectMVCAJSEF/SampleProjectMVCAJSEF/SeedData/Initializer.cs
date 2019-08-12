using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using SampleProjectMVCAJSEF.DataAccess;
using SampleProjectMVCAJSEF.Models;
using SampleProjectMVCAJSEF.Models.Entities;

namespace SampleProjectMVCAJSEF.SeedData
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var rolestore = new ApplicationRoleStore(context);
            var rolemanager = new RoleManager<ApplicationRole>(rolestore);
            var userStore = new ApplicationUserStore(context);
            var usermanager = new ApplicationUserManager(userStore);

            var id1 = Guid.NewGuid().ToString();
            var id2 = Guid.NewGuid().ToString();
            var id3 = Guid.NewGuid().ToString();
            var id4 = Guid.NewGuid().ToString();
            usermanager.Create(new ApplicationUser()
            {
                Id = id1,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "User",
                Active = true
            }, "Developer1!");
            usermanager.Create(new ApplicationUser()
            {
                Id = id2,
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                FirstName = "Default",
                LastName = "User",
                Active = true
            }, "Developer1!");
            context.SaveChanges();
            context.Roles.Add(new ApplicationRole()
            {
                Name = "Administrator",
                Id = Guid.NewGuid().ToString(),
            });
            context.Roles.Add(new ApplicationRole()
            {
                Name = "Default User",
                Id = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
            usermanager.AddToRole(id1, "Administrator");
            usermanager.AddToRole(id2, "Default User");
        }
    }
}