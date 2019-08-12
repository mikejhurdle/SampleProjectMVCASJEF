using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectMVCAJSEF.IDataServices
{
    public interface IDropdownService
    {
        Task<List<DropdownTypeDTO>> GetDropDownValues();
        Task<List<DropdownDTO>> GetDropDownValuesByType(string type);
        Task<int> SaveDropDownValue(DropdownDTO dto);
        Task<int> AddDropdownType(string name);
    }
}
