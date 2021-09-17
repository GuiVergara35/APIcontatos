using System;
using ContactListAPI.Domain.Entities.Base;
using ContactListAPI.Domain.Enums;

namespace ContactListAPI.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string ContactName { get; set; }
        public string Telephone { get; set; }
        public EnumNiche Niche { get; set; }
        public User User { get; set; }
    }
}
