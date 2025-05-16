
namespace Badir.Repository;

public class UserRepository : GenericRepository<User, int> , IUserRepository
{
    public UserRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}