using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Interfaces
{
	public interface IEmployeeRepository
	{
		public void Add(Employee Employee);

		public void Update(Employee Employee);

		public void Delete(Employee employee);

		public List<Employee> GetAll();

		public Employee? GetById(int id);

		public Employee? GetByIdWithDepartment(int id);

		public List<Employee> GetAllWithDepartments();

		public List<Employee> SearchByNameWithDepartments(string name);
		public void Save();
	}
}
