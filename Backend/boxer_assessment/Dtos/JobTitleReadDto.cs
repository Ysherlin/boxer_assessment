namespace boxer_assessment.Dtos
{
    /// <summary>
    /// DTO for returning job title lookup data.
    /// </summary>
    public class JobTitleReadDto
    {
        /// <summary>
        /// Job title identifier.
        /// </summary>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Job title display name.
        /// </summary>
        public string TitleName { get; set; } = null!;
    }
}
