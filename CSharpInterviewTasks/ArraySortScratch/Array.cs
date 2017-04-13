using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySortScratch
{
	public class Array
	{
		public int[] InputElements;

		public Array(ref int[] inputElements)
		{
			InputElements = inputElements;			
		}

		public void Sort(int scratchSize)
		{
			if (InputElements == null || InputElements.Length == 0)
			{
				throw new InvalidOperationException("Input array is null or empty");
			}

			if (scratchSize < 0)
			{
				throw new ArgumentException("Scratch array size is invalid");
			}

			if (scratchSize == 0)
			{
				throw new ArgumentException("Scratch array is empty");
			}

			if (!IsInRange(1, scratchSize))
			{
				throw new InvalidOperationException("Input array contains invalid numbers");
			}

			if (InputElements.Length == 1 || scratchSize == 1)
			{
				return;
			}

			SortWithScratch(scratchSize);
		}

		private void SortWithScratch(int scratchSize)
		{
			int[] scratch = new int[scratchSize];		

			if (scratchSize == InputElements.Length)
			{
				SortScratchEqual(ref scratch);
			}

			if (scratchSize < InputElements.Length)
			{
				SortScratchLess(ref scratch);
			}

			if (scratchSize > InputElements.Length)
			{
				SortScratchGreater(ref scratch);
			}
		}

		private void SortScratchEqual(ref int[] scratch)
		{
			for (int i = 0; i < InputElements.Length; i++)
			{
				scratch[InputElements[i] - 1] = InputElements[i];
			}

			InputElements = scratch;

		}

		private void SortScratchLess(ref int[] scratch)
		{
			for (int i = 0; i < InputElements.Length; i++)
			{
				scratch[InputElements[i] - 1]++;
			}

			int index = 0;
			for (int i = 0; i < scratch.Length; i++)
			{
				for (int j = 0; j < scratch[i]; j++)
				{
					InputElements[index++] = i + 1;
				}
			}
		}

		private void SortScratchGreater(ref int[] scratch)
		{
			System.Array.Resize(ref scratch, InputElements.Length);
			scratch = InputElements;
			QuickSort(ref scratch);
			InputElements = scratch;
		}

		private bool IsInRange(int low, int high)
		{
			for (int i = 0; i < InputElements.Length; i++)
			{
				if (InputElements[i] < low || InputElements[i] > high)
				{
					return false;
				}
			}
			return true;
		}

		public static void QuickSort(ref int[] array)
		{
			QuickSort(ref array, 0, array.Length - 1);
		}

		public static void QuickSort(ref int[] array, int low, int high)
		{
			if (low >= high)
			{
				return;
			}

			int pivot = array[((high - low)/2) + low];
			int left = low;
			int right = high;

			while (left <= right)
			{
				while (array[left] < pivot)
				{
					left++;
				}

				while (array[right] > pivot)
				{
					right--;
				}

				if (left <= right)
				{
					int temp = array[left];
					array[left] = array[right];
					array[right] = temp;
					left++;
					right--;
				}

				if (low < right)
				{
					QuickSort(ref array, low, right);
				}

				if (high > left)
				{
					QuickSort(ref array, left, high);
				}
			}
		}
	}
}
