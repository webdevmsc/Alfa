using System.Threading.Tasks;
using AlfaProject.Database;
using AlfaProject.Features.UserFeatures.Create;
using AlfaProject.Features.UserFeatures.Delete;
using AlfaProject.Features.UserFeatures.GetAll;
using AlfaProject.Features.UserFeatures.Update;
using AlfaProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlfaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}