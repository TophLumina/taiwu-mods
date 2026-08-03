using System;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 云游道技能数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteTravelingTaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 化外逍遥额外最大健康
	/// </summary>
	[SerializableGameDataField]
	public short BonusMaxHealth;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = BonusMaxHealth;
		int totalSize = (int)(pData + 2 - pData);
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
		BonusMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public void Initialize()
	{
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}
}
