using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCharsRepeat
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = "aaabzzzaafff";
			CustomString strToCollapse = new CustomString(input);
			string output = strToCollapse.Collapse();
			Console.WriteLine(output);
		}
	}
}
