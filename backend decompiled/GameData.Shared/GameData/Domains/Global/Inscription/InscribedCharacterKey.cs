using System;
using GameData.Serializer;

namespace GameData.Domains.Global.Inscription;

public struct InscribedCharacterKey(uint worldId, int charId) : ISerializableGameData, IEquatable<InscribedCharacterKey>
{
	public uint WorldId = worldId;

	public int CharId = charId;

	public static readonly InscribedCharacterKey Invalid = new InscribedCharacterKey(0u, -1);

	public static explicit operator ulong(InscribedCharacterKey value)
	{
		return (ulong)(((long)value.CharId << 32) + value.WorldId);
	}

	public static explicit operator InscribedCharacterKey(ulong value)
	{
		return new InscribedCharacterKey((uint)value, (int)(value >> 32));
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(uint*)pData = WorldId;
		((int*)pData)[1] = CharId;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		WorldId = *(uint*)pData;
		CharId = ((int*)pData)[1];
		return 8;
	}

	public bool Equals(InscribedCharacterKey other)
	{
		if (WorldId == other.WorldId)
		{
			return CharId == other.CharId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is InscribedCharacterKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)(WorldId * 397) ^ CharId;
	}
}
