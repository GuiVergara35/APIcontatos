using System;
using ContactListAPI.Domain.Entities.Base;
using ContactListAPI.Domain.Enums;

namespace ContactListAPI.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public EnumNiche Niche { get; set; }
        public User User { get; set; }

    }
}
