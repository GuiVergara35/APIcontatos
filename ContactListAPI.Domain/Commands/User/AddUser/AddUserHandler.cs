using System.Threading;
using System.Threading.Tasks;
using prmToolkit.NotificationPattern;
using MediatR;
using ContactListAPI.Domain.Interfaces.Repositories;

namespace ContactListAPI.Domain.Commands.User.AddUser
{
    public class AddUserHandler : Notifiable, IRequestHandler<AddUserRequest, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public AddUserHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Response> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            //Validating the request
            if (request == null)
            {
                AddNotification("Request", "Must inform user's data");
                return new Response(this);
            }

            //Verify if user exists
            if (_userRepository.Existe(x => x.Email.Equals(request.Email)))
            {
                AddNotification("Email", "Email already registered.");
                return new Response(this);
            }

            Entities.User user = new Entities.User(request.FirstName, request.LastName, request.Email, request.Password);

            AddNotifications(user);

            if (IsInvalid())
            {
                return new Response(this);
            }

            user = _userRepository.Adicionar(user);

            //Creating response object
            var response = new Response(this, user);

            AddUserNotification userNotification = new AddUserNotification(user);
            await _mediator.Publish(userNotification);

            return await Task.FromResult(response);
        }
    }
}
