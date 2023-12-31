using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MusicApi;
using Microsoft.AspNetCore.Identity;
using MusicBlazorApp.State;
using MusicApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Google authentication 
var services = builder.Services;
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

// Google Authentication
services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["ClientId"];
    googleOptions.ClientSecret = configuration["ClientSecret"];
});

builder.Services.AddDbContext<MusicDbContext>(config => config.UseNpgsql(builder.Configuration["MusicDB"]));

builder.Services.AddScoped<CartState>();
builder.Services.AddScoped<UrlState>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>
    (options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<MusicDbContext>();

builder.Services.AddHostedService<DefaultUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
