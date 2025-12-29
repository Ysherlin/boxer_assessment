using boxer_assessment.Domain.Entities;
using boxer_assessment.Dtos;
using boxer_assessment.Repositories.Interfaces;
using boxer_assessment.Services;
using boxer_assessment.Services.Interfaces;
using Moq;

namespace boxer_assessment.Tests.Services
{
    /// <summary>
    /// Unit tests for EmployeeService.
    /// </summary>
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _repositoryMock = null!;
        private IEmployeeService _service = null!;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetAllAsync_ReturnsPagedEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@company.com",
                    Salary = 50000,
                    IsActive = true,
                    JobTitle = new JobTitle { TitleName = "Developer" }
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane@company.com",
                    Salary = 60000,
                    IsActive = true,
                    JobTitle = new JobTitle { TitleName = "Manager" }
                }
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(employees);

            // Act
            var result = await _service.GetAllAsync(
                search: null,
                pageNumber: 1,
                pageSize: 10);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Items.Count, Is.EqualTo(2));
            Assert.That(result.TotalCount, Is.EqualTo(2));
            Assert.That(result.Items[0].FirstName, Is.EqualTo("John"));
        }

        [Test]
        public async Task GetAllAsync_WithSearch_ReturnsFilteredEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@company.com",
                    IsActive = true,
                    JobTitle = new JobTitle { TitleName = "Developer" }
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane@company.com",
                    IsActive = true,
                    JobTitle = new JobTitle { TitleName = "Manager" }
                }
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(employees);

            // Act
            var result = await _service.GetAllAsync(
                search: "john",
                pageNumber: 1,
                pageSize: 10);

            // Assert
            Assert.That(result.Items.Count, Is.EqualTo(1));
            Assert.That(result.Items[0].FirstName, Is.EqualTo("John"));
        }

        [Test]
        public async Task GetAllAsync_WithPagination_ReturnsCorrectPage()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "A", Email = "a@test.com", JobTitle = new JobTitle { TitleName = "Dev" } },
                new Employee { EmployeeId = 2, FirstName = "B", Email = "b@test.com", JobTitle = new JobTitle { TitleName = "Dev" } },
                new Employee { EmployeeId = 3, FirstName = "C", Email = "c@test.com", JobTitle = new JobTitle { TitleName = "Dev" } }
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(employees);

            // Act
            var result = await _service.GetAllAsync(
                search: null,
                pageNumber: 2,
                pageSize: 1);

            // Assert
            Assert.That(result.Items.Count, Is.EqualTo(1));
            Assert.That(result.Items[0].FirstName, Is.EqualTo("B"));
            Assert.That(result.TotalCount, Is.EqualTo(3));
        }

        [Test]
        public async Task GetByIdAsync_WhenEmployeeExists_ReturnsEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane@company.com",
                IsActive = true,
                JobTitle = new JobTitle { TitleName = "Manager" }
            };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(employee);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.FirstName, Is.EqualTo("Jane"));
            Assert.That(result.JobTitle, Is.EqualTo("Manager"));
        }

        [Test]
        public async Task GetByIdAsync_WhenEmployeeDoesNotExist_ReturnsNull()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Employee?)null);

            // Act
            var result = await _service.GetByIdAsync(99);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateAsync_CreatesEmployeeAndReturnsId()
        {
            // Arrange
            var dto = new EmployeeCreateDto
            {
                FirstName = "New",
                LastName = "User",
                Email = "new@company.com",
                Salary = 45000,
                IsActive = true,
                JobTitleId = 2
            };

            _repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Employee>()))
                .Callback<Employee>(e => e.EmployeeId = 10)
                .Returns(Task.CompletedTask);

            // Act
            var id = await _service.CreateAsync(dto);

            // Assert
            Assert.That(id, Is.EqualTo(10));
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_WhenEmployeeExists_ReturnsTrue()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1 };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(employee);

            var dto = new EmployeeUpdateDto
            {
                FirstName = "Updated",
                LastName = "Name",
                Salary = 70000,
                IsActive = true,
                JobTitleId = 3
            };

            // Act
            var result = await _service.UpdateAsync(1, dto);

            // Assert
            Assert.That(result, Is.True);
            _repositoryMock.Verify(r => r.UpdateAsync(employee), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_WhenEmployeeDoesNotExist_ReturnsFalse()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Employee?)null);

            var dto = new EmployeeUpdateDto
            {
                FirstName = "Test",
                LastName = "User",
                Salary = 50000,
                IsActive = true,
                JobTitleId = 1
            };

            // Act
            var result = await _service.UpdateAsync(1, dto);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DeleteAsync_WhenEmployeeExists_ReturnsTrue()
        {
            // Arrange
            var employee = new Employee { EmployeeId = 1 };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(employee);

            // Act
            var result = await _service.DeleteAsync(1);

            // Assert
            Assert.That(result, Is.True);
            _repositoryMock.Verify(r => r.DeleteAsync(employee), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_WhenEmployeeDoesNotExist_ReturnsFalse()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Employee?)null);

            // Act
            var result = await _service.DeleteAsync(1);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
