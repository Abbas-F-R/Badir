using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace Badir.Service.AuthService;

public class JwtService(IRepositoryWrapper wrapper, ITopicService service, TokenService.TokenService tokenService, IMapper mapper)
    : IJwtService
{
    public async Task<(Auth?, string? error)> Register(UserForm request)
    {
        var existingUser = await CheckExistingUser(request.Username);
        if (existingUser != null)
            return (null, "Username taken");
        var user = CreateUser(request,  Role.User);
        var result = await SaveUser(user);
        if (result == null)
            return (null, "User creation failed");
        var error = await CreateTopic(request.Username, result.Id);
        if (error != null)
            return (null, error);
        return GenerateAuthResponse(result, null);
    }
    


    public async Task<(Auth?, string? error)> Login(LoginRequest request)
    {
        var userSaved = await wrapper.User.Get(u => ( u.Username == request.Username), 
            x => x.Include(u => u.Permission!));
        if (userSaved == null)
            return (null, "User not found");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, userSaved.PasswordHash))
            return (null, "Wrong password");
        int tokenExpTime = ( userSaved.Role == Role.Manager )
            ? 12
            : 2;
        var token = tokenService.CreateToken(userSaved, tokenExpTime);
        var auth = new Auth(userSaved.Username!, token, userSaved.Id);
        return (auth, null);
    }

    public async Task<(Auth?, string?)> LoginWithGoogle(ClaimsPrincipal principal)
    {
        var email = principal.FindFirstValue(ClaimTypes.Email);
        var name = principal.FindFirstValue(ClaimTypes.Name);

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
            return (null, "Email or name not found from Google");

        try
        {
            // تحقق هل المستخدم موجود
            var user = await CheckExistingUser(email);

            // إذا لم يكن موجودًا، ننشئه
            if (user == null)
            {
                var newUser = new User
                {
                    Username = email,
                    Name = name,
                    Role = Role.User,
                    PasswordHash = "", // لأن تسجيل الدخول عن طريق Google
                };

                var result = await wrapper.User.Add(newUser);
                if (result == null || result.Id == null)
                    return (null, "Failed to create user");

                user = result;
            }

            // أنشئ التوكن
            var token = tokenService.CreateToken(user, 4);
            if (string.IsNullOrEmpty(token))
                return (null, "Failed to generate token");

            var auth = new Auth(user.Username!, token, user.Id);
            return (auth, null);
        }
        catch (Exception ex)
        {
            return (null, $"Exception occurred: {ex.Message}");
        }
    }




    
    /// ////////////////////////////////////////////
    private async Task<User?> CheckExistingUser(string username)
    {
        return await wrapper.User.Get(u => u.Username == username);
    }


    private User CreateUser(RegisterRequest request, Role role)
    {
        return new User
        {
            Name = request.Name,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Username = request.Username,
            Role = role,
        };
    }

    private User CreateUser(UserForm request, Role role)
    {
        return new User
        {
            Name = request.Name,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Username = request.Username,
            Role = role,
        };
    }
    
    private async Task<User?> SaveUser(User user)
    {
        return await wrapper.User.Add(user);
    }
    

    private (Auth?, string?) GenerateAuthResponse(User user, int? time)
    {
        var token = tokenService.CreateToken(user, time);
        return (new Auth(user.Username!, token, user.Id), null);
    }
    private async Task<string?> CreateTopic(string username, int userId)
    {
        var topicForm = new TopicForm { Name = username };
        var (_, error) = await service.Add(topicForm, userId, username);
        return error;
    }


    private bool IsValidRole(string role, RegisterRequest request)
    {
        if (!Enum.TryParse<Role>(role, out var parsedRole) ||
            parsedRole != Role.Admin &&
            (request.Role == Role.Manager ))
        {
            return false;
        }
        else if (parsedRole == Role.Admin &&
                 (request.Role == Role.Admin))
        {
            return false;
        }

        return true;
    }
    
    public async Task<(UserDto?, string? error)> AddPermission(UserPermissionsUpdate update)
    {
        var user = await wrapper.User.Get(
            u => u.Id == update.Id,
            x => x.Include(p => p.Permission!)
        );

        if (user == null)
            return (null, "");

        var (permissions, totalCount) = await wrapper.Permission.GetAll(p => update.PermissionIds.Contains(p.Id));
        if (permissions == null || totalCount <= 0)
        {
            return (null, "" );
        }

        foreach (var permission in permissions)
        {
            var existing = user.Permission!.FirstOrDefault(p => p.Id == permission.Id);
            if (existing != null)
                user.Permission!.Remove(existing);
            else
                user.Permission!.Add(permission);
        }

        var result = await wrapper.User.Update(user);
        return (mapper.Map<UserDto>(result), null);
    }
}