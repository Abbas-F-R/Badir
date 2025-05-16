namespace Badir.Base;

public class ResponseWithDetails<T,D>
{
    public List<T>? Data { get; set; }
    public D Details { get; set; }
    public int? PagesCount { get; set; }
    public int CurrentPage { get; set; }
    public int? TotalCount { get; set; }
    public bool IsLast  { get; set; }
    
    
    
    public ResponseWithDetails()
    {
    }

    public ResponseWithDetails(bool status, string message, List<T>? data, D details, int pagesCount, int currentPage, bool isLast, int totalCount)
    {
        Data = data;
        Details = details;
        PagesCount = pagesCount;
        CurrentPage = currentPage;
        TotalCount = totalCount;
        IsLast = isLast;

    }
}
