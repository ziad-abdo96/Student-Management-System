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

		public void Delete(int Id)
		{
			Employee? Employee = GetById(Id);
			if (Employee != null)
				_context?.Remove(Employee);
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
	}
}
