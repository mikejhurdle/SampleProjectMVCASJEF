using SampleProjectMVCAJSEF.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.DataServices
{
    public class BaseService
    {
        public IDbContext _db;
        public BaseService(IDbContext context)
        {
            _db = context;
        }

    }
}