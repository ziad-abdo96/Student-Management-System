using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;

namespace FirstProject.Repositories.Implementations
{
	public class DepartmentRepository : IDepartmentRepository
	{
		AppDbContext _context;
		public DepartmentRepository(AppDbContext context)
		{
			_context = context;
		}
		public void Add(Department department)
		{
			_context.Add(department);
		}

		public void Update(Department department)
		{
			_context.Update(department);
		}

		public void Delete(int Id)
		{
			Department? department = GetById(Id);
			if (department != null) 
				_context?.Remove(department);
		}

		public List<Department> GetAll()
		{
			return _context.Department.ToList();
		}

		public Department? GetById(int id)
		{
			return _context.Department.FirstOrDefault(d => d.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
