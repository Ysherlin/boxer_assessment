using boxer_assessment.Dtos;

namespace boxer_assessment.Services.Interfaces
{
    /// <summary>
    /// Defines business operations for employees.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets a paged list of employees with optional search.
        /// </summary>
        /// <param name="search">Search term.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        Task<PagedResultDto<EmployeeReadDto>> GetAllAsync(
            string? search,
            int pageNumber,
            int pageSize);

        /// <summary>
        /// Gets an employee by identifier.
        /// </summary>
        /// <param name="id">Employee identifier.</param>
        Task<EmployeeReadDto?> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="dto">Employee creation data.</param>
        Task<int> CreateAsync(EmployeeCreateDto dto);

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">Employee identifier.</param>
        /// <param name="dto">Employee update data.</param>
        Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto);

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="id">Employee identifier.</param>
        Task<bool> DeleteAsync(int id);
    }
}
