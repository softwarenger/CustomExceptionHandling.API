using CustomExceptionHandlingMiddleware.API;
using Microsoft.AspNetCore.Mvc;

namespace CustomExceptionHandling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomExceptionController : ControllerBase
    {
         
        [HttpGet]
        public IActionResult GetAllContent()
        {
            throw new CustomException("something went wrong...");
        }
    }
}