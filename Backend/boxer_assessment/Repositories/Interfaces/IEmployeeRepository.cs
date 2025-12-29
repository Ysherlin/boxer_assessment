using boxer_assessment.Domain.Entities;

namespace boxer_assessment.Repositories.Interfaces
{
    /// <summary>
    /// Defines data access operations for employees.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        Task<List<Employee>> GetAllAsync();

        /// <summary>
        /// Gets an employee by identifier.
        /// </summary>
        /// <param name="id">Employee identifier.</param>
        Task<Employee?> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">Employee entity.</param>
        Task AddAsync(Employee employee);

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="employee">Employee entity.</param>
        Task UpdateAsync(Employee employee);

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="employee">Employee entity.</param>
        Task DeleteAsync(Employee employee);
    }
}
