using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repositories.Implementations
{
	public class TraineeRepository : ITraineeRepository
	{
		AppDbContext _context;
		public TraineeRepository(AppDbContext context)
		{
			_context = context;
		}
		public void Add(Trainee trainee)
		{
			_context.Add(trainee);
		}

		public void Update(Trainee trainee)
		{
			_context.Update(trainee);
		}

		public void Delete(Trainee trainee)
		{
			_context?.Remove(trainee);
		}

		public List<Trainee> GetAll()
		{
			return _context.Trainee
				.Where(t => !t.IsDeleted)
				.ToList();
		}

		public Trainee? GetById(int id)
		{
			return _context.Trainee.FirstOrDefault(t => t.Id == id && !t.IsDeleted);
		}

		public List<Trainee> GetAllWithDepartments()
		{
			return _context.Trainee
				.Include(t => t.Department)
				.Where(t => !t.IsDeleted)
				.ToList();
		}
		public List<Trainee> SearchByNameWithDepartments(string search)
		{
			return _context.Trainee
				.Include(x => x.Department)
				.Where(x => x.Name!.Contains(search))
				.Where(t => !t.IsDeleted)
				.ToList();
		}
		public void Save()
		{
			_context.SaveChanges();
		}


		public CrsResult? GetTraineeCourseResult(int traineeId, int courseId)
		{
			return _context.CrsResult
				.Include(x => x.Trainee)
					.ThenInclude(x => x.Department)
				.Include(x => x.Course)
				.FirstOrDefault(cr => cr.TraineeId == traineeId 
				&& cr.CourseId == courseId
				&& !cr.Trainee.IsDeleted);
		}


		public List<CrsResult> GetAllResultsForTrainee(int traineeId)
		{
			return _context.CrsResult
				.Include(cr => cr.Trainee)
				.Include(cr => cr.Course)
				.Where(cr => cr.TraineeId == traineeId &&
					!cr.Trainee.IsDeleted)
				.ToList();
		}
	}
}
