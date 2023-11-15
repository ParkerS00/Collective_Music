using Microsoft.AspNetCore.Identity;

//This class should be in its own file, but for ease of copy/paste...
public class Constants
{
    public static string DefaultAdminUsername { get; } = nameof(DefaultAdminUsername);
    public static string DefaultAdminPassword { get; } = nameof(DefaultAdminPassword);
    public const string AdminRole = "admins";
}

public class DefaultUserService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultUserService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var username = config[Constants.DefaultAdminUsername];
        var password = config[Constants.DefaultAdminPassword];
        if (username is null || password is null)
        {
            throw new MissingDefaultAdminConfigException();
        }

        var user = await userManager.FindByNameAsync(username);
        if (user is null)
        {
            user = new IdentityUser() { Email = username, UserName = username, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new UnableToCreateDefaultAdminUserException(string.Join("; ", result.Errors.Select(e => e.Description)));

            var adminRole = await roleManager.FindByNameAsync(Constants.AdminRole);
            if (adminRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = Constants.AdminRole });
            }

            await userManager.AddToRoleAsync(user, Constants.AdminRole);
        }
    }
}