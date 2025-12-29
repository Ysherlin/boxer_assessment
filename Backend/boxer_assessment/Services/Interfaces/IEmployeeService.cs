using boxer_assessment.Dtos;

namespace boxer_assessment.Services.Interfaces
{
    /// <summary>
    /// Defines employee business operations.
    /// </summary>
    public interface IEmployeeService
    {
        Task<PagedResultDto<EmployeeReadDto>> GetAllAsync(
            string? search,
            int pageNumber,
            int pageSize);

        Task<EmployeeReadDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(EmployeeCreateDto dto);

        Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
