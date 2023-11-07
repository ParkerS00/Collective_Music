using Bunit;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicBlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace MusicTests
{
    public class BlazorIntegrationTestContext : TestContext, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer;

        public BlazorIntegrationTestContext()
        {
            _dbContainer = new PostgreSqlBuilder()
                .WithImage("postgres")
                .WithPassword("Strong_password_123!")
                .Build();

            Services.AddDbContextFactory<MusicDBContext>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();

            var dbContext = Services.GetRequiredService<MusicDBContext>();
            await dbContext.Database.MigrateAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
