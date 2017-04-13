using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicographicalStrings
{
	public class StringArray
	{
		const int MinStringLength = 1;
		const int MaxStringLength = 26;
		private readonly string[] _inputStrings;

		public StringArray(ref string[] inputStrings)
		{
			_inputStrings = inputStrings;
		}


		public string[] GetMinMaxLength()
		{
			Validate(MinStringLength, MaxStringLength);
			StringBuilder minStrings = new StringBuilder(_inputStrings[0]);
			StringBuilder maxStrings = new StringBuilder(_inputStrings[0]);
			int minLength = _inputStrings[0].Length;
			int maxLength = _inputStrings[0].Length;

			for (int i = 1; i < _inputStrings.Length; i++)
			{
				if (_inputStrings[i].Length < minLength)
				{
					minLength = _inputStrings[i].Length;
					minStrings.Clear();
					minStrings.Append(_inputStrings[i]);
					continue;
				}

				if (_inputStrings[i].Length > maxLength)
				{
					maxLength = _inputStrings[i].Length;
					maxStrings.Clear();
					maxStrings.Append(_inputStrings[i]);
					continue;
				}

				if (_inputStrings[i].Length == minLength)
				{
					minStrings.Append(_inputStrings[i]);
				}

				if (_inputStrings[i].Length == maxLength)
				{
					maxStrings.Append(_inputStrings[i]);
				}
			}

			string[] minMaxStrings =
			{
				FindMin(minStrings, minLength), FindMax(maxStrings, maxLength)
			};

			return minMaxStrings;
		}

		private string FindMin(StringBuilder builder, int length)
		{
			while (builder.Length > length)
			{
				if (Compare(builder, 0, length, length) == -1)
				{
					builder.Remove(length, length);
				}
				else
				{
					builder.Remove(0, length);
				}
			}
			return builder.ToString();
		}

		private string FindMax(StringBuilder builder, int length)
		{
			while (builder.Length > length)
			{
				if (Compare(builder, 0, length, length) == 1)
				{
					builder.Remove(length, length);
				}
				else
				{
					builder.Remove(0, length);
				}
			}
			return builder.ToString();
		}


		private static int Compare(StringBuilder builder, int firstIndex, int secondIndex, int length)
		{
			for (int i = firstIndex; i < firstIndex + length; i++)
			{
				if ((builder[i] - 'a') == (builder[secondIndex + i] - 'a'))
				{
					continue;
				}

				if ((builder[i] - 'a') < (builder[secondIndex + i] - 'a'))
				{
					return -1;
				}

				if ((builder[i] - 'a') > (builder[secondIndex + i] - 'a'))
				{
					return 1;
				}
			}

			return 0;
		}

		private void Validate(int minLength, int maxLength)
		{
			if (_inputStrings == null || _inputStrings.Length == 0)
			{
				throw new InvalidOperationException("List of strings is null empty");
			}

			if (_inputStrings.Length == 1)
			{
				throw new InvalidOperationException("List of strings contains only one item");
			}

			for (int i = 0; i < _inputStrings.Length; i++)
			{
				if (_inputStrings[i].Length < minLength || _inputStrings[i].Length > maxLength)
				{
					throw new InvalidOperationException("String size is invalid");
				}
			}
		}
	}
}
