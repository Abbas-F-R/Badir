namespace Badir.Repository;

public class RateRepository : GenericRepository<Rate, int> , IRateRepository
{

    public RateRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}