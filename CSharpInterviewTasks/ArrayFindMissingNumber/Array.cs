using System;

namespace ArrayFindMissingNumber
{
	public static class Array
	{
		public enum FindStrategy
		{
			Sum,
			Xor
		}

		public static int[] Generate(int min, int max, int missingNumber)
		{
			if (missingNumber < min || missingNumber > max)
			{
				throw new ArgumentOutOfRangeException("missingNumber");
			}

			int[] result = new int[max - min];
			int index = 0;
			int current = min;

			while (current <= max)
			{
				if (current != missingNumber)
				{
					result[index++] = current;
				}
				current++;
			}

			Shuffle(result, result.Length);

			return result;
		}

		public static int FindMissingNumber(int[] range, FindStrategy strategy)
		{
			return strategy == FindStrategy.Sum
				? FindMissingNumberSum(range)
				: FindMissingNumberXor(range);
		}

		public static void Shuffle(int[] array, int swapsCount)
		{
			Random random = new Random();

			int counter = 0;

			while (counter < swapsCount)
			{
				int firstIndex = random.Next(0, array.Length);
				int secondIndex = random.Next(0, array.Length);

				if (firstIndex == secondIndex)
				{
					continue;
				}

				int temp = array[firstIndex];
				array[firstIndex] = array[secondIndex];
				array[secondIndex] = temp;

				counter++;
			}

		}

		private static int FindMissingNumberSum(int[] range)
		{
			int maxInRange = range.Length + 1;
			int total = (maxInRange * (maxInRange + 1)) / 2;
			for (int i = 0; i < range.Length; i++)
			{
				total -= range[i];
			}			
			return total;
		}
		
		private static int FindMissingNumberXor(int[] range)
		{
			int totalXor = range.Length + 1;
			for (int i = range.Length; i >= 1; i--)
			{
				totalXor ^= i;
			}

			int rangeXor = range[0];
			for (int i = 1; i < range.Length; i++)
			{
				rangeXor ^= range[i];
			}

			return rangeXor ^ totalXor;
		}
	}
}
