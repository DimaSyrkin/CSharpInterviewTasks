namespace ReverseBits
{
	public class UnsignedInt
	{
		const int Size = (sizeof(uint)) * 8 - 1;
		private readonly uint _inputNumber;

		public UnsignedInt(uint inputNumber)
		{
			_inputNumber = inputNumber;
		}

		public uint Reverse()
		{
			uint reversed = 0;
			uint number = _inputNumber;

			for (int i = Size; i >= 0; i--)
			{
				reversed <<= 1;
				reversed |= (number & 1);
				
				number >>= 1;
			}

			return reversed;
		}

		public uint ReverseNoLoop()
		{
			uint number = _inputNumber;

			number = ((number & 0x55555555) << 1) | ((number & 0xAAAAAAAA) >> 1);
			number = ((number & 0x33333333) << 2) | ((number & 0xCCCCCCCC) >> 2);
			number = ((number & 0x0F0F0F0F) << 4) | ((number & 0xF0F0F0F0) >> 4);
			number = ((number & 0x00FF00FF) << 8) | ((number & 0xFF00FF00) >> 8);
			number = ((number & 0x0000FFFF) << 16) | ((number & 0xFFFF0000) >> 16);
			return number;
		}		
	}
}
