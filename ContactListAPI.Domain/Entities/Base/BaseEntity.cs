using System;
using prmToolkit.NotificationPattern;

namespace ContactListAPI.Domain.Entities.Base
{
    public abstract class BaseEntity : Notifiable
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
