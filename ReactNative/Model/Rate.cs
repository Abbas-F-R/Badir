using System.ComponentModel.DataAnnotations.Schema;

namespace ReactNative.Model;

[Table("rates")]

public class Rate : BaseEntity
{
    public int? RateNumber { get; set; }
    public int? UserId { get; set; }
    public int? RaterId { get; set; }
}