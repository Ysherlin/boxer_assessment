namespace boxer_assessment.Dtos
{
    /// <summary>
    /// DTO for returning employee data.
    /// </summary>
    public class EmployeeReadDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string JobTitle { get; set; } = null!;
    }
}
