using System;
using GameData.Serializer;

namespace GameData.Domains.Global.Inscription;

/// <summary>
/// 铭刻的角色的索引
/// </summary>
public struct InscribedCharacterKey : ISerializableGameData, IEquatable<InscribedCharacterKey>
{
	/// <summary>
	/// 世界 ID
	/// </summary>
	public uint WorldId;

	/// <summary>
	/// 角色 ID
	/// </summary>
	public int CharId;

	/// <summary>
	/// 无效的铭刻角色Key
	/// </summary>
	public static readonly InscribedCharacterKey Invalid = new InscribedCharacterKey(0u, -1);

	/// <summary>
	/// 铭刻的角色的索引
	/// </summary>
	/// <param name="worldId"></param>
	/// <param name="charId"></param>
	public InscribedCharacterKey(uint worldId, int charId)
	{
		WorldId = worldId;
		CharId = charId;
	}

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
