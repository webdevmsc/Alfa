using System;
using System.Threading.Tasks;
using AlfaProject.Features.UserFeatures.Create;
using AlfaProject.Features.UserFeatures.Delete;
using AlfaProject.Features.UserFeatures.GetAll;
using AlfaProject.Features.UserFeatures.GetExcel;
using AlfaProject.Features.UserFeatures.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlfaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllRequest()));
        }
        
        [HttpGet]
        [Route("GetExcel")]
        public async Task<IActionResult> GetExcel()
        {
            return File(await _mediator.Send(new GetExcelRequest()), $"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Users-{DateTime.Now.ToLocalTime()}.xlsx");
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