using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(NotForArchive = true)]
public class SelectItemRules : ISerializableGameData
{
	[SerializableGameDataField]
	public short ItemSubType = -1;

	[SerializableGameDataField]
	public bool OnlyFromInventory;

	public bool IsMatch(ItemKey itemKey)
	{
		if (ItemSubType >= 0)
		{
			return itemKey.GetConfig().ItemSubType == ItemSubType;
		}
		return true;
	}

	public SelectItemRules()
	{
	}

	public SelectItemRules(SelectItemRules other)
	{
		ItemSubType = other.ItemSubType;
		OnlyFromInventory = other.OnlyFromInventory;
	}

	public void Assign(SelectItemRules other)
	{
		ItemSubType = other.ItemSubType;
		OnlyFromInventory = other.OnlyFromInventory;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = ItemSubType;
		byte* num = pData + 2;
		*num = (OnlyFromInventory ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		OnlyFromInventory = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
