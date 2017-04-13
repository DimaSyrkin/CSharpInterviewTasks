using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedParentheses
{
	class Program
	{
		static void Main(string[] args)
		{
			//char[] exp = new[] {'[', ']', '}', '{', '}', '{', '}', ']'};
			//char[] exp = new[] { ']', '{', '[', '[', '}', ']' };
			char[] exp = new[] { '[', '{', ']', '{', ']', '}', '[', '['};
			char[] expOpen = new[] { '[', '(' };

			ParenthesesExpression expression = new ParenthesesExpression(ref expOpen);
			var missingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();
			//Console.WriteLine(expression.IsBalanced());
		}
	}
}
