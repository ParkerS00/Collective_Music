using Bunit;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MusicApi.Data;
using Testcontainers.PostgreSql;

namespace MusicTests;

public class PageTestContext : TestContext, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;

    public PageTestContext()
    {
        var whereAmI = Environment.CurrentDirectory;
        var backupFile = Directory.GetFiles("../../../..", "*.sql", SearchOption.AllDirectories)
            .Select(f => new FileInfo(f))
            .OrderByDescending(fi => fi.LastWriteTime)
            .First();
        _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres")
            .WithPassword("Strong_password_123!")
            .WithBindMount(backupFile.FullName, "/docker-entrypoint-initdb.d/init.sql")
            .Build();
    }


    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        Services.RemoveAll(typeof(DbContextOptionsBuilder<MusicDbContext>));
        Services.AddDbContextFactory<MusicDbContext>((provider, options) => {
            IConfiguration config = provider.GetRequiredService<IConfiguration>();
            options.UseSqlServer(_dbContainer.GetConnectionString());
        });
        var factory = Services.GetRequiredService<IDbContextFactory<MusicDbContext>>();
        var dbContext = factory.CreateDbContext();
        await dbContext.Database.MigrateAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}