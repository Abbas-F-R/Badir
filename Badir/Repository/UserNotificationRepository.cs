namespace Badir.Repository;

public class UserNotificationRepository : GenericRepository<UserNotification, int> , IUserNotificationRepository
{
    public UserNotificationRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}