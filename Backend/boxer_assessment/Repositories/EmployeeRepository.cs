using Microsoft.EntityFrameworkCore;
using boxer_assessment.Data;
using boxer_assessment.Domain.Entities;
using boxer_assessment.Repositories.Interfaces;

namespace boxer_assessment.Repositories
{
    /// <inheritdoc />
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// Database context instance.
        /// </summary>
        private readonly EmployeeDbContext _context;

        /// <summary>
        /// Creates a new repository instance.
        /// </summary>
        /// <param name="context">Database context.</param>
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.JobTitle)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.JobTitle)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        /// <inheritdoc />
        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
