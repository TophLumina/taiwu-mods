using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

[SerializableGameData]
public class JiaoEvolutionDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int JiaoId;

	[SerializableGameDataField]
	public short SimulationResult;

	[SerializableGameDataField]
	public bool IsOwnedResult;

	[SerializableGameDataField]
	public sbyte Status;

	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	public JiaoEvolutionDisplayData()
	{
		JiaoId = -1;
		SimulationResult = -1;
		IsOwnedResult = false;
		Status = -1;
		ItemDisplayData = null;
	}

	public JiaoEvolutionDisplayData(int jiaoId, short simulationResult, bool isOwnedResult, sbyte status, ItemDisplayData itemDisplayData)
	{
		JiaoId = jiaoId;
		SimulationResult = simulationResult;
		IsOwnedResult = isOwnedResult;
		Status = status;
		ItemDisplayData = itemDisplayData;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = JiaoId;
		pCurrData += 4;
		*(short*)pCurrData = SimulationResult;
		pCurrData += 2;
		*pCurrData = (IsOwnedResult ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)Status;
		pCurrData++;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		JiaoId = *(int*)pCurrData;
		pCurrData += 4;
		SimulationResult = *(short*)pCurrData;
		pCurrData += 2;
		IsOwnedResult = *pCurrData != 0;
		pCurrData++;
		Status = (sbyte)(*pCurrData);
		pCurrData++;
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
