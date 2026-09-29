using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData]
public struct FullBlockName : ISerializableGameData
{
	[SerializableGameDataField]
	public MapBlockData BlockData;

	[SerializableGameDataField]
	public MapBlockData BelongBlockData;

	[SerializableGameDataField]
	public sbyte stateTemplateId;

	[SerializableGameDataField]
	public short areaTemplateId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((BlockData == null) ? (totalSize + 2) : (totalSize + (2 + BlockData.GetSerializedSize())));
		totalSize = ((BelongBlockData == null) ? (totalSize + 2) : (totalSize + (2 + BelongBlockData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (BlockData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = BlockData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BelongBlockData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = BelongBlockData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)stateTemplateId;
		pCurrData++;
		*(short*)pCurrData = areaTemplateId;
		pCurrData += 2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (BlockData == null)
			{
				BlockData = new MapBlockData();
			}
			pCurrData += BlockData.Deserialize(pCurrData);
		}
		else
		{
			BlockData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (BelongBlockData == null)
			{
				BelongBlockData = new MapBlockData();
			}
			pCurrData += BelongBlockData.Deserialize(pCurrData);
		}
		else
		{
			BelongBlockData = null;
		}
		stateTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		areaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
