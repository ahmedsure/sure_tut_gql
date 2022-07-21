using Microsoft.AspNetCore.Mvc;

namespace GQLDEMOTUT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult( new { x= "Done Testing "});
        }
    }
}
