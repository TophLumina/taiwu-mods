using System;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace GameData.ArchiveData;

public static class CompressionStreamFactory
{
	public static Stream StartCompression(Stream stream, CompressionAlgorithm algorithm, CompressionType compressionType)
	{
		if (algorithm == CompressionAlgorithm.Deflate)
		{
			return new DeflateStream(stream, compressionType switch
			{
				CompressionType.NoCompression => CompressionLevel.NoCompression, 
				CompressionType.PrioritizeSpeed => CompressionLevel.Fastest, 
				CompressionType.PrioritizeSize => CompressionLevel.Optimal, 
				_ => throw new ArgumentOutOfRangeException("compressionType", compressionType, "Unknown compression type."), 
			}, leaveOpen: true);
		}
		return stream;
	}

	public static void EndCompression(Stream stream)
	{
		if (!(stream is FileStream))
		{
			stream.Dispose();
		}
	}

	public static Stream StartDecompression(Stream stream, CompressionAlgorithm algorithm)
	{
		if (algorithm == CompressionAlgorithm.Deflate)
		{
			Inflater inflater = new Inflater(noHeader: true);
			return new InflaterInputStream(stream, inflater)
			{
				IsStreamOwner = false
			};
		}
		return stream;
	}

	public static void EndDecompression(Stream stream, CompressionAlgorithm algorithm)
	{
		if (algorithm != CompressionAlgorithm.Raw)
		{
			stream.Dispose();
		}
	}
}
