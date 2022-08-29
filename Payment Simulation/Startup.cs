using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Payment_Simulation.Data;

namespace Payment_Simulation
{
    public class Startup
    {
      
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        public static void ConfigureServices(WebApplicationBuilder builder  )
        {

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TransactionsSimulation>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection") ?? throw new InvalidOperationException("Connection string 'DefaultDbConnection' not found.")));

            builder.Services.AddAutoMapper(typeof(Startup));

        }
        public static void Configure(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        }
    }
}
