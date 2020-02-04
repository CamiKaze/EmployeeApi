using System.Linq;
using System.Threading.Tasks;
using Employees.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeDetailsController(EmployeeContext context) => _context = context;

        #region GET
        [HttpGet] // GET: api/EmployeeDetails
        public async Task<IActionResult> GetEmployeeDetails()
        {
            var employeeDetails = await _context.EmployeeDetails.ToListAsync();

            return Ok(employeeDetails);
        }
        #endregion

        #region GET/id
        [HttpGet("{id}")] // GET: api/EmployeeDetails/5
        public async Task<IActionResult> GetEmployeeDetail(long id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);

            return employeeDetail == null ? NotFound() : (IActionResult)Ok(employeeDetail);
        }
        #endregion

        #region PUT/id
        [HttpPut("{id}")] // PUT: api/EmployeeDetails/5
        public async Task<IActionResult> PutEmployeeDetail(long id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.id) { return BadRequest(); }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }
        #endregion

        #region POST
        [HttpPost] // POST: api/EmployeeDetails
        public async Task<IActionResult> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.EmployeeDetails.Add(employeeDetail);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeDetail), new { employeeDetail.id }, employeeDetail);
        }
        #endregion

        #region DELETE/id
        [HttpDelete("{id}")] // DELETE: api/EmployeeDetails/5
        public async Task<IActionResult> DeleteEmployeeDetail(long id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null) { return NotFound(); }

            _context.EmployeeDetails.Remove(employeeDetail);
            await _context.SaveChangesAsync();

            return Ok(employeeDetail);
        }
        #endregion

        private bool EmployeeDetailExists(long id) => _context.EmployeeDetails.Any(e => e.id == id);
    }
}