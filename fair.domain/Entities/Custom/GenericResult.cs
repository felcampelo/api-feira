namespace fair.domain.Entities.Custom
{
    public class GenericResult
    {
        public GenericResult()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public object? Content { get; set; }
        public int TotalRecords { get; set; }
    }
}
