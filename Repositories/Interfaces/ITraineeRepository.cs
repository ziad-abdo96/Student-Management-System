using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Interfaces
{
	public interface ITraineeRepository
	{
		public void Add(Trainee trainee);

		public void Update(Trainee trainee);

		public void Delete(Trainee trainee);

		public Trainee GetById(int id);

		public List<Trainee> GetAll();

		CrsResult? GetTraineeCourseResult(int traineeId, int courseId);

		List<CrsResult> GetAllResultsForTrainee(int traineeId);

		public void Save();
		public List<Trainee> GetAllWithDepartments();
		public List<Trainee> SearchByNameWithDepartments(string search);
	}
}
