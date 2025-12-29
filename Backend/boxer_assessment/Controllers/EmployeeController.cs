using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using boxer_assessment.Data;
using boxer_assessment.Domain.Entities;
using boxer_assessment.Dtos;

namespace boxer_assessment.Controllers
{
    /// <summary>
    /// API controller for managing employees.
    /// </summary>
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        /// <summary>
        /// Creates a new employee controller.
        /// </summary>
        /// <param name="context">Database context.</param>
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAll()
        {
            var employees = await _context.Employees
                .Include(e => e.JobTitle)
                .Select(e => new EmployeeReadDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    JobTitle = e.JobTitle.TitleName
                })
                .ToListAsync();

            return Ok(employees);
        }

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.JobTitle)
                .Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeReadDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    JobTitle = e.JobTitle.TitleName
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeCreateDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Salary = dto.Salary,
                IsActive = dto.IsActive,
                JobTitleId = dto.JobTitleId,
                CreatedDate = DateTime.UtcNow
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, null);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeUpdateDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Salary = dto.Salary;
            employee.IsActive = dto.IsActive;
            employee.JobTitleId = dto.JobTitleId;
            employee.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
