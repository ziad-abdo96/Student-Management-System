namespace FirstProject.Models
{
	public interface ISort
	{
		public void Sort(int[] arr);
	}

	public class Selection : ISort
	{
		public void Sort(int[] arr)
		{
			
		}
	}

	public class BubleSort : ISort
	{
		public void Sort(int[] arr)
		{

		}
	}

	public class Stack // hight level
	{
		BubleSort bubleSort; //low level 

		ISort sort;

		public Stack(ISort _sort) 
		{ 
			sort = _sort;
		}


	}

	public class testclass
	{
		public int Add(int x, int y)
		{
			return x + y;
		}
	
		public void display()
		{
			int a = 10;
			int b = 20;

			Add(a, b);
		}
	}


}
