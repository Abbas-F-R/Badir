namespace Badir.Service.RateService;

public interface IRateService
{
    Task<(RateDto? data, string? error)> Add( RateForm form);

}