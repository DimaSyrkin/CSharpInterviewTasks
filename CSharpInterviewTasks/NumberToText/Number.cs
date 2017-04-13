using System;
using System.Text;

namespace NumberToText
{
	public class Number
	{
		private const int MAX_ONE_DIGIT = 9;		
		private const int MAX_TWO_DIGITS = 99;
		private const int MAX_ENDS_WITH_TEEN = 19;
		
		private static readonly string[] Ones =
		{
			"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
		};

		private static readonly string[] Tens =
		{
			"ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
		};

		private static readonly string[] ElevenToNineteen =
		{
			"eleven", "twelve", "thirteen", "fortteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
		};

		private static readonly string[] TenPowers =
		{
			" hundred ", " thousand ", " million ", " billion "
		};

		public static string ConvertToText(int inputNumber)
		{
			if (inputNumber < 0)
			{
				throw new ArgumentException("Input number is less than zero");
			}

			if (inputNumber == 0)
			{
				return "zero";
			}

			if (inputNumber < 100)
			{
				return Convert0To99ToTextBase(inputNumber);
			}

			return ConvertToTextBase(inputNumber);
		}

		private static string ConvertToTextBase(int inputNumber)
		{
			int tripleDivider = 1000;
			StringBuilder builder = new StringBuilder();
			int tenPowersCounter = 0;
			while (inputNumber != 0)
			{
				builder.Insert(0, ConvertTripleToText(inputNumber % tripleDivider, TenPowers[tenPowersCounter++]));
				inputNumber = inputNumber / tripleDivider;
			}

			Trim(builder);
			return builder.ToString();
		}

		private static string ConvertTripleToText(int number, string tenPower)
		{
			StringBuilder builder = new StringBuilder();
			int hundreds = number / 100;
			int remainder = number%100;
			
			if (hundreds > 0 && remainder == 0)
			{
				AppendHundreds(builder, hundreds);
				Trim(builder);
				AppendTenPower(builder, tenPower);				
			}

			if (hundreds > 0 && remainder != 0)
			{
				AppendHundreds(builder, hundreds);
				Append0To99(builder, remainder);
				AppendTenPower(builder, tenPower);
			}

			if (hundreds == 0 && remainder != 0)
			{
				Append0To99(builder, remainder);
				AppendTenPower(builder, tenPower);
			}

			return builder.ToString();
		}

		private static void AppendHundreds(StringBuilder builder, int hundredsCount)
		{
			builder.Append(Convert0To99ToTextBase(hundredsCount));
			builder.Append(TenPowers[0]);
		}

		private static void AppendTenPower(StringBuilder builder, string tenPower)
		{
			if (tenPower != TenPowers[0])
			{
				builder.Append(tenPower);
			}
		}

		private static void Append0To99(StringBuilder builder, int number)
		{
			builder.Append(Convert0To99ToTextBase(number));
		}
		
		private static string Convert0To99ToTextBase(int inputNumber)
		{
			if (inputNumber <= MAX_ONE_DIGIT)
			{
				return Convert0To9ToText(inputNumber);
			}

			if (inputNumber <= MAX_TWO_DIGITS)
			{
				return Convert10To99ToTextBase(inputNumber);
			}
			
			throw new ArgumentException("Unreachable code detected. Input number is invalid");
		}

		private static string Convert10To99ToTextBase(int inputNumber)
		{
			int tensCount = inputNumber/10;
			int onesCount = inputNumber%10;
			if (onesCount == 0)
			{
				return Tens[tensCount - 1];
			}

			if (inputNumber <= MAX_ENDS_WITH_TEEN)
			{
				return ElevenToNineteen[onesCount - 1];
			}

			return Tens[tensCount - 1] + " " + Convert0To9ToText(onesCount);
		}

		private static string Convert0To9ToText(int inputNumber)
		{
			if (inputNumber == 0)
			{
				return "";
			}

			return Ones[inputNumber - 1];
		}

		private static void Trim(StringBuilder builder)
		{
			while (builder[builder.Length - 1] == ' ')
			{
				builder.Remove(builder.Length - 1, 1);
			}
		}
	}
}
