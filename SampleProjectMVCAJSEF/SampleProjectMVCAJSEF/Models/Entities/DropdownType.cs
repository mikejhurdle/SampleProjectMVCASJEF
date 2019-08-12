using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models.Entities
{
    public class DropdownType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<DropdownValue> Values { get; set; }
    }
}