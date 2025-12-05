using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repositories.Implementations
{
	public class CourseRepository : ICourseRepository
	{
		AppDbContext _context;
		public CourseRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Course Course)
		{
			_context.Add(Course);
		}

		public void Update(Course Course)
		{
			_context.Update(Course);
		}

		public void Delete(Course course)
		{
			_context?.Remove(course);
		}

		public List<CrsResult> GetResultsByCourseId(int courseId)
		{
			List<CrsResult> results = _context.CrsResult
							.Include(x => x.Course)
							.Include(x => x.Trainee)
							.Where(x => x.CourseId == courseId)
							.ToList();

			return results;
		}

		public List<Course> GetAll()
		{
			return _context.Course.ToList();
		}

		public Course? GetById(int id)
		{
			return _context.Course.FirstOrDefault(d => d.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
