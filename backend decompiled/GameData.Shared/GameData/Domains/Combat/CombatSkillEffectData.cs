using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 功法效果数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CombatSkillEffectData : ISerializableGameData
{
	/// <summary>
	/// 功法效果类型，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalType;

	/// <summary>
	/// 功法效果参数，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private int _internalParam0;

	/// <summary>
	/// 功法效果类型
	/// </summary>
	public ECombatSkillEffectType Type => (ECombatSkillEffectType)_internalType;

	/// <summary>
	/// 功法效果值
	/// </summary>
	public int Value => _internalParam0;

	/// <summary>
	/// 构造功法效果数据
	/// </summary>
	/// <param name="type"></param>
	/// <param name="param0"></param>
	public CombatSkillEffectData(ECombatSkillEffectType type, int param0)
	{
		_internalType = (sbyte)type;
		_internalParam0 = param0;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)_internalType;
		byte* num = pData + 1;
		*(int*)num = _internalParam0;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_internalType = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam0 = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
