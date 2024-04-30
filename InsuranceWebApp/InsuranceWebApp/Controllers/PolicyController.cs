using InsuranceWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly EmployeeInsuranceContext _context;

        public PolicyController(EmployeeInsuranceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PolicyDetail>> Get()
        {
            return await _context.PolicyDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var policy = await _context.PolicyDetails.FirstOrDefaultAsync(m => m.EmpId == id);
            if (policy == null)
                return NotFound();
            return Ok(policy);
        }
    }
}
