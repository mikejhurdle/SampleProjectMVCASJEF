using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using SampleProjectMVCAJSEF.Models;
using SampleProjectMVCAJSEF.IDataAccess;
using SampleProjectMVCAJSEF.Models.Entities;

namespace SampleProjectMVCAJSEF.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IDbContext
    {
        public ApplicationDbContext()
          : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ApplicationDbContext>(null);
            if (Debugger.IsAttached)
            {
                Database.Log = s => Debug.Write(s);
            }
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DropdownType> DropdownType { get; set; }
        public virtual DbSet<DropdownValue> DropdownValue { get; set; }

        #region Db/Entity Framework Config
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            // Solves all Cascading issues....
            dbModelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            dbModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            dbModelBuilder.Entity<ApplicationUserLogin>().HasKey<string>(l => l.UserId);
            dbModelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(dbModelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        public void UpdateEntity<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }
        public void UpdateRecord<T>(T entity, T updatedEntity) where T : BaseEntity
        {
            this.Entry(entity).CurrentValues.SetValues(updatedEntity);
        }

        #endregion
    }
}