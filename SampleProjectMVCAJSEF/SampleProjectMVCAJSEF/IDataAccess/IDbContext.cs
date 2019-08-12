using SampleProjectMVCAJSEF.Models;
using SampleProjectMVCAJSEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectMVCAJSEF.IDataAccess
{
    public interface IDbContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<Document> Document { get; set; }
        DbSet<DropdownType> DropdownType { get; set; }
        DbSet<DropdownValue> DropdownValue { get; set; }

        Task<int> SaveChangesAsync();

    }
}
