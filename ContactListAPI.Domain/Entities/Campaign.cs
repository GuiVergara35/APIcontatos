using System;
using ContactListAPI.Domain.Entities.Base;

namespace ContactListAPI.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string CampaignName { get; set; }
        public User User { get; set; }
    }
}
