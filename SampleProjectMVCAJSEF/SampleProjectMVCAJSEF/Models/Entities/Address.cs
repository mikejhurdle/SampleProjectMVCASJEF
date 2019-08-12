using SampleProjectMVCAJSEF.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models.Entities
{
    public class Address : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PrimaryPhone { get; set; }
        public string Fax { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
        public Address() { }
        public Address(AddressDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Address1 = dto.Address1;
            Address2 = dto.Address2;
            City = dto.City;
            State = dto.State;
            Zip = dto.Zip;
            Country = dto.Country;
            IsPrimary = true;
        }
    }
}