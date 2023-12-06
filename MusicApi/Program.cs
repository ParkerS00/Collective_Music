using Microsoft.EntityFrameworkCore;
using MusicApi.Services;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using System.Configuration;
using MusicApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<MusicDbContext>(config => config.UseNpgsql(builder.Configuration["MusicDB"]));
builder.Services.AddScoped<IItemService<Item>, ItemService>();
builder.Services.AddScoped<IRoomRentalService, RoomRentalService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IReviewService<Review>, ReviewService>();
builder.Services.AddScoped<ICustomerService<Customer>, CustomerService>();
builder.Services.AddScoped<IInventoryService<Inventory>, InventoryService>();
builder.Services.AddScoped<CartService>();

builder.Services.AddHttpClient();
//builder.Services.AddControllers().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddIdentity<IdentityUser, IdentityRole>
    (options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<MusicDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
