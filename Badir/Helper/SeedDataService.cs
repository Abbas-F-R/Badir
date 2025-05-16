
namespace Badir.Helper
{
    public class SeedDataService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedDataService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var wrapper = scope.ServiceProvider.GetRequiredService<IRepositoryWrapper>();
                var tokenService = scope.ServiceProvider.GetRequiredService<TokenService>();
                var existingAdmin = await wrapper.User.Get(u => u.Username == "username");
                
                if (existingAdmin == null)
                {
                    string adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("password");
                    var admin = new User("name", adminPasswordHash, "username", Role.Admin, "", "", "");
                    var result = await wrapper.User.Add(admin);
                    if (result == null) { return; }
                    var adminToken = tokenService.CreateToken(result, null);
                }
                else
                {
                    var adminToken = tokenService.CreateToken(existingAdmin, null);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}