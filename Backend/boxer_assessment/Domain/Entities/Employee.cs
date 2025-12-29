namespace boxer_assessment.Domain.Entities
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee primary key.
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
        /// Indicates if the employee is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Foreign key to job title.
        /// </summary>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Related job title.
        /// </summary>
        public JobTitle JobTitle { get; set; } = null!;

        /// <summary>
        /// Date the record was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date the record was last modified.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
