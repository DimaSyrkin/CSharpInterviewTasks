using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicographicalStrings
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] someStrings = new[] {"ab", "cvc", "", "fre"};
			StringArray array = new StringArray(ref someStrings);

			string[] minMaxStrings = array.GetMinMaxLength();
		}
	}
}
