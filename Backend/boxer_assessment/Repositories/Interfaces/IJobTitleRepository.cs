using boxer_assessment.Domain.Entities;

namespace boxer_assessment.Repositories.Interfaces
{
    /// <summary>
    /// Defines job title data access operations.
    /// </summary>
    public interface IJobTitleRepository
    {
        /// <summary>
        /// Gets all job titles.
        /// </summary>
        Task<List<JobTitle>> GetAllAsync();
    }
}
