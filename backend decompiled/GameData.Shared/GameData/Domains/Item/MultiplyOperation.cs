using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 多选的单个操作
/// </summary>
[SerializableGameData]
public struct MultiplyOperation(ItemKey target, ItemKey tool, int count, sbyte targetItemSourceType, sbyte toolItemSourceType) : ISerializableGameData
{
	/// <summary>
	/// 要操作的物品KEY
	/// </summary>
	[SerializableGameDataField]
	public ItemKey Target = target;

	/// <summary>
	/// 要操作的物品的数量
	/// </summary>
	[SerializableGameDataField]
	public int Count = count;

	/// <summary>
	/// 对应使用的工具KEY
	/// </summary>
	[SerializableGameDataField]
	public ItemKey Tool = tool;

	/// <summary>
	/// 目标物品的来源类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte TargetItemSourceType = targetItemSourceType;

	/// <summary>
	/// 工具的来源类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ToolItemSourceType = toolItemSourceType;

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Target.Serialize(pCurrData);
		*(int*)pCurrData = Count;
		pCurrData += 4;
		pCurrData += Tool.Serialize(pCurrData);
		*pCurrData = (byte)TargetItemSourceType;
		pCurrData++;
		*pCurrData = (byte)ToolItemSourceType;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Target.Deserialize(pCurrData);
		Count = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Tool.Deserialize(pCurrData);
		TargetItemSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ToolItemSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
