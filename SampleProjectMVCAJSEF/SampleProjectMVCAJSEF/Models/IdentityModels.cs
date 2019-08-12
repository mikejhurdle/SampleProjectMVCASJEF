using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SampleProjectMVCAJSEF.DataAccess;

namespace SampleProjectMVCAJSEF.Models
{
    [Table("Users")]
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public int? ClientId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    [Table("Roles")]
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) { Name = name; }
        public string Description { get; set; }

    }
    [Table("UserRoles")]
    public class ApplicationUserRole : IdentityUserRole
    {

    }
    [Table("UserClaims")]
    public class ApplicationUserClaim : IdentityUserClaim { }
    [Table("UserLogins")]
    public class ApplicationUserLogin : IdentityUserLogin { }
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, string,
       ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUserPasswordStore<ApplicationUser, string>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }

    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, string, ApplicationUserRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}