using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 收购显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class AcquiringDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 额外收购一次的概率
	/// </summary>
	[SerializableGameDataField]
	public int ExtraBuyPossibility;

	/// <summary>
	/// 收购价百分比
	/// </summary>
	[SerializableGameDataField]
	public int PricePercent;

	/// <summary>
	/// 收购中物品
	/// </summary>
	[SerializableGameDataField]
	public TemplateKey AcquiringItem;

	/// <summary>
	/// 额外商会好感度
	/// </summary>
	[SerializableGameDataField]
	public int ExtraMerchantFavor;

	/// <summary>
	/// 已购数量
	/// </summary>
	[SerializableGameDataField]
	public int BoughtAmount;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = ExtraBuyPossibility;
		pCurrData += 4;
		*(int*)pCurrData = PricePercent;
		pCurrData += 4;
		pCurrData += AcquiringItem.Serialize(pCurrData);
		*(int*)pCurrData = ExtraMerchantFavor;
		pCurrData += 4;
		*(int*)pCurrData = BoughtAmount;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
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
		ExtraBuyPossibility = *(int*)pCurrData;
		pCurrData += 4;
		PricePercent = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += AcquiringItem.Deserialize(pCurrData);
		ExtraMerchantFavor = *(int*)pCurrData;
		pCurrData += 4;
		BoughtAmount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
