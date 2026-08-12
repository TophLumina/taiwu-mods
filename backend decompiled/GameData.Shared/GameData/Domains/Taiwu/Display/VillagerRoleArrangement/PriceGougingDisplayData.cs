using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 哄抬物价
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PriceGougingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 指定物品
	/// </summary>
	[SerializableGameDataField]
	public TemplateKey GougingItem;

	/// <summary>
	/// 价格上涨速率
	/// </summary>
	[SerializableGameDataField]
	public int PriceRiseRate;

	/// <summary>
	/// 最大价格是原来的多少倍
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
		pCurrData += GougingItem.Serialize(pCurrData);
		*(int*)pCurrData = PriceRiseRate;
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
		pCurrData += GougingItem.Deserialize(pCurrData);
		PriceRiseRate = *(int*)pCurrData;
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
