using System;

namespace AsciiKanjiBackspace
{
	public class AsciiKanjiString
	{
		private readonly byte[] _bytes;

		public enum ByteCharTypes
		{
			Ascii,
			KanjiHead,
			KanjiTail
		};

		public enum BackspaceShifts
		{
			Ascii = 1,			
			Kanji = 2
		};

		public AsciiKanjiString(ref byte[] bytes)
		{
			_bytes = bytes;
		}

		public void Backspace(int inputIndex)
		{
			int index = inputIndex - 1;
			if (!IsValid())
			{
				throw new InvalidOperationException("String is not valid");
			}

			if (index < 0 || index >= _bytes.Length)
			{
				throw new IndexOutOfRangeException("String index is out of range");
			}

			if (index == 0 || (index == 1 && GetMsb(0) == 1))
			{
				throw new InvalidOperationException("Unable to perform backspace for the first symbol");
			}

			BackspaceCore(index);
		}

		private void BackspaceCore(int index)
		{
			if (index == 1 && GetMsb(index - 1) == 0)
			{
				PerformBackspace(index, BackspaceShifts.Ascii);
				return;
			}

			if (GetMsb(index - 1) == 0 && GetMsb(index - 2) == 0)
			{
				PerformBackspace(index, BackspaceShifts.Ascii);
				return;
			}

			BackspaceWithPreviousCharByteCheck(index);
		}

		private void BackspaceWithPreviousCharByteCheck(int index)
		{			
			ByteCharTypes previousCharByteType = GetPreviousCharByteType(index);
			if (previousCharByteType == ByteCharTypes.Ascii)
			{
				PerformBackspace(index - 1, BackspaceShifts.Ascii);
				return;
			}

			if (previousCharByteType == ByteCharTypes.KanjiHead)
			{
				PerformBackspace(index, BackspaceShifts.Kanji);
				return;
			}

			if (previousCharByteType == ByteCharTypes.KanjiTail)
			{
				if (GetMsb(index - 1) == 1)
				{
					PerformBackspace(index - 1, BackspaceShifts.Kanji);
					return;
				}
				if (GetMsb(index - 1) == 0)
				{
					PerformBackspace(index, BackspaceShifts.Ascii);
					return;
				}
			}
		}

		private ByteCharTypes GetPreviousCharByteType(int index)
		{
			int indexToFind = index - 2;

			int counter = indexToFind;

			while (true)
			{
				if (counter <= 0)
				{
					return GetLastByteCharType(0, indexToFind);
				}

				if ((GetMsb(counter) == 0 && GetMsb(counter - 1) == 0) ||
					(GetMsb(counter) == 1 && GetMsb(counter - 1) == 0 && GetMsb(counter + 1) == 0))
				{
					return GetLastByteCharType(counter, indexToFind);
				}

				if (GetMsb(counter) == 0)
				{
					counter--;
					continue;
				}
				if (GetMsb(counter) == 1)
					counter-=2;
			}
		}

		private void PerformBackspace(int index, BackspaceShifts shift)
		{			
			for (int i = index; i < _bytes.Length; i++)
			{
				_bytes[i - (int)shift] = _bytes[i];
			}

			// Terminate string here. There's no null-terminator in C#, so I've set each byte to 0.
			for (int i = _bytes.Length - (int)shift; i < _bytes.Length; i++)
			{
				_bytes[i] = 0;
			}
		}
		
		private int GetMsb(int index)
		{
			return _bytes[index] >> 7;
		}

		private bool IsValid()
		{
			if (_bytes.Length <= 1)
			{
				return false;
			}

			int index = 0;
			while (true)
			{
				if (index > _bytes.Length)
					return false;
				if (index == _bytes.Length)
					return true;
				if (GetMsb(index) == 0)
				{
					index++;
					continue;
				}
				if (GetMsb(index) == 1)
				{
					index += 2;					
				}
			}
		}

		private ByteCharTypes GetLastByteCharType(int startIndex, int endIndex)
		{
			int index = startIndex;
			while (true)
			{
				if (index > endIndex)
					return ByteCharTypes.KanjiTail;
				if (index == endIndex && GetMsb(index) == 0)
					return ByteCharTypes.Ascii;
				if (index == endIndex && GetMsb(index) == 1)
					return ByteCharTypes.KanjiHead;

				if (GetMsb(index) == 0)
				{
					index++;
					continue;
				}
				if (GetMsb(index) == 1)
					index += 2;
			}
		}
	}
}
