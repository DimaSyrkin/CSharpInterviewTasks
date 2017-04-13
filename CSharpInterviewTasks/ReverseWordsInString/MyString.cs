using System;
using System.Text;

namespace ReverseWordsInString
{
	public class MyString
	{
		private readonly StringBuilder _builder = new StringBuilder();

		public MyString(string s)
		{
			_builder.Clear();
			_builder.Append(s);
		}

		public void ReverseWords()
		{
			if (_builder.Length == 0)
			{
				throw new InvalidOperationException("Input string is null or empty.");
			}

			if (_builder.Length == 1)
			{
				return;
			}

			int i = 0;
			int wordStart = -1;

			while (i < _builder.Length)
			{
				if (!IsValidChar(_builder[i]))
				{
					throw new ArgumentException("Input string contains invalid character(s).");
				}

				if ((wordStart == -1) && (_builder[i] != ' '))
				{
					wordStart = i;
				}

				if (wordStart >= 0 && ((i == _builder.Length - 1) || (_builder[i + 1] == ' ')))
				{
					Reverse(wordStart, i);
					wordStart = -1;
				}

				i++;
			}

			Reverse(0, i - 1);
		}

		private void Reverse(int startIndex, int endIndex)
		{
			while (startIndex < endIndex)
			{
				if (_builder[startIndex] != _builder[endIndex])
				{
					char temp = _builder[startIndex];
					_builder[startIndex] = _builder[endIndex];
					_builder[endIndex] = temp;
				}
				startIndex++;
				endIndex--;
			}
		}

		private bool IsValidChar(char ch)
		{
			return ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
			       || (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я')
			       || (ch == ' '));
		}

		internal string Print()
		{
			return _builder.ToString();
		}

	}
}
