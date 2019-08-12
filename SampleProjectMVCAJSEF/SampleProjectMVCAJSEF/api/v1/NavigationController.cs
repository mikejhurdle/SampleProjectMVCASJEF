using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleProjectMVCAJSEF.api.v1
{
    [RoutePrefix("api/v1/navigation")]
    public class NavigationController : ApiController
    {
        [Route("GetNavTiles")]
        public IHttpActionResult GetNavTiles()
        {

            List<MainNavDTO> tiles = new List<MainNavDTO>()
                {
                    new MainNavDTO(){ Title="Account",Link="/Manage",Background="yellow",Icon="/Icons/account.svg" },
                    new MainNavDTO(){ Title="Record Your Catch",Link="/Portal",Background="yellow",Icon="/Icons/browser.svg" }
                };
            if (User.IsInRole("Administrator"))
            {
                tiles.Add(new MainNavDTO
                {
                    Title = "Admin",
                    Link = "/Admin",
                    Background = "red",
                    Icon = "/Icons/businessman.svg"

                });
            }
            return Ok(tiles);
        }
        [Route("GetAdminTiles")]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult GetAdminTiles()
        {

            List<MainNavDTO> tiles = new List<MainNavDTO>()
                {
                    new MainNavDTO(){ Title="Users",Link="/Admin/ManageUsers",Background="teal",Icon="/Icons/team.svg" },
                    new MainNavDTO(){ Title="Dropdowns",Link="/Admin/ManageDropdowns",Background="green",Icon="/Icons/browser.svg"},
                };

            return Ok(tiles);

        }
    }
}
