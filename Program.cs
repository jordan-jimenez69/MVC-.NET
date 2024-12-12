using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var serverVersion = new MySqlServerVersion(new Version(11, 5, 2));
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
    );



builder.Services.AddIdentity<Teacher, IdentityRole>(options =>
{

    options.SignIn.RequireConfirmedAccount = false;
    options.Stores.MaxLengthForKeys = 128;
    options.Password.RequiredLength = 3;

}).AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Appel de la méthode d'initialisation des rôles
        await RoleInitializer.InitializeRoles(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de l'initialisation des rôles : {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
