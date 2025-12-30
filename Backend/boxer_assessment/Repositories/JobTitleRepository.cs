using boxer_assessment.Data;
using boxer_assessment.Domain.Entities;
using boxer_assessment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace boxer_assessment.Repositories
{
    /// <summary>
    /// Job title repository implementation.
    /// </summary>
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly EmployeeDbContext _context;

        /// <summary>
        /// Creates a new repository instance.
        /// </summary>
        /// <param name="context">Database context.</param>
        public JobTitleRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<List<JobTitle>> GetAllAsync()
        {
            return await _context.JobTitles
                .OrderBy(j => j.TitleName)
                .ToListAsync();
        }
    }
}
