using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowerCaseToUpperCase
{
	public class MyString
	{
		private readonly StringBuilder _builder = new StringBuilder();

		public MyString(string s)
		{
			_builder.Clear();
			_builder.Append(s);
		}

		public string ToUpper()
		{
			if (_builder.Length == 0)
			{
				throw new InvalidOperationException("Source string is null or empty");
			}

			for (int i = 0; i < _builder.Length; i++)
			{
				if ((_builder[i] >= 'А') && (_builder[i] <= 'Я'))
					continue;
				
				if ((_builder[i] >= 'а') && (_builder[i] <= 'п'))
				{
					int mask = 0xFDF;
					int upperCode = Convert.ToInt32(_builder[i]) & mask;
					_builder[i] = (char) upperCode;
				}

				if ((_builder[i] >= 'р') && (_builder[i] <= 'я'))
				{
					int mask1 = 0x20;
					int mask2 = 0xFBF;
					int upperCode = (Convert.ToInt32(_builder[i]) | mask1) & mask2;
					_builder[i] = (char) upperCode;
				}
			}

			return _builder.ToString();
		}
	}
}
