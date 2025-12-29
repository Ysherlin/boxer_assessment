namespace boxer_assessment.Dtos
{
    /// <summary>
    /// DTO for updating an employee.
    /// </summary>
    public class EmployeeUpdateDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public int JobTitleId { get; set; }
    }
}
