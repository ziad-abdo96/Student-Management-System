using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Interfaces
{
	public interface ICourseRepository
	{
		public void Add(Course course);

		public void Update(Course course);

		public void Delete(Course course);

		public List<Course> GetAll();	

		public Course? GetById(int id);

		List<CrsResult> GetResultsByCourseId(int courseId);

		public void Save();
	}
}
