using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactListAPI.Data.Repositories.Transactions;
using ContactListAPI.Domain.Commands.User.AddUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactListAPI.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AddUserRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                if (!response.Notifications.Any())
                    _unitOfWork.SaveChanges();
                return Ok(response);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
        }
    }
}
