using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Implementations;
using FirstProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSession();//layer for session


			// Built in serviec "register"
			builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
			{
				option.Password.RequiredLength = 4;
				option.Password.RequireDigit = false;
				option.Password.RequireUppercase = false;
			}).AddEntityFrameworkStores<AppDbContext>();

			//Custom Services "register"
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<ICourseRepository, CourseRepository>();
			builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
			builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();

			var app = builder.Build();



			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseSession();

			app.UseRouting(); //Guid

			app.UseAuthentication();

			app.UseAuthorization();

			//Declare & execute
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
