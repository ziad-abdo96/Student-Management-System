using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repositories.Implementations
{
	public class InstructorRepository : IInstructorRepository
	{
		AppDbContext _context;
		public InstructorRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Instructor Instructor)
		{
			_context.Add(Instructor);
		}

		public void Update(Instructor Instructor)
		{
			_context.Update(Instructor);
		}

		public void Delete(Instructor instructor)
		{
			_context?.Remove(instructor);
		}

		public Instructor? GetByIdWithCourseAndDepartment(int id)
		{
			return _context.Instructor
				.Include(x => x.Course)
				.Include(x => x.Department)
				.FirstOrDefault(i => i.Id == id);
		}

		public List<Instructor> GetAll()
		{
			return _context.Instructor.ToList();
		}

		public Instructor? GetById(int id)
		{
			return _context.Instructor.FirstOrDefault(d => d.Id == id);
		}

		public List<Instructor> SearchByNameContains(string name)
		{
			return _context.Instructor
				.Where(x => x.Name.Contains(name))
				.ToList();
		}


		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
