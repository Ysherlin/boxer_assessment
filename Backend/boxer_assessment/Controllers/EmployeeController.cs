using Microsoft.AspNetCore.Mvc;
using boxer_assessment.Dtos;
using boxer_assessment.Services.Interfaces;

namespace boxer_assessment.Controllers
{
    /// <summary>
    /// API controller for managing employees.
    /// </summary>
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        /// <summary>
        /// Creates a new employee controller.
        /// </summary>
        /// <param name="service">Employee service.</param>
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a paged list of employees with optional search.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PagedResultDto<EmployeeReadDto>>> GetAll(
            [FromQuery] string? search,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllAsync(search, pageNumber, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);

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
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
