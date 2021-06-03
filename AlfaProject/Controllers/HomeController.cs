using System.Threading.Tasks;
using AlfaProject.Database;
using AlfaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlfaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController(IUserRepository userRepository)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok("Hello");
        }
    }
}