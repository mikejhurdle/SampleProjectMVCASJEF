using SampleProjectMVCAJSEF.IDataAccess;
using SampleProjectMVCAJSEF.IDataServices;
using SampleProjectMVCAJSEF.Models.DTO;
using SampleProjectMVCAJSEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleProjectMVCAJSEF.DataServices
{
    public class DropdownService : BaseService, IDropdownService
    {
        public DropdownService(IDbContext db) : base(db) { }
        public async Task<int> AddDropdownType(string name)
        {
            if (_db.DropdownType.Any(a => a.Name == name))
            {
                return await _db.DropdownType.Where(w => w.Name == name).Select(s => s.Id).FirstOrDefaultAsync();
            }
            else
            {
                var ddt = new DropdownType { Name = name };
                _db.DropdownType.Add(ddt);
                await _db.SaveChangesAsync();
                return ddt.Id;
            }
        }

        public async Task<List<DropdownTypeDTO>> GetDropDownValues()
        {
            return await _db.DropdownType.Select(s => new DropdownTypeDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Values = s.Values.Select(s2 => new DropdownDTO { Name = s2.Value, Active = s2.Active, TypeId = s2.DropdownTypeId, Id = s2.Id }).ToList()
            }).ToListAsync();
        }

        public async Task<List<DropdownDTO>> GetDropDownValuesByType(string type)
        {

            return await _db.DropdownValue.Where(w => w.DropdownType.Name == type).Select(s => new DropdownDTO
            {
                Name = s.Value,
                Active = s.Active,
                TypeId = s.DropdownTypeId,
                Id = s.Id
            }).ToListAsync();
        }

        public async Task<int> SaveDropDownValue(DropdownDTO dto)
        {
            var returnId = 0;
            if (dto.Id > 0)
            {
                var existing = await _db.DropdownValue.Where(w => w.Id == dto.Id).FirstOrDefaultAsync();
                if (existing != null)
                {
                    existing.Active = dto.Active;
                    existing.Value = dto.Name;
                    existing.DropdownTypeId = dto.TypeId;
                    await _db.SaveChangesAsync();
                    returnId = existing.Id;
                }

            }
            else
            {
                var existing = await _db.DropdownValue.FirstOrDefaultAsync(w => w.Value == dto.Name);
                if (existing != null)
                {
                    existing.Active = dto.Active;
                    existing.Value = dto.Name;
                    existing.DropdownTypeId = dto.TypeId;
                    await _db.SaveChangesAsync();
                    returnId = existing.Id;
                }
                else
                {
                    var newDDVal = new DropdownValue
                    {
                        Active = dto.Active,
                        Value = dto.Name,
                        DropdownTypeId = dto.TypeId
                    };
                    _db.DropdownValue.Add(newDDVal);
                    await _db.SaveChangesAsync();
                    returnId = newDDVal.Id;
                }


            }
            return returnId;
        }
    }
}