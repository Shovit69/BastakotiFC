using ShovitBastakoti.Models;
using Microsoft.EntityFrameworkCore;
using ShovitBastakoti.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BastakotiFCContext>(options =>
   options.UseSqlServer("Server=tcp:shovit.database.windows.net,1433;Initial Catalog=BastakotiFC;Persist Security Info=False;User ID=admin69;Password=Messidona69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                   "Server=tcp:shovit.database.windows.net,1433;Initial Catalog=BastakotiFC;Persist Security Info=False;User ID=admin69;Password=Messidona69@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddDefaultIdentity<IdentityUser>(
               options =>
               {
                   options.SignIn.RequireConfirmedAccount = true;
                   options.Password.RequiredLength = 6;
                   options.Password.RequireLowercase = true;
                   options.Password.RequireUppercase = true;
               }
               )
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<BastakotiFCContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
