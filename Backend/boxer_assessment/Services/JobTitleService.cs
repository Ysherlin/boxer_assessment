using boxer_assessment.Dtos;
using boxer_assessment.Repositories.Interfaces;
using boxer_assessment.Services.Interfaces;

namespace boxer_assessment.Services
{
    /// <summary>
    /// Job title service implementation.
    /// </summary>
    public class JobTitleService : IJobTitleService
    {
        private readonly IJobTitleRepository _repository;

        /// <summary>
        /// Creates a new service instance.
        /// </summary>
        /// <param name="repository">Job title repository.</param>
        public JobTitleService(IJobTitleRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async Task<List<JobTitleReadDto>> GetAllAsync()
        {
            var titles = await _repository.GetAllAsync();

            return titles
                .Select(t => new JobTitleReadDto
                {
                    JobTitleId = t.JobTitleId,
                    TitleName = t.TitleName
                })
                .ToList();
        }
    }
}
