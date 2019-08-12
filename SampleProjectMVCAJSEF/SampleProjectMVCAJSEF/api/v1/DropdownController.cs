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
    [RoutePrefix("api/v1/dropdown")]
    public class DropdownController : ApiController
    {
        private IDropdownService _serv;
        public DropdownController(IDropdownService serv)
        {
            _serv = serv;
        }
        [Route("GetValues")]
        public async Task<IHttpActionResult> GetValues()
        {
            try
            {
                var list = await _serv.GetDropDownValues();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route("GetValuesByType")]
        public async Task<IHttpActionResult> GetValuesByType(string type)
        {
            try
            {
                var list = await _serv.GetDropDownValuesByType(type);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route("SaveDropdownItem")]
        public async Task<IHttpActionResult> SaveDropdownValue(DropdownDTO dto)
        {
            try
            {
                return Ok(await _serv.SaveDropDownValue(dto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
