using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.Models.TestModels;


/// CREATE CONTROLLER FOR PROJECT LOADING - 2024/11/30
namespace MyPortfolioSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult TestEndpoint()

        {
            return Ok("Backend is working!");
        }

        [HttpPost("post")]
        public IActionResult PostTestEndpoint([FromBody] Test_InputModel model)
        {
            if(model.Name == null)
            {
                return BadRequest("Title cannot be empty");
            }

            var response = new { Greeting = $"Hello, {model.Name}"! };

            return Ok(response.Greeting);

        }
    }
}
