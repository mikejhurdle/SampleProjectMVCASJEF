using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models.Entities
{
    public class DropdownValue
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int DropdownTypeId { get; set; }
        [ForeignKey("DropdownTypeId")]
        public DropdownType DropdownType { get; set; }
        public bool Active { get; set; }

    }
}