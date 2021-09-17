using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ContactListAPI.Domain.Commands.User.AddUser.Notifications
{
    public class SendEmailUserActivating : INotificationHandler<AddUserNotification>
    {
        public async Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Send email to user " + notification.User.FirstName);
        }
    }
}
