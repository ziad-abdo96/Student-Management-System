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
			return _context.Trainee.ToList();
		}

		public Trainee? GetById(int id)
		{
			return _context.Trainee.FirstOrDefault(d => d.Id == id);
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
				.FirstOrDefault(x => x.TraineeId == traineeId && x.CourseId == courseId);
		}


		public List<CrsResult> GetAllResultsForTrainee(int traineeId)
		{
			return _context.CrsResult
				.Include(x => x.Trainee)
				.Include(x => x.Course)
				.Where(x => x.TraineeId == traineeId)
				.ToList();
		}
	}
}
