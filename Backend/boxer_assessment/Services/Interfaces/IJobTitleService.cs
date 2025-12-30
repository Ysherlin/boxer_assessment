using boxer_assessment.Dtos;

namespace boxer_assessment.Services.Interfaces
{
    /// <summary>
    /// Defines job title business operations.
    /// </summary>
    public interface IJobTitleService
    {
        /// <summary>
        /// Gets all job titles.
        /// </summary>
        Task<List<JobTitleReadDto>> GetAllAsync();
    }
}
