using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 采集资源结果
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public struct CollectResourceResult : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ResourceType;

	[SerializableGameDataField]
	public int ResourceCount;

	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
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
		*pCurrData = (byte)ResourceType;
		pCurrData++;
		*(int*)pCurrData = ResourceCount;
		pCurrData += 4;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ItemDisplayData == null)
			{
				ItemDisplayData = new ItemDisplayData();
			}
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
