using boxer_assessment.Domain.Entities;
using boxer_assessment.Dtos;
using boxer_assessment.Repositories.Interfaces;
using boxer_assessment.Services.Interfaces;

namespace boxer_assessment.Services
{
    /// <summary>
    /// Employee service implementation.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        /// <summary>
        /// Creates a new service instance.
        /// </summary>
        /// <param name="repository">Employee repository.</param>
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeReadDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees.Select(e => new EmployeeReadDto
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Salary = e.Salary,
                IsActive = e.IsActive,
                JobTitle = e.JobTitle.TitleName
            }).ToList();
        }

        public async Task<EmployeeReadDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return null;
            }

            return new EmployeeReadDto
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                JobTitle = employee.JobTitle.TitleName
            };
        }

        public async Task<int> CreateAsync(EmployeeCreateDto dto)
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

            await _repository.AddAsync(employee);

            return employee.EmployeeId;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return false;
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Salary = dto.Salary;
            employee.IsActive = dto.IsActive;
            employee.JobTitleId = dto.JobTitleId;
            employee.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(employee);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return false;
            }

            await _repository.DeleteAsync(employee);

            return true;
        }
    }
}
