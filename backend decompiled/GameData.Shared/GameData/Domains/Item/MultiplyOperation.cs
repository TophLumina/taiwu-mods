using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData]
public struct MultiplyOperation(ItemKey target, ItemKey tool, int count, sbyte targetItemSourceType, sbyte toolItemSourceType) : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey Target = target;

	[SerializableGameDataField]
	public int Count = count;

	[SerializableGameDataField]
	public ItemKey Tool = tool;

	[SerializableGameDataField]
	public sbyte TargetItemSourceType = targetItemSourceType;

	[SerializableGameDataField]
	public sbyte ToolItemSourceType = toolItemSourceType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
