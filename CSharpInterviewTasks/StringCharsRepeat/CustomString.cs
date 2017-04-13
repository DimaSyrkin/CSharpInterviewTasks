using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCharsRepeat
{
	public class CustomString
	{
		private readonly string _inputCharacters;

		public CustomString(string inputCharacters)
		{
			_inputCharacters = inputCharacters;
		}

		public string Collapse()
		{
			if (_inputCharacters == null || _inputCharacters.Length == 0)
			{
				throw new InvalidOperationException("Input string is null or empty");
			}

			if (!IsLowerCase())
			{
				throw new InvalidOperationException("Input string contains invalid characters");
			}			

			StringBuilder result = new StringBuilder();
			int counter = 1;
			char currentChar = _inputCharacters[0];
			for (int i = 1; i < _inputCharacters.Length; i++)
			{
				if (_inputCharacters[i] == currentChar)
				{
					counter++;
				}
				else
				{
					result.Append(counter);
					result.Append(currentChar);
					counter = 1;
					currentChar = _inputCharacters[i];
				}
			}

			result.Append(counter);
			result.Append(currentChar);
			return result.ToString();
		}

		private bool IsLowerCase()
		{
			for (int i = 0; i < _inputCharacters.Length; i++)
			{
				if (_inputCharacters[i] < 'a' || _inputCharacters[i] > 'z')
				{
					return false;
				}
			}

			return true;
		}
	}
}
