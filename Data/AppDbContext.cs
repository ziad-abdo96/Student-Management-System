using FirstProject.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{

		public DbSet<Department> Department { get; set; }

		public DbSet<Course> Course { get; set; }
		
		public DbSet<Instructor> Instructor { get; set; }
		
		public DbSet<Trainee> Trainee { get; set; }
		
		public DbSet<CrsResult> CrsResult { get; set; }

		public DbSet<Employee> Employee { get; set; }

		//	public DbSet<Student> Student { get; set; }

		//public AppDbContext() : base()
		//{

		//}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// This is where global query filters belong
			modelBuilder.Entity<Trainee>()
				.HasQueryFilter(t => !t.IsDeleted);
			modelBuilder.Entity<Department>()
				.HasQueryFilter(d => !d.IsDeleted);

			base.OnModelCreating(modelBuilder);
		}
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	base.OnConfiguring(optionsBuilder);

		//	IConfigurationRoot config = new ConfigurationBuilder()
		//		.AddJsonFile("appsettings.json")
		//		.Build();

		//	string connectionString = config.GetSection("ConnectionStrings").Value;



		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FristProject;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
		//}

	}
}
