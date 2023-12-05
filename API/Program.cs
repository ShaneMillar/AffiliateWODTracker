using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Data.Repositories;
using AffiliateWODTracker.Services.Interfaces;
using AffiliateWODTracker.Services.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDataContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>() // Add roles if you plan to use them
//    .AddEntityFrameworkStores<ApplicationDataContext>();


builder.Services.AddIdentity<OwnerEntity, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDataContext>()
    .AddDefaultTokenProviders();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAffiliateRepository, AffiliateRepository>();


//Managers
builder.Services.AddScoped<IAffiliateManager, AffiliateManager>();

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

app.MapGet("/", () => Results.Redirect("/Account/Login"));

app.Run();
