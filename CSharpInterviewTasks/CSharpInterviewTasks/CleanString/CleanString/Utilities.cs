namespace CleanString
{
	public static class Utilities
	{
		public static void CreateHashSetsLatin(string strToRemove, ref bool[] lowerCaseHashSet, ref bool[] upperCaseHashSet)
		{
			foreach (char ch in strToRemove)
			{
				if (ch >= 'a' && ch <= 'z' && !lowerCaseHashSet[ch - 'a'])
				{
					lowerCaseHashSet[ch - 'a'] = true;
				}
				else if (ch >= 'A' && ch <= 'Z' && !upperCaseHashSet[ch - 'A'])
				{
					upperCaseHashSet[ch - 'A'] = true;
				}
			}
		}

		public static void CreateHashSetsCyrillic(string strToRemove, ref bool[] lowerCaseHashSet, ref bool[] upperCaseHashSet)
		{
			foreach (char ch in strToRemove)
			{
				if (ch >= 'а' && ch <= 'п' && !lowerCaseHashSet[ch - 'a'])
				{
					lowerCaseHashSet[ch - 'a'] = true;
				}
				else if ((ch >= 'р' && ch <= 'я') && !lowerCaseHashSet[ch - 'р' + 'п' + 1])
				{
					lowerCaseHashSet[ch - 'р' + 'п' + 1] = true;
				}
				else if (ch >= 'А' && ch <= 'Я' && !upperCaseHashSet[ch - 'А'])
				{
					upperCaseHashSet[ch - 'A'] = true;
				}
			}
		}

		public static bool IsCyrillic(char ch)
		{			
			return ((ch >= 'А' && ch <= 'Я') || (ch >= 'а' && ch <= 'п') || (ch >= 'р' && ch <= 'я'));
		}

		public static bool IsLatin(char ch)
		{			
			return ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'));
		}
	}
}
