namespace Badir.Dto.Rate;

public class RateForm
{
    public required int RateNumber { get; set; }
    public required int UserId { get; set; }
    public required int RaterId { get; set; }
}