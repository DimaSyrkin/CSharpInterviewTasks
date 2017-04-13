using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiKanjiBackspace
{
	class Program
	{
		static void Main(string[] args)
		{
			byte ascii = 0x41;
			byte kanjiHead = 0xB0;
			byte kanjiTail = 0xB1;
			byte kanjiTailZero = 0x30;

			byte[] charArray = { ascii, kanjiHead, kanjiTailZero, kanjiHead, kanjiTailZero, kanjiHead, kanjiTail, ascii, ascii, ascii };

			AsciiKanjiString str = new AsciiKanjiString(ref charArray);
			str.Backspace(8);
		}
	}
}
