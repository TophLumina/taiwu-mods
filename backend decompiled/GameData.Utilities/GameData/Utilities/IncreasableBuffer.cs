namespace GameData.Utilities;

public class IncreasableBuffer
{
	private byte[] _buffer;

	private readonly int _initialSize;

	public IncreasableBuffer(int initialSize)
	{
		_buffer = new byte[initialSize];
		_initialSize = initialSize;
	}

	public byte[] Get(int minSize)
	{
		if (_buffer.Length >= minSize)
		{
			return _buffer;
		}
		int newSize = _buffer.Length * 2;
		if ((uint)newSize > 2147483647u)
		{
			newSize = int.MaxValue;
		}
		if (newSize < minSize)
		{
			newSize = minSize;
		}
		_buffer = new byte[newSize];
		return _buffer;
	}

	public void Shrink()
	{
		_buffer = new byte[_initialSize];
	}
}
