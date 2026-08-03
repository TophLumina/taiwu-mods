using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 志向tips显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ProfessionTipDisplayData : ISerializableGameData
{
	/// <summary>
	/// 志向id
	/// </summary>
	[SerializableGameDataField]
	public int ProfessionId;

	/// <summary>
	/// 当前生效的造诣，武学或技艺
	/// </summary>
	[SerializableGameDataField]
	public sbyte WorkingSkillType;

	/// <summary>
	/// 造诣加成值
	/// </summary>
	[SerializableGameDataField]
	public int AttainmentBonus;

	/// <summary>
	/// 志向成长值
	/// </summary>
	[SerializableGameDataField]
	public int ProfessionUpgrade;

	/// <summary>
	/// 志向成长值加成
	/// </summary>
	[SerializableGameDataField]
	public int ProfessionUpgradeBonus;

	/// <summary>
	/// 是否穿着对应的服装
	/// </summary>
	/// <returns></returns>
	[SerializableGameDataField]
	public bool IsWearingBonusClothing;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = ProfessionId;
		byte* num = pData + 4;
		*num = (byte)WorkingSkillType;
		byte* num2 = num + 1;
		*(int*)num2 = AttainmentBonus;
		byte* num3 = num2 + 4;
		*(int*)num3 = ProfessionUpgrade;
		byte* num4 = num3 + 4;
		*(int*)num4 = ProfessionUpgradeBonus;
		byte* num5 = num4 + 4;
		*num5 = (IsWearingBonusClothing ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
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
		ProfessionId = *(int*)pCurrData;
		pCurrData += 4;
		WorkingSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		AttainmentBonus = *(int*)pCurrData;
		pCurrData += 4;
		ProfessionUpgrade = *(int*)pCurrData;
		pCurrData += 4;
		ProfessionUpgradeBonus = *(int*)pCurrData;
		pCurrData += 4;
		IsWearingBonusClothing = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
