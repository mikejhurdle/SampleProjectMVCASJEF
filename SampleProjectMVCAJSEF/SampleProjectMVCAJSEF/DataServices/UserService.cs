using Microsoft.AspNet.Identity;
using SampleProjectMVCAJSEF.DataAccess;
using SampleProjectMVCAJSEF.IDataAccess;
using SampleProjectMVCAJSEF.IDataServices;
using SampleProjectMVCAJSEF.Models;
using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleProjectMVCAJSEF.DataServices
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IDbContext db) : base(db)
        {

        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var IdentityContext = new ApplicationDbContext();
                var lst = await IdentityContext.Users.Select(s =>
                    new UserDTO()
                    {
                        Id = s.Id,
                        Email = s.Email,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Active = s.Active,
                        Role = s.Roles.Select(s2 => s2.RoleId).FirstOrDefault(),
                        Phone = s.Phone,
                        ClientId = s.ClientId
                    }).ToListAsync();
                foreach (var user in lst)
                {
                    user.Role = IdentityContext.Roles.Where(w => w.Id == user.Role).Select(s => s.Name).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<string>> GetRoles()
        {
            try
            {
                var IdentityContext = new ApplicationDbContext();
                return await IdentityContext.Roles.Select(s => s.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> SaveUser(UserDTO dto)
        {
            try
            {
                var IdentityContext = new ApplicationDbContext();
                ApplicationUser savedUser = null;
                if (!string.IsNullOrEmpty(dto.Id))
                {
                    savedUser = await IdentityContext.Users.Where(w => w.Id == dto.Id).FirstOrDefaultAsync();
                    if (savedUser != null)
                    {
                        savedUser.FirstName = dto.FirstName;
                        savedUser.LastName = dto.LastName;
                        savedUser.Active = dto.Active;
                        savedUser.Email = dto.Email;
                        savedUser.Phone = dto.Phone;
                        savedUser.UserName = dto.Email;
                        await IdentityContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("User Not Found");
                    }
                }
                else
                {
                    savedUser = AddNewuser(IdentityContext, dto);
                }
                var rolesAdded = UpdateRole(dto.Role, savedUser, IdentityContext);
                dto.Id = savedUser.Id;
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private ApplicationUser AddNewuser(ApplicationDbContext context, UserDTO dto)
        {
            try
            {
                var userStore = new ApplicationUserStore(context);
                var usermanager = new ApplicationUserManager(userStore);
                var id1 = Guid.NewGuid().ToString();
                usermanager.Create(new ApplicationUser()
                {
                    Id = id1,
                    UserName = dto.Email,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Active = dto.Active,
                    Phone = dto.Phone,
                    ClientId = dto.ClientId
                }, "Developer1!");
                return usermanager.FindByEmail(dto.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private bool UpdateRole(string role, ApplicationUser user, ApplicationDbContext context)
        {
            try
            {
                var userStore = new ApplicationUserStore(context);
                var usermanager = new ApplicationUserManager(userStore);
                var id1 = Guid.NewGuid().ToString();
                var roles = usermanager.GetRoles(user.Id);
                usermanager.RemoveFromRoles(user.Id, roles.ToArray());
                usermanager.AddToRole(user.Id, role);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}