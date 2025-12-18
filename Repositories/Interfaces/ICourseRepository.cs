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

		public List<Course> SearchByName(string name);
		public List<CrsResult> GetResultsByCourseId(int courseId);

		public List<Course> GetAllWithDepartments();

		public List<Course> SearchByNameWithDepartments(string name);
		
		public List<Course> GetCoursesByDepartmentId(int departmentId);
		public void Save();
	}
}
