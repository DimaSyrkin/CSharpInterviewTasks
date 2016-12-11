using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanString
{
	public static class Utilities
	{
		public static void CreateHashSets(string strToRemove, ref bool[] lowerCaseHashSet, ref bool[] upperCaseHashSet)
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
	}
}
