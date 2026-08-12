using System.Runtime.InteropServices;
using GameData.Serializer;

namespace GameData.Utilities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct VoidValue : ISerializableGameData
{
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 0;
	}

	public unsafe int Serialize(byte* pData)
	{
		return 0;
	}

	public unsafe int Deserialize(byte* pData)
	{
		return 0;
	}
}
