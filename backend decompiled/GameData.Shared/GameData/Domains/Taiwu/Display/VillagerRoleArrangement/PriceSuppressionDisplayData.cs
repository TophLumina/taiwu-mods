using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 抑制物价
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PriceSuppressionDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 指定物品
	/// </summary>
	[SerializableGameDataField]
	public TemplateKey SuppressionItem;

	/// <summary>
	/// 价格下降速率
	/// </summary>
	[SerializableGameDataField]
	public int PriceDropRate;

	/// <summary>
	/// 最小价格是原来的多少倍
	/// </summary>
	[SerializableGameDataField]
	public int MaxPriceTimes;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 11;
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
		pCurrData += SuppressionItem.Serialize(pCurrData);
		*(int*)pCurrData = PriceDropRate;
		pCurrData += 4;
		*(int*)pCurrData = MaxPriceTimes;
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
		pCurrData += SuppressionItem.Deserialize(pCurrData);
		PriceDropRate = *(int*)pCurrData;
		pCurrData += 4;
		MaxPriceTimes = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
