using System;

namespace SetMsbToZero
{
	public class UnsignedInt
	{
		private readonly uint _inputNumber;

		public UnsignedInt(uint inputNumber)
		{
			_inputNumber = inputNumber;
		}

		public uint SetMsbToZero()
		{
			if ((_inputNumber & 0x80000000) == 0)
			{
				throw new InvalidOperationException("Most significant bit is already set to zero");
			}
			return _inputNumber & 0x7FFFFFFF;
		}
	}
}
