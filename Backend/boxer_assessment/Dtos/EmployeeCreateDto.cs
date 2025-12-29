using System.ComponentModel.DataAnnotations;

namespace boxer_assessment.Dtos
{
    /// <summary>
    /// Data used to create an employee.
    /// </summary>
    public class EmployeeCreateDto
    {
        /// <summary>
        /// Employee first name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Employee last name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Employee email address.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Employee salary.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        /// <summary>
        /// Indicates whether the employee is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Job title identifier.
        /// </summary>
        [Required]
        public int JobTitleId { get; set; }
    }
}
