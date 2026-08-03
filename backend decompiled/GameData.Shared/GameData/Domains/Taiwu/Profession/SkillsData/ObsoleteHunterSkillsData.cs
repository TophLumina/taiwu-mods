using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteHunterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 坐骑攻击每月可用次数
	/// </summary>
	public const sbyte CarrierAnimalAttackCountPerMonth = 3;

	/// <summary>
	/// 本月已使用坐骑攻击次数。用于猎户技能3，过月时重置
	/// </summary>
	[SerializableGameDataField]
	public sbyte UsedCarrierAnimalAttackCount;

	/// <summary>
	/// 获取剩余次数
	/// </summary>
	public sbyte RemainCount => (sbyte)MathUtils.Clamp(3 - UsedCarrierAnimalAttackCount, 0, 3);

	/// <inheritdoc />
	public void Initialize()
	{
		UsedCarrierAnimalAttackCount = 0;
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public ObsoleteHunterSkillsData()
	{
		UsedCarrierAnimalAttackCount = 0;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 1;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)UsedCarrierAnimalAttackCount;
		int totalSize = (int)(pData + 1 - pData);
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
		UsedCarrierAnimalAttackCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
