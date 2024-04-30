using InsuranceWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeInsuranceContext _context;

        public EmployeeController(EmployeeInsuranceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDetail>> Get()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var employee = await _context.EmployeeDetails.FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
    }
}
