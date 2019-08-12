using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

    }
    public class BaseEntityWithAudit : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedByUser { get; set; }
    }
}