namespace boxer_assessment.Dtos
{
    /// <summary>
    /// Data returned for an employee.
    /// </summary>
    public class EmployeeReadDto
    {
        /// <summary>
        /// Employee identifier.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee first name.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Employee last name.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Employee email address.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Employee salary.
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Indicates whether the employee is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Job title identifier.
        /// </summary>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Job title name.
        /// </summary>
        public string JobTitle { get; set; } = null!;
    }
}
