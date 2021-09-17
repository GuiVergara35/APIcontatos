using System;
using ContactListAPI.Domain.Entities.Base;

namespace ContactListAPI.Domain.Entities
{
    public class MessageSending : BaseEntity
    {
        public Campaign Campaign { get; set; }
        public Group Group { get; set; }
        public Contact Contact { get; set; }
        public bool Sent { get; set; }
    }
}
