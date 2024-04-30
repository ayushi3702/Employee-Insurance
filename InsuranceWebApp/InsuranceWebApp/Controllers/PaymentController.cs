using InsuranceWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly EmployeeInsuranceContext _context;

        public PaymentController(EmployeeInsuranceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentDetail>> Get()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        [HttpGet("{EmpId}")]
        public async Task<IActionResult> Get(int EmpId)
        {
            if (EmpId < 1)
                return BadRequest();
            var payment = await _context.PaymentDetails.Where(m => m.EmpId == EmpId).ToListAsync();
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentDetail payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(PaymentDetail paymentData)
        {
            if (paymentData == null || paymentData.PaymentId == 0)
                return BadRequest();

            var payment = await _context.PaymentDetails.FindAsync(paymentData.PaymentId);
            if (payment == null)
                return NotFound();
            payment.BankName = paymentData.BankName;
            payment.CardHolderName = paymentData.CardHolderName;
            payment.CardNumber = paymentData.CardNumber;
            payment.CardExpiryDate = paymentData.CardExpiryDate;
            payment.Cvv = paymentData.Cvv;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var payment = await _context.PaymentDetails.FindAsync(id);
            if (payment == null)
                return NotFound();
            _context.PaymentDetails.Remove(payment);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
