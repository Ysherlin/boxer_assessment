using boxer_assessment.Domain.Entities;

namespace boxer_assessment.Repositories.Interfaces
{
    /// <summary>
    /// Defines employee data access operations.
    /// </summary>
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(Employee employee);
    }
}
