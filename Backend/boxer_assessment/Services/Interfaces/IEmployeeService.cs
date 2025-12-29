using boxer_assessment.Dtos;

namespace boxer_assessment.Services.Interfaces
{
    /// <summary>
    /// Defines employee business operations.
    /// </summary>
    public interface IEmployeeService
    {
        Task<List<EmployeeReadDto>> GetAllAsync();

        Task<EmployeeReadDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(EmployeeCreateDto dto);

        Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
