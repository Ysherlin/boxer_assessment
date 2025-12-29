namespace boxer_assessment.Dtos
{
    /// <summary>
    /// Represents a paged result.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class PagedResultDto<T>
    {
        /// <summary>
        /// Items for the current page.
        /// </summary>
        public List<T> Items { get; set; } = new();

        /// <summary>
        /// Total number of items.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Current page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        public int PageSize { get; set; }
    }
}
