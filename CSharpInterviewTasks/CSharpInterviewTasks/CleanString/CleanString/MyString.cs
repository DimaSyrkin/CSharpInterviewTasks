using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanString
{
	public class MyString
	{
		private const int LETTERS_IN_ENGLISH = 26; // 'z' - 'a' + 1
		private readonly StringBuilder _builder = new StringBuilder();

		public MyString(string s)
		{
			_builder.Clear();
			_builder.Append(s);
		}

		public void Clean(string strToRemove)
		{
			if (_builder.Length == 0)
			{
				throw new InvalidOperationException("Source string is null or empty");
			}

			if (strToRemove == null || strToRemove == "") // can I use String.IsNullOrEmpty(strToRemove)?
			{
				throw new ArgumentException("Cleaning string is null or empty");
			}

			bool[] lowerCaseHashSet = new bool[LETTERS_IN_ENGLISH];
			bool[] upperCaseHashSet = new bool[LETTERS_IN_ENGLISH];

			Utilities.CreateHashSets(strToRemove, ref lowerCaseHashSet, ref upperCaseHashSet);

			int i = 0;
			while (i < _builder.Length)
			{
				if ((_builder[i] >= 'a' && _builder[i] <= 'z' && lowerCaseHashSet[_builder[i] - 'a'])
					|| (_builder[i] >= 'A' && _builder[i] <= 'Z' && upperCaseHashSet[_builder[i] - 'A']))
				{
					_builder.Remove(i, 1);
					continue;
				}
				i++;
			}
		}

		internal string Print()
		{
			return _builder.ToString();
		}
	}
}
