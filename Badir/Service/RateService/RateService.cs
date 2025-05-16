namespace Badir.Service.RateService;

public class RateService(IRepositoryWrapper wrapper, IMapper mapper) : IRateService
{
    public async Task<(RateDto? data, string? error)> Add( RateForm form)
    {

        var user = await wrapper.User.GetById(form.UserId);
        if (user == null)
        {
            return (null, "User not found");
        }
        var admin = await wrapper.User.GetById(form.RaterId);
        if (admin == null)
        {
            return (null, "Admin not found");
        }
        if (form.RateNumber > 5 || form.RateNumber < 0)
        {
            return (null, "Rate number should be between 1 and 5");
        }
        var existingRate = await wrapper.Rate.Get(r => r.UserId == form.UserId  && r.RaterId == form.RaterId);
        if (existingRate != null)
        {
            existingRate.RateNumber = form.RateNumber; 
            await wrapper.Rate.Update(existingRate);

            return (mapper.Map<RateDto>(existingRate), null);

        }

        var rate = mapper.Map<Rate>(form);
        var result = await wrapper.Rate.Add(rate);
        if (result == null)
        {
            return (null, "Error Rate adding");
        }
        return (mapper.Map<RateDto>(result), null);
    }
}