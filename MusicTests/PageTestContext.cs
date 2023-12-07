using Bunit;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MusicApi.Data;
using MusicBlazorApp.State;
using Testcontainers.PostgreSql;

namespace MusicTests;

public class PageTestContext : TestContext, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;

    public PageTestContext()
    {
        _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres")
            .WithPassword("Strong_password_123!")
            .Build();

        Services.AddDbContextFactory<MusicDbContext>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
        Services.AddScoped<CartState>();
        Services.AddScoped<UrlState>();
        Services.AddIdentity<IdentityUser, IdentityRole>
            (options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<MusicDbContext>();
        Services.AddHostedService<DefaultUserService>();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var factory = Services.GetRequiredService<IDbContextFactory<MusicDbContext>>();
        var dbContext = await factory.CreateDbContextAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}