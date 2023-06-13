using Library.Data;
using Library.Data.Entities;
using Library.Services;
using Microsoft.EntityFrameworkCore;
using static Library.Constants.ApplicationsUserConstants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = PasswordMinLength;
    })
    .AddEntityFrameworkStores<LibraryDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBooksService, BooksService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseMigrationsEndPoint();
}
else
{
    _ = app.UseExceptionHandler("/Home/Error");
    _ = app.UseHsts();
}

_ = app.UseHttpsRedirection();
_ = app.UseStaticFiles();

_ = app.UseRouting();

_ = app.UseAuthentication();
_ = app.UseAuthorization();

_ = app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

_ = app.MapRazorPages();

app.Run();
