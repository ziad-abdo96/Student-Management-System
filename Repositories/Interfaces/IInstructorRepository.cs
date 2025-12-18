using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Interfaces
{
	public interface IInstructorRepository 
	{
		public void Add(Instructor instructor);

		public void Update(Instructor instructor);

		public void Delete(Instructor instructor);

		public List<Instructor> GetAll();

		public Instructor? GetById(int id);

		public Instructor? GetByIdWithCourseAndDepartment(int id);

		public List<Instructor> GetAllWithCourseAndDepartment();
		public List<Instructor> SearchByNameContains(string name);
		public void Save();
	}
}
