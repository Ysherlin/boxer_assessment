using boxer_assessment.Domain.Entities;
using boxer_assessment.Dtos;
using boxer_assessment.Repositories.Interfaces;
using boxer_assessment.Services.Interfaces;

namespace boxer_assessment.Services
{
    /// <inheritdoc />
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Employee repository instance.
        /// </summary>
        private readonly IEmployeeRepository _repository;

        /// <summary>
        /// Creates a new employee service.
        /// </summary>
        /// <param name="repository">Employee repository.</param>
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async Task<PagedResultDto<EmployeeReadDto>> GetAllAsync(
            string? search,
            int pageNumber,
            int pageSize)
        {
            var employees = await _repository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.ToLower();

                employees = employees
                    .Where(e =>
                        e.FirstName.ToLower().Contains(term) ||
                        e.LastName.ToLower().Contains(term) ||
                        e.Email.ToLower().Contains(term))
                    .ToList();
            }

            var totalCount = employees.Count;

            var pagedItems = employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EmployeeReadDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    JobTitleId = e.JobTitleId,
                    JobTitle = e.JobTitle.TitleName
                })
                .ToList();

            return new PagedResultDto<EmployeeReadDto>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        /// <inheritdoc />
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
                JobTitleId = employee.JobTitleId,
                JobTitle = employee.JobTitle.TitleName
            };
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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
