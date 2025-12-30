using boxer_assessment.Domain.Entities;
using boxer_assessment.Repositories.Interfaces;
using boxer_assessment.Services;
using boxer_assessment.Services.Interfaces;
using Moq;

namespace boxer_assessment.Tests.Services
{
    /// <summary>
    /// Unit tests for the job title service.
    /// </summary>
    public class JobTitleServiceTests
    {
        /// <summary>
        /// Mocked job title repository.
        /// </summary>
        private Mock<IJobTitleRepository> _repositoryMock = null!;

        /// <summary>
        /// Job title service under test.
        /// </summary>
        private IJobTitleService _service = null!;

        /// <summary>
        /// Sets up test dependencies.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IJobTitleRepository>();
            _service = new JobTitleService(_repositoryMock.Object);
        }

        /// <summary>
        /// Verifies that all job titles are returned.
        /// </summary>
        [Test]
        public async Task GetAllAsync_ReturnsJobTitles()
        {
            // Arrange
            var jobTitles = new List<JobTitle>
            {
                new JobTitle { JobTitleId = 1, TitleName = "Junior Developer" },
                new JobTitle { JobTitleId = 2, TitleName = "Developer" }
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(jobTitles);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].TitleName, Is.EqualTo("Junior Developer"));
            Assert.That(result[1].TitleName, Is.EqualTo("Developer"));
        }

        /// <summary>
        /// Verifies that an empty list is returned when no job titles exist.
        /// </summary>
        [Test]
        public async Task GetAllAsync_WhenNoJobTitles_ReturnsEmptyList()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<JobTitle>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that job titles are mapped correctly to DTOs.
        /// </summary>
        [Test]
        public async Task GetAllAsync_MapsEntitiesToDtosCorrectly()
        {
            // Arrange
            var jobTitles = new List<JobTitle>
            {
                new JobTitle { JobTitleId = 5, TitleName = "Manager" }
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(jobTitles);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            var dto = result.Single();
            Assert.That(dto.JobTitleId, Is.EqualTo(5));
            Assert.That(dto.TitleName, Is.EqualTo("Manager"));
        }
    }
}
