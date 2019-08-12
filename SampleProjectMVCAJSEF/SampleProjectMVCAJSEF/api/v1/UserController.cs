using SampleProjectMVCAJSEF.IDataServices;
using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleProjectMVCAJSEF.api.v1
{
    [RoutePrefix("api/v1/user")]
    [Authorize]
    public class UserController : ApiController
    {
        private IUserService _serv;
        public UserController(IUserService serv)
        {
            _serv = serv;
        }
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _serv.GetAllUsers());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveUser(UserDTO dto)
        {
            try
            {
                return Ok(await _serv.SaveUser(dto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [Route("GetRoles")]
        public async Task<IHttpActionResult> GetRoles()
        {
            try
            {
                return Ok(await _serv.GetRoles());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
