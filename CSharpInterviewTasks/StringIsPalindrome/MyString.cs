using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringIsPalindrome
{
	public class MyString
	{
		private readonly StringBuilder _builder = new StringBuilder();

		public MyString(string input)
		{
			_builder.Clear();
			_builder.Append(input);
		}

		public bool IsPalindrome()
		{
			if (String.IsNullOrEmpty(_builder.ToString()))
			{
				throw new InvalidOperationException("Input string is null or empty.");
			}

			if (String.IsNullOrEmpty(_builder.ToString().Trim()))
			{
				throw new InvalidOperationException("Input string contains only spaces.");
			}

			return IsPalindromeCore();
		}

		private bool IsPalindromeCore()
		{
			int low = 0;
			int high = _builder.Length - 1;

			while (high > low)
			{
				if (_builder[high] == ' ')
				{
					high--;
					continue;
				}

				if (_builder[low] == ' ')
				{
					low++;
					continue;
				}

				if (_builder[low++] != _builder[high--])
				{
					return false;
				}
			}

			return true;
		}
	}
}
