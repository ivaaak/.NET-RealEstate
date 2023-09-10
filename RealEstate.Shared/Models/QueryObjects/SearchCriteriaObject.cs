namespace RealEstate.Shared.Models.QueryObjects
{
    public class SearchCriteriaObject
    {
        public string? SearchTerm { get; set; }

        public string? SortBy { get; set; }

        public bool SortDescending { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
