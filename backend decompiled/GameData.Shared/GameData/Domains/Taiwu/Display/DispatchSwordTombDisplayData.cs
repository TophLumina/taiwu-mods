using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class DispatchSwordTombDisplayData : ISerializableGameData
{
	/// <summary>
	/// 剑冢id，对应配置表
	/// </summary>
	[SerializableGameDataField]
	public sbyte Id;

	/// <summary>
	/// 位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 位置详情，方便显示
	/// </summary>
	[SerializableGameDataField]
	public MapBlockData BlockData;

	/// <summary>
	/// 位置详情Root，方便显示
	/// </summary>
	[SerializableGameDataField]
	public MapBlockData RootBlockData;

	/// <summary>
	/// 剩余出冢月数，有的可以没有
	/// </summary>
	[SerializableGameDataField]
	public short RemainingMonths;

	/// <summary>
	/// 剑冢中的化身状态，0:平静如常;1:隐有异动;2:破冢而出;3:打掉了
	/// </summary>
	[SerializableGameDataField]
	public sbyte EscapeState;

	/// <summary>
	/// 有多少护冢在看守
	/// </summary>
	[SerializableGameDataField]
	public short KeeperCount;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize = ((BlockData == null) ? (totalSize + 2) : (totalSize + (2 + BlockData.GetSerializedSize())));
		totalSize = ((RootBlockData == null) ? (totalSize + 2) : (totalSize + (2 + RootBlockData.GetSerializedSize())));
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
		*pCurrData = (byte)Id;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
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
		if (RootBlockData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = RootBlockData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = RemainingMonths;
		pCurrData += 2;
		*pCurrData = (byte)EscapeState;
		pCurrData++;
		*(short*)pCurrData = KeeperCount;
		pCurrData += 2;
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
		Id = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
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
			if (RootBlockData == null)
			{
				RootBlockData = new MapBlockData();
			}
			pCurrData += RootBlockData.Deserialize(pCurrData);
		}
		else
		{
			RootBlockData = null;
		}
		RemainingMonths = *(short*)pCurrData;
		pCurrData += 2;
		EscapeState = (sbyte)(*pCurrData);
		pCurrData++;
		KeeperCount = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
