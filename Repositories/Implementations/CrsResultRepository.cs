using FirstProject.Data;
using FirstProject.Models.Entities;

namespace FirstProject.Repositories.Implementations
{
	public class CrsResultRepository
	{
		AppDbContext _context;
		public CrsResultRepository(AppDbContext context)
		{
			_context = context;
		}
		public void Create(CrsResult CrsResult)
		{
			_context.Add(CrsResult);
		}

		public void Update(CrsResult CrsResult)
		{
			_context.Update(CrsResult);
		}

		public void Delete(int Id)
		{
			CrsResult? CrsResult = GetById(Id);
			if (CrsResult != null)
				_context?.Remove(CrsResult);
		}

		public List<CrsResult> GetAll()
		{
			return _context.CrsResult.ToList();
		}

		public CrsResult? GetById(int id)
		{
			return _context.CrsResult.FirstOrDefault(d => d.Id == id);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
