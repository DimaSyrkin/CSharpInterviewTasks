using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanString
{
	public class MyString
	{
		private const int LETTERS_IN_ENGLISH = 26; // 'z' - 'a' + 1
		private const int LETTERS_IN_RUSSIAN = 32;
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
			
			if (Utilities.IsLatin(_builder[0]))
			{
				CleanLatin(strToRemove);
			}

			if (Utilities.IsCyrillic(_builder[0]))
			{
				CleanCyrillic(strToRemove);
			}
		}

		public void CleanLatin(string strToRemove)
		{
			bool[] lowerCaseHashSet = new bool[LETTERS_IN_ENGLISH];
			bool[] upperCaseHashSet = new bool[LETTERS_IN_ENGLISH];

			Utilities.CreateHashSetsLatin(strToRemove, ref lowerCaseHashSet, ref upperCaseHashSet);

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

		public void CleanCyrillic(string strToRemove)
		{
			bool[] lowerCaseHashSet = new bool[LETTERS_IN_RUSSIAN];
			bool[] upperCaseHashSet = new bool[LETTERS_IN_RUSSIAN];

			Utilities.CreateHashSetsCyrillic(strToRemove, ref lowerCaseHashSet, ref upperCaseHashSet);

			int i = 0;
			while (i < _builder.Length)
			{
				if ((_builder[i] >= 'а' && _builder[i] <= 'п' && lowerCaseHashSet[_builder[i] - 'а'])
					|| (_builder[i] >= 'р' && _builder[i] <= 'я' && lowerCaseHashSet[_builder[i] - 'р' + 'п' + 1])
					|| (_builder[i] >= 'А' && _builder[i] <= 'Я' && upperCaseHashSet[_builder[i] - 'А']))
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
