using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class HealingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 可交互的品级
	/// </summary>
	[SerializableGameDataField]
	public int InteractTargetGrade;

	/// <summary>
	/// 元鸡效果治疗入魔值的量
	/// </summary>
	[SerializableGameDataField]
	public int HealXiangshuInfectionAmount;

	/// <summary>
	/// 地区恩义获取
	/// </summary>
	[SerializableGameDataField]
	public int GainSpiritualDebt;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = InteractTargetGrade;
		byte* num = pData + 4;
		*(int*)num = HealXiangshuInfectionAmount;
		byte* num2 = num + 4;
		*(int*)num2 = GainSpiritualDebt;
		int totalSize = (int)(num2 + 4 - pData);
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
		InteractTargetGrade = *(int*)pCurrData;
		pCurrData += 4;
		HealXiangshuInfectionAmount = *(int*)pCurrData;
		pCurrData += 4;
		GainSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
