using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenClosedParentheses
{
	[TestClass]
	public class ParenthesesExpressionTests
	{
		[TestMethod]
		public void BalanceExpression_Balanced_ReturnsSameExpression()
		{
			char[] array = new []{'{', '[', '(', ')', ']', '}' };

			ParenthesesExpression expression = new ParenthesesExpression(ref array);
			List<int> actualMissingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();

			Assert.AreEqual(0, actualMissingIndexes.Count);
			CollectionAssert.AreEqual(array, expression.Expression);			
		}

		[TestMethod]
		public void BalanceExpression_UnbalancedNestedMissingClosed_ReturnsBalancedExpression()
		{
			char[] array = new[] { '{', '[', '(', ')', '}' };
			char[] expectedExpression = new[] { '{', '[', '(', ')', ']', '}' };
			List<int> expectedMissingIndexes = new List<int>(new int[]{1});			

			ParenthesesExpression expression = new ParenthesesExpression(ref array);
			List<int> actualMissingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();
			
			CollectionAssert.AreEqual(expectedMissingIndexes, actualMissingIndexes);
			CollectionAssert.AreEqual(expectedExpression, expression.Expression);
		}

		[TestMethod]
		public void BalanceExpression_UnbalancedNestedMissingOpen_ReturnsBalancedExpression()
		{
			char[] array = new[] { '{', '(', ')', ']', '}' };
			char[] expectedExpression = new[] { '{', '[', '(', ')', ']', '}' };
			List<int> expectedMissingIndexes = new List<int>(new int[] { 3 });

			ParenthesesExpression expression = new ParenthesesExpression(ref array);
			List<int> actualMissingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();

			CollectionAssert.AreEqual(expectedMissingIndexes, actualMissingIndexes);
			CollectionAssert.AreEqual(expectedExpression, expression.Expression);
		}

		[TestMethod]
		public void BalanceExpression_UnbalancedNestedSeveralMissing_ReturnsBalancedExpression()
		{
			char[] array = new[] { '{', '(', ')', ']', '(', ']', '}' };
			char[] expectedExpression = new[] { '{', '[', '(', ')', ']', '[', '(', ')', ']', '}' };
			List<int> expectedMissingIndexes = new List<int>(new int[] { 3, 4, 5 });

			ParenthesesExpression expression = new ParenthesesExpression(ref array);
			List<int> actualMissingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();

			CollectionAssert.AreEqual(expectedMissingIndexes, actualMissingIndexes);
			CollectionAssert.AreEqual(expectedExpression, expression.Expression);
		}

		[TestMethod]
		public void BalanceExpression_UnbalancedOpenOnly_ReturnsBalancedExpression()
		{
			char[] array = new[] { '{', '(','(', '[' };
			char[] expectedExpression = new[] { '{', '(', '(', '[', ']', ')', ')', '}' };
			List<int> expectedMissingIndexes = new List<int>(new int[] { 0, 1, 2, 3 });

			ParenthesesExpression expression = new ParenthesesExpression(ref array);
			List<int> actualMissingIndexes = expression.GetUnbalancedIndexes();
			expression.BalanceExpression();

			CollectionAssert.AreEqual(expectedMissingIndexes, actualMissingIndexes);
			CollectionAssert.AreEqual(expectedExpression, expression.Expression);
		}
	}
}
