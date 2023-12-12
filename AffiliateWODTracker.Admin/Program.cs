using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Data.Repositories;
using AffiliateWODTracker.Services.Interfaces;
using AffiliateWODTracker.Services.Managers;
using AffiliateWODTracker.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>() // Add roles if you plan to use them
//    .AddEntityFrameworkStores<ApplicationDataContext>();



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddRazorPages(); // This line registers Razor Pages services

// Add other services like your data context, repositories, etc.
builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Repositories
builder.Services.AddScoped<IAffiliateRepository, AffiliateRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

//Managers
builder.Services.AddScoped<IAffiliateManager, AffiliateManager>();
builder.Services.AddScoped<IMemberManager, MemberManager>();

//Services
builder.Services.AddAutoMapper(typeof(MappingService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
