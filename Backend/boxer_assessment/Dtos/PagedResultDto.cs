namespace boxer_assessment.Dtos
{
    /// <summary>
    /// Represents a paged result.
    /// </summary>
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; } = new();

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
