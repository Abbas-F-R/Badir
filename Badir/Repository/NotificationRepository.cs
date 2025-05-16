namespace Badir.Repository;

public class NotificationRepository : GenericRepository<Notification, int> , INotificationRepository
{
    public NotificationRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}