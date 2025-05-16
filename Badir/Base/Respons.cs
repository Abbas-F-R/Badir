namespace Badir.Base;

public class Response<T>
{
    public List<T>? Data { get; set; }
    public int? PagesCount { get; set; }
    public int CurrentPage { get; set; }
    public int? TotalCount { get; set; }
    public bool IsLast  { get; set; }
    
    
    
    public Response()
    {
    }

    public Response(bool status, string message, List<T>? data, int pagesCount, int currentPage, bool isLast, int totalCount)
    {
        Data = data;
        PagesCount = pagesCount;
        CurrentPage = currentPage;
        TotalCount = totalCount;
        IsLast = isLast;

    }
}