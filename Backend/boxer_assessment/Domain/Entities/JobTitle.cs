namespace boxer_assessment.Domain.Entities
{
    /// <summary>
    /// Represents a job title entity.
    /// </summary>
    public class JobTitle
    {
        /// <summary>
        /// Job title primary key.
        /// </summary>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Name of the job title.
        /// </summary>
        public string TitleName { get; set; } = null!;

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
