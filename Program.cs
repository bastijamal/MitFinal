using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SondanaSon.DAL;
using SondanaSon.Models;

namespace SondanaSon;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        ///Identity ile bagli olan elaveler
        builder.Services.AddIdentity<User, IdentityRole>(opt=>{
            opt.Password.RequiredLength = 5;

        }).AddEntityFrameworkStores<AppDbContext>(); //bunun uchun yaziram demekdir




        ///
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });

        var app = builder.Build();


        app.UseStaticFiles();

        app.UseRouting();

        // benzer shey yazram ba!
        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
