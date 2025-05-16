namespace Badir.Repository;

public class PermissionRepository : GenericRepository<Permission, int> , IPermissionRepository
{
    public PermissionRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}