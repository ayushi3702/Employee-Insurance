using InsuranceWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmployeeInsuranceContext _context;

        public LoginController(EmployeeInsuranceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginRequest model)
        {
            var user = _context.UserLoginDetails.SingleOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return NotFound("User not found"); // If user is not found, return 404 Not Found with a message
            }

            if (user.Password != model.Password)
            {
                return BadRequest("Incorrect password"); // If password is incorrect, return 400 Bad Request with a message
            }

            return Ok(user);
        }
    }
}
