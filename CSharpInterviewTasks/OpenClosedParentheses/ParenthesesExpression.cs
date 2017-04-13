using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedParentheses
{
	public class ParenthesesExpression
	{
		private char[] _expression;

		private readonly Dictionary<char, char> _bracketsPair = new Dictionary<char, char>()
		{
			{'{', '}'}, {'[', ']'}, {'(', ')'}, { ')', '('}, { ']', '[' }, { '}', '{' }
		};

		public ParenthesesExpression(ref char[] expression)
		{
			_expression = expression;
		}

		public char[] Expression 
		{ 

			get
			{
				return _expression;
			}

			private set {
				_expression = value;
			}
		}


		public List<int> GetUnbalancedIndexes()
		{
			Stack<char> stack = new Stack<char>();
			Dictionary<char, Stack<int>> positions = InitPositions();
			List<int> missingIndices = new List<int>();			

			for (int i = 0; i < _expression.Length; i++)
			{
				positions[_expression[i]].Push(i);
				if (IsOpenParenthesis(_expression[i]))
				{
					stack.Push(_expression[i]);
				}
				else
				{
					if (positions[_bracketsPair[_expression[i]]].Count == 0)
					{
						missingIndices.Add(i);
						positions[_expression[i]].Pop();
						continue;
					}

					while (stack.Count != 0)
					{
						if (IsMatchingParenthesis(stack.Peek(), _expression[i]))
						{
							positions[stack.Pop()].Pop();
							positions[_expression[i]].Pop();
							break;
						}
						missingIndices.Add(positions[stack.Pop()].Pop());
					}
				}
			}

			foreach (var bracket in positions.Keys)
			{
				while (positions[bracket].Count != 0)
				{
					missingIndices.Add(positions[bracket].Pop());
				}
			}

			if (missingIndices.Count > 1)
			{
				missingIndices.Sort();
			}

			return missingIndices;
		}

		public void BalanceExpression()
		{			
			while (true)
			{
				List<int> missingIndices = GetUnbalancedIndexes();
				if (missingIndices.Count == 0)
				{
					return;
				}

				int charIndex = missingIndices[0];
				if (IsOpenParenthesis(_expression[charIndex]))
				{
					_expression = BalanceRight(charIndex);
				}
				else
				{
					_expression = BalanceLeft(charIndex);
				}
			}
		}

		public char[] BalanceLeft(int charIndex)
		{
			List<char> expression = _expression.ToList();
			if (charIndex == 0)
			{
				expression.Insert(0, _bracketsPair[expression[charIndex]]);
				return expression.ToArray();
			}

			int closedParenthesisCount = 0;
			for (int j = charIndex - 1; j >= 0; j--)
			{
				if (!IsOpenParenthesis(expression[j]))
				{
					closedParenthesisCount++;
				}
				else
				{
					closedParenthesisCount--;
					if (closedParenthesisCount <= 0)
					{
						expression.Insert(j, _bracketsPair[expression[charIndex]]);
						return expression.ToArray();
					}
				}

				if (j == 0 && closedParenthesisCount >= 0)
				{
					expression.Insert(j, _bracketsPair[expression[charIndex]]);
					return expression.ToArray();
				}
			}
			throw new Exception("Unreachable code detected");
		}

		public char[] BalanceRight(int charIndex)
		{
			List<char> expression = _expression.ToList();
			if (charIndex == expression.Count - 1)
			{
				expression.Insert(expression.Count, _bracketsPair[expression[charIndex]]);
				return expression.ToArray();
			}

			int openParenthesisCount = 0;
			for (int j = charIndex + 1; j < expression.Count; j++)
			{
				if (IsOpenParenthesis(expression[j]))
				{
					openParenthesisCount++;
				}
				else
				{
					openParenthesisCount--;
					if (openParenthesisCount <= 0)
					{
						expression.Insert(j, _bracketsPair[expression[charIndex]]);
						return expression.ToArray();
					}
				}

				if ((j == expression.Count - 1 && openParenthesisCount >= 0))
				{
					expression.Insert(expression.Count, _bracketsPair[expression[charIndex]]);
					return expression.ToArray();
				}
			}
			throw new Exception("Unreachable code detected");
		}

		public static bool IsOpenParenthesis(char ch)
		{
			return ch == '(' || ch == '{' || ch == '[';
		}

		public static bool IsMatchingParenthesis(char left, char right)
		{
			return (
				(left == '{' && right == '}') || 
				(left == '[' && right == ']') || 
				(left == '(' && right == ')')
				);
		}

		public static Dictionary<char, Stack<int>> InitPositions()
		{
			return new Dictionary<char, Stack<int>>()
			{
				{'[', new Stack<int>() },
				{']', new Stack<int>() },
				{'}', new Stack<int>() },
				{'{', new Stack<int>() },
				{'(', new Stack<int>() },
				{')', new Stack<int>() },
			};
		}
	}
}
