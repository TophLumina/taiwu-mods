using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 选择道具规则数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SelectItemRules : ISerializableGameData
{
	/// <summary>
	/// 道具子类
	/// </summary>
	[SerializableGameDataField]
	public short ItemSubType = -1;

	/// <summary>
	/// 仅可从行囊中选取
	/// </summary>
	[SerializableGameDataField]
	public bool OnlyFromInventory;

	/// <summary>
	/// 指定道具是否匹配某筛选规则
	/// </summary>
	public bool IsMatch(ItemKey itemKey)
	{
		if (ItemSubType >= 0)
		{
			return itemKey.GetConfig().ItemSubType == ItemSubType;
		}
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SelectItemRules()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SelectItemRules(SelectItemRules other)
	{
		ItemSubType = other.ItemSubType;
		OnlyFromInventory = other.OnlyFromInventory;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SelectItemRules other)
	{
		ItemSubType = other.ItemSubType;
		OnlyFromInventory = other.OnlyFromInventory;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
