namespace ReactNative.Service.RateService;

public interface IRateService
{
    Task<(RateDto? data, string? error)> Add( RateForm form);

}