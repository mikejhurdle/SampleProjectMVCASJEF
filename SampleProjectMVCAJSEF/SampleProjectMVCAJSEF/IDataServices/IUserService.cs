using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectMVCAJSEF.IDataServices
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> SaveUser(UserDTO dto);
        Task<List<string>> GetRoles();
    }
}
