using System;

namespace GameData.ArchiveData;

public class ArchiveFileHeaderException : Exception
{
	public ArchiveFileHeaderException(string message)
		: base(message)
	{
	}

	public ArchiveFileHeaderException(ArchiveFileVersion expectedVer, ArchiveFileVersion actualVer)
		: base($"Corrupted/Obsolete header detected by file version. {expectedVer} expected, {actualVer} given.")
	{
	}

	public ArchiveFileHeaderException(ushort expectedMark, ushort actualMark)
		: base($"Corrupted/Obsolete header detected by incompatibility mark. {expectedMark} expected, {actualMark} given.")
	{
	}

	public ArchiveFileHeaderException(byte[] expectedTag, byte[] actualTag)
		: base("Corrupted header detected by file tag. " + string.Join(',', expectedTag) + " expected, " + string.Join(',', actualTag) + " given.")
	{
	}
}
