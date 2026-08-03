using System;

namespace GameData.ArchiveData;

public class SerializedSizeMismatchException : Exception
{
	public SerializedSizeMismatchException(int expectedSize, int actualSize)
		: base($"Expected size of {expectedSize} but got {actualSize}")
	{
	}
}
