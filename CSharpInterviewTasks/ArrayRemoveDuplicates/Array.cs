using System;

namespace ArrayRemoveDuplicates
{
	public class Array
	{
		public int[] InputElements;

		public enum RemoveDuplicatesStrategy
		{
			ResizeArray,
			FillMaxInt,
			ConsoleOutput
		}

		public Array(ref int[] inputElements)
		{
			InputElements = inputElements;
		}

		public void RemoveDuplicates(RemoveDuplicatesStrategy removeDuplicatesStrategy)
		{
			if (InputElements == null || InputElements.Length == 0)
			{
				throw new InvalidOperationException("Input array is null or empty");
			}

			if (!IsSorted())
			{
				throw new InvalidOperationException("Input array is unsorted");
			}

			if (removeDuplicatesStrategy == RemoveDuplicatesStrategy.ConsoleOutput)
			{
				PrintUniqueElements();
				return;
			}

			if (InputElements.Length == 1)
			{
				return;
			}

			RemoveDuplicatesCore(removeDuplicatesStrategy);
		}

		private void RemoveDuplicatesCore(RemoveDuplicatesStrategy removeDuplicatesStrategy)
		{
			int duplicatesCount = 0;

			int i = 0;
			int j = 1;			
			while (j < InputElements.Length)
			{
				if (InputElements[i] == InputElements[j])
				{
					j++;
					duplicatesCount++;
				}
				else
				{
					i++;
					InputElements[i] = InputElements[j];					
					j++;
				}
			}

			if (duplicatesCount > 0)
			{
				RemoveLastElements(removeDuplicatesStrategy, duplicatesCount);
			}
		}

		private void PrintUniqueElements()
		{
			int i = 0;
			Console.Write(InputElements[0]);
			if (InputElements.Length == 1)
			{
				return;
			}

			int j = 1;
			while (j < InputElements.Length)
			{
				if (InputElements[i] == InputElements[j])
				{
					j++;					
				}
				else
				{
					i++;					
					InputElements[i] = InputElements[j];
					Console.Write(", {0}", InputElements[i]);
					j++;
				}
			}
			Console.WriteLine();
		}

		private bool IsSorted()
		{
			for (int i = 1; i < InputElements.Length; i++)
			{
				if (InputElements[i] < InputElements[i - 1])
				{
					return false;
				}
			}
			return true;
		}

		private void RemoveLastElements(RemoveDuplicatesStrategy strategy, int count)
		{
			if (strategy == RemoveDuplicatesStrategy.ResizeArray)
			{
				System.Array.Resize(ref InputElements, InputElements.Length - count);
			}

			if (strategy == RemoveDuplicatesStrategy.FillMaxInt)
			{
				for (int i = InputElements.Length - count; i < InputElements.Length; i++)
				{
					InputElements[i] = Int32.MaxValue;
				}
			}
		}
	}
}
