using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Interfaces
{
	public interface IDepartmentRepository
	{
		public void Add(Department department);

		public void Update(Department department);

		public void Delete(int Id);

		public List<Department> GetAll();

		public Department? GetById(int id);

		public void Save();
	}
}
