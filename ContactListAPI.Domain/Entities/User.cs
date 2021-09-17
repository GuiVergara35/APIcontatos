using System;
using ContactListAPI.Domain.Entities.Base;
using ContactListAPI.Domain.Extensions;
using prmToolkit.NotificationPattern;

namespace ContactListAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            new AddNotifications<User>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 3, 50)
                .IfNullOrInvalidLength(x => x.LastName, 3, 50)
                .IfNotEmail(x => x.Email)
                .IfNullOrInvalidLength(x => x.Password, 7, 36);

            if (!string.IsNullOrEmpty(this.Password))
            {
                this.Password = Password.ConvertToMD5();
            }

            RegisterDate = DateTime.UtcNow;
            IsActive = false;

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public DateTime RegisterDate { get; private set; }
        public bool IsActive { get; private set; }


    }
}
