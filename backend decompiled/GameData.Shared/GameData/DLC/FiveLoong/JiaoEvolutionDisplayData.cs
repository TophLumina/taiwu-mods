using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 五方神龙 - 蛟的进化前端显示数据
/// </summary>
[SerializableGameData]
public class JiaoEvolutionDisplayData : ISerializableGameData
{
	/// <summary>
	/// 蛟Id
	/// </summary>
	[SerializableGameDataField]
	public int JiaoId;

	/// <summary>
	/// 当前随机的结果
	/// </summary>
	[SerializableGameDataField]
	public short SimulationResult;

	/// <summary>
	/// 是否曾经有过该龙子
	/// </summary>
	[SerializableGameDataField]
	public bool IsOwnedResult;

	/// <summary>
	/// 蛟模拟化形结果的状态
	/// </summary>
	[SerializableGameDataField]
	public sbyte Status;

	/// <summary>
	/// 蛟的物品展示数据
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
