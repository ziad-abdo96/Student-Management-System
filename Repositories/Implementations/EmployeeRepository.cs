using FirstProject.Data;
using FirstProject.Models.Entities;
using FirstProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Repositories.Implementations
{
	public class EmployeeRepository : IEmployeeRepository 
	{
		AppDbContext _context;
		public EmployeeRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(Employee Employee)
		{
			_context.Add(Employee);
		}

		public void Update(Employee Employee)
		{
			_context.Update(Employee);
		}

		public void Delete(Employee employee)
		{
			_context?.Remove(employee);
		}

		public List<Employee> GetAll()
		{
			return _context.Employee.ToList();
		}

		public Employee? GetById(int id)
		{
			return _context.Employee.FirstOrDefault(d => d.Id == id);
		}

		public Employee? GetByIdWithDepartment(int id)
		{
			return _context.Employee
					.Include(e => e.Department)
					.FirstOrDefault(e => e.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public List<Employee> GetAllWithDepartments()
		{
			return _context.Employee
					.Include(e => e.Department)
					.ToList();
		}

		public List<Employee> SearchByNameWithDepartments(string name)
		{
			return _context.Employee
					.Include(e => e.Department)
					.Where(e => e.Name.Contains(name))
					.ToList();
		}
	}
}
