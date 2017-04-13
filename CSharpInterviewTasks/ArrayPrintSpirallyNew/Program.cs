namespace ArrayPrintSpirallyNew
{
	class Program
	{		
		static void Main(string[] args)
		{
			int[,] arr = {
						 {1,2,3},
						 {4,5,6},
						 {7,8,9},
						 {10,11,12}
						 };

			int[,] arr2 = {
						 {1,2,3,4,5},
						 {6,7,8,9,10},						 
						 {11,12,13,14,15},
						 {11,12,13,14,15},
						 {11,12,13,14,15},
						 {11,12,13,14,15},
						 {11,12,13,14,15},
						 {11,12,13,14,15}
						 };

			Array2D array2D = new Array2D(ref arr2, 5, 8);			
			array2D.PrintSpirally();
		}
	}
}
