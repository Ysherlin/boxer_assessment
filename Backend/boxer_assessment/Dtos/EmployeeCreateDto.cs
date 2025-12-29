using System.ComponentModel.DataAnnotations;

namespace boxer_assessment.Dtos
{
    /// <summary>
    /// DTO for creating an employee.
    /// </summary>
    public class EmployeeCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int JobTitleId { get; set; }
    }
}
