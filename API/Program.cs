using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Data.Repositories;
using AffiliateWODTracker.Services.Interfaces;
using AffiliateWODTracker.Services.Managers;
using AffiliateWODTracker.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>() // Add roles if you plan to use them
//    .AddEntityFrameworkStores<ApplicationDataContext>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDataContext>()
    .AddDefaultTokenProviders();

// Repositories
builder.Services.AddScoped<IAffiliateRepository, AffiliateRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

//Managers
builder.Services.AddScoped<IAffiliateManager, AffiliateManager>();
builder.Services.AddScoped<IMemberManager, MemberManager>();

//Services
builder.Services.AddAutoMapper(typeof(MappingService));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins(MobileConfig.HttpConfig.API) // Replace with your client's IP
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/Account/Login"));

app.Run();
