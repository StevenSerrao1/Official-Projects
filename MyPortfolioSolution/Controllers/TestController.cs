using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.Models.TestModels;

namespace MyPortfolioSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("get")]
        [HttpGet("")]
        public IActionResult TestEndpoint()

        {
            return Ok("Backend is working!");
        }

        [HttpPost("post")]
        public IActionResult PostTestEndpoint([FromBody] Test_InputModel model)
        {
            if(model.Name == null)
            {
                return BadRequest("Name cannot be empty");
            }

            var response = new { Greeting = $"Hello, {model.Name}"! };

            return Ok(response.Greeting);

        }
    }

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // Redirect web app startup to 'Home' action method below
        [Route("/")]
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction("Home");
        }

        // Initial app startup action method **
        [HttpGet("")]
        public IActionResult Home()
        {
            return Ok("Home page");
        }
    }
}
