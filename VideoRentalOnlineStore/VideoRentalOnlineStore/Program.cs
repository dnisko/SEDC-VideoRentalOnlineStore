using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Implementation;
using Services.Interfaces;

namespace VideoRentalOnlineStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString") ??
                                   throw new InvalidOperationException(
                                       "Connection string 'DefaultConnectionString' not found.");
            builder.Services.AddDbContext<MovieRentalAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MovieRentalAppDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddTransient<IMovieRepository, MovieRepository>();
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRentalRepository, RentalRepository>();
            builder.Services.AddTransient<IRentalService, RentalService>();
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

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
            ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                CreateRolesAndAdminUser(roleManager, userManager).Wait();
            }

            app.Run();
        }

        private static async Task CreateRolesAndAdminUser(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Check if the admin user exists and create it if it doesn't
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
