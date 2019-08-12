using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models.DTO
{
    public class DropdownTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DropdownDTO> Values { get; set; }
    }
}